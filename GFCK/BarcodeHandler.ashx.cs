using System;
using System.Collections.Generic;
using System.Web;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using TECIT.TBarCode;

namespace TECIT.OnlineBarcodes
{

  /// <summary>
  /// Summary description for $codebehindclassname$
  /// </summary>
  //[WebService(Namespace = "http://tempuri.org/")]
  //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  public class BarcodeHandler : IHttpHandler
  {
    private TECIT.TBarCode.Barcode _myBarcode = new TECIT.TBarCode.Barcode();
    private BarcodeInfo _barcodeInfo = null;

    private const double _mils_mm = 0.0254;
    private const double _px_mm = 0.265;
    private const int DPI_MAX = 600;
    private const int DPI_MIN = 72;
    private const float DPI_SCREEN_DEFAULT = 96;

    private string _code = "Code128";
    private string _composite = null;
    private string _imageFormat = null;
    private string _data = null;
    private string _dpi = "96";
    private string _moduleWidth = String.Empty;
    private string _unit = String.Empty;

    private string _translateEscape = null;
    private string _humanReadableText = null;
    private string _rotation = null;
    private double _width = 0;
    private double _height = 0;
    private int _scaleX = 0;
    private int _scaleY = 0;

    private bool _printDataText = true;

    HttpResponse _response;
    HttpRequest _request;

    public void ProcessRequest(HttpContext context)
    {
      _response = context.Response;
      _request = context.Request;

      try
      {
        InitFromQueryString();
        SetBarcodeParameter();
        WriteImageToStream(GenerateBarcode());
      }
      catch (Exception except)
      {
        WriteImageToStream(CreateErrorBitmap(except.Message));
      }
    }


    /// <summary>
    /// Draws a Bitmap containing the specified error message
    /// </summary>
    /// <param name="errMessage"></param>
    /// <returns></returns>
    private Bitmap CreateErrorBitmap(string errMessage)
    {
        int width = 300;
        int height = 100;

        Bitmap errBitmap = new Bitmap(width, height);

        Graphics g = Graphics.FromImage(errBitmap);

        StringFormat strFormat = new StringFormat();

        strFormat.Alignment = StringAlignment.Center;
        strFormat.LineAlignment = StringAlignment.Center;

        g.FillRectangle(Brushes.White, 0, 0, width, height);
        g.DrawRectangle(new Pen(Brushes.LightGray, 1), new Rectangle(0, 28, width - 1, height - 33));

        strFormat.Alignment = StringAlignment.Center;
        strFormat.LineAlignment = StringAlignment.Near;
        g.DrawString("Barcode Generator Error", new Font("Arial", 10, FontStyle.Bold), Brushes.Red, new Rectangle(0, 5, width, 15), strFormat);

        strFormat.Alignment = StringAlignment.Center;
        strFormat.LineAlignment = StringAlignment.Center;

        switch (errMessage)
        {
            case "Wrong character":
                errMessage = "Input data contains unsupported characters - select another barcode type or correct your input data.";
                break;
            case "Wrong number of input characters":
                errMessage = "This barcode needs a specific number of input characters - correct your data.";
                break;
            default:
                break;
        }

        g.DrawString(errMessage, new Font("Arial", 10), Brushes.Red, new Rectangle(8, 28, width - 16, height - 35), strFormat);

        return errBitmap;
    }


    /// <summary>
    /// Sets the barcode parameter.
    /// </summary>
    private void SetBarcodeParameter()
    {
        _barcodeInfo = StandardBarcodes.GetBarcodeInfo(_code);

        // license
        // put in your license code here
        //_myBarcode.License("Licensee Name", LicenseType.DeveloperOrWeb, 1, "hex code goes here", TBarCodeProduct.Barcode2D);

        _myBarcode.Dpi = GetValidatedDPI(_dpi);

        // set barcode font
        _myBarcode.FontName = "Arial";

        // workaround for "Not Implemented Bug"!!
        _myBarcode.MultipleBarcodes.StructuredAppendMode = StructuredAppendMode.None;

        // --- BARCODE DATA ---

        if (String.IsNullOrEmpty(_data))
            throw new Exception("No bar code data specified");

        // auto correct for Code-39: leading/trailing asterisks are not allowed
        if (_barcodeInfo.BarcodeType == BarcodeType.Code39
            || _barcodeInfo.BarcodeType == BarcodeType.Code39Extended)
        {
            char[] trims = { '*' };
            _data = _data.Trim(trims);
        }

		if (_translateEscape == "on")
            _myBarcode.TranslateEscapeSequences = true;
			
        _myBarcode.Data = _data;

        // --- BAR CODE TYPE ---

        _myBarcode.BarcodeType = _barcodeInfo.BarcodeType;

        SetComposite();

        // --- BAR CODE SIZE ---

        SetModuleWidth();

        SetBarcodeSize();

        _myBarcode.HumanReadableText = _humanReadableText;

        _myBarcode.IsTextVisible = _printDataText;

        SetRotation();


    }

    /// <summary>
    /// Sets the appropriate Rotation 
    /// </summary>
    private void SetRotation()
    {
        bool switchDimensions = false;
        switch (_rotation)
        {
            case "90":
                _myBarcode.Rotation = Rotation.Degree90;
                switchDimensions = true;
                break;
            case "180":
                _myBarcode.Rotation = Rotation.Degree180;
                break;
            case "270":
                _myBarcode.Rotation = Rotation.Degree270;
                switchDimensions = true;
                break;
            default:
                _myBarcode.Rotation = Rotation.Degree0;
                break;
        }

        if (switchDimensions)
        {
            _myBarcode.BoundingRectangle = new Rectangle(0, 0, _myBarcode.BoundingRectangle.Height, _myBarcode.BoundingRectangle.Width);
        }
    }

    /// <summary>
    /// Generates the barcode.
    /// </summary>
    private Bitmap GenerateBarcode()
    {
        Bitmap barcodeImage = null;

        barcodeImage = _myBarcode.DrawBitmap(_myBarcode.BoundingRectangle.Width, _myBarcode.BoundingRectangle.Height);
        barcodeImage.SetResolution((float)_myBarcode.Dpi, (float)_myBarcode.Dpi);

        return barcodeImage;
    }

    /// <summary>
    /// Writes the image to the output stream.
    /// </summary>
    /// <param name="bitmap"></param>
    private void WriteImageToStream(Bitmap bitmap)
    {
        _response.Clear();

        switch (_imageFormat == null ? null : _imageFormat.ToLower())
        {
            case "jpg":
            case "jpeg":
                _response.ContentType = "image/jpeg";

                // set jpg quality to highest level
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                myEncoderParameters.Param[0] = new EncoderParameter(myEncoder, 100L); // best quality;

                bitmap.Save(_response.OutputStream, jgpEncoder, myEncoderParameters);
                break;
            case "gif":
            default:
                _response.ContentType = "image/gif";
                bitmap.Save(_response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
                break;
        }

        bitmap.Dispose();
    }

    /// <summary>
    /// Gets the encoder.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <returns></returns>
    private ImageCodecInfo GetEncoder(ImageFormat format)
    {

        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }

    /// <summary>
    /// Sets the composite component type.
    /// </summary>
    private void SetComposite()
    {
        if (String.IsNullOrEmpty(_composite))
        {
            _myBarcode.CompositeSymbol.CCType = _barcodeInfo.CompositeComponent;
        }
        else
        {
            switch (_composite.ToLower())
            {
                case "cca":
                    _myBarcode.CompositeSymbol.CCType = CompositeComponentTypes.CCA;
                    break;
                case "ccb":
                    _myBarcode.CompositeSymbol.CCType = CompositeComponentTypes.CCB;
                    break;
                case "ccc":
                    _myBarcode.CompositeSymbol.CCType = CompositeComponentTypes.CCC;
                    break;
                case "auto":
                    _myBarcode.CompositeSymbol.CCType = CompositeComponentTypes.Auto;
                    break;
                case "none":
                    _myBarcode.CompositeSymbol.CCType = CompositeComponentTypes.None;
                    break;
                default:
                    _myBarcode.CompositeSymbol.CCType = _barcodeInfo.CompositeComponent;
                    break;
            }
        }
    }

    /// <summary>
    /// Sets the size of the barcode.
    /// </summary>
    private void SetBarcodeSize()
    {
        try
        {
            double widthPx = 0.0;
            double heightPx = 0.0;
            //double dpi = _myBarcode.Dpi;
            float screenDpiX = DPI_SCREEN_DEFAULT;
            double scaleDpi = (double)_myBarcode.Dpi / screenDpiX;

            bool is2DCode = _myBarcode.CalculateNumberOfRows() > 1;
            double horizontalModules = (is2DCode) ? _myBarcode.CalculateXColumnsOf2DBarcode() : _myBarcode.CalculateNumberOfModules();

            // use default scaling if nothing was set by the user
            _scaleX = _scaleX == 0 ? _barcodeInfo.ScaleX : _scaleX;
            _scaleY = _scaleY == 0 ? _barcodeInfo.ScaleY : _scaleY;

            // -- size mode "fit to bounding rectangle" --
            if (_myBarcode.SizeMode == SizeMode.FitToBoundingRectangle)
            {

                // if 2D symbology (count rows > 1)
                if (is2DCode)
                {
                    double xcols = horizontalModules;
                    double xrows = _myBarcode.CalculateXRowsOf2DBarcode();

                    // 2D symbology should use the values of XCols/XRows
                    widthPx = _scaleX * xcols;
                    heightPx = _scaleY * xrows;

                    // clear row height if set by previous code
                    _myBarcode.Pdf417.RowHeight = -1;
                }
                else
                {
                    widthPx = _scaleX * horizontalModules;
                    // generate linear codes always with default H
                    heightPx = _barcodeInfo.DefaultHeight;
                }

                // scale with DPI enlarging factor
                heightPx *= scaleDpi;
                widthPx *= scaleDpi;
            }
            // -- other size modes --
            else
            {
                // create screen compatible graphics object
                IntPtr nullDC = GDI32.CreateCompatibleDC(IntPtr.Zero);
                Graphics gfx = Graphics.FromHdcInternal(nullDC);

                // update 96 dpi default value with actual value here
                screenDpiX = gfx.DpiX;
                _myBarcode.IgnoreDpiFromDC = false;

                // correct module width because with non-standard screen res (e.g. 120dpi) the resulting mod width is wrong
                float correct = DPI_SCREEN_DEFAULT / screenDpiX;

                // default size
                SizeF size = new SizeF(75, 25);

                try
                {
                    float moduleWidth = _myBarcode.CalculateModuleWidth(gfx);

                    // check if bar width is < 1 Pixel
                    if (_myBarcode.SizeMode != SizeMode.MinimalModuleWidth
                        && (moduleWidth + 0.0001) < (25.4 / (_myBarcode.Dpi)))
                        throw new Exception("Module width too low!");

                    // scale and correct module width
                    if (scaleDpi > 1.0 || correct != 1.0)
                    {
                        if (scaleDpi > 1.0)
                            moduleWidth *= (float)scaleDpi; // don't go under 1 pixel

                        // increase modulewidth according to the dpi
                        _myBarcode.ModuleWidth = moduleWidth * correct;
                        _myBarcode.SizeMode = SizeMode.CustomModuleWidth;
                    }

                    // PDF417 and MicroPDF need special row height
                    if (_myBarcode.BarcodeType == BarcodeType.Pdf417
                        || _myBarcode.BarcodeType == BarcodeType.MicroPdf417)
                    {
                        _myBarcode.Pdf417.RowHeight = moduleWidth * 3 * correct;
                    }

                    // calculate bar code size (after setting row height!)
                    size = _myBarcode.CalculateBarcodeSize(gfx);

                }
                catch (Exception e)
                {
                    // forward to main error handler below
                    throw new Exception(e.Message);
                }
                finally
                {
                    // cleanup !!
                    GDI32.DeleteDC(nullDC);
                    gfx.Dispose();
                }

                // convert from mm to Pixels
                widthPx = Math.Ceiling(size.Width / 25.4 * screenDpiX);

                // for linear bar codes we use default height
                if (!is2DCode)
                {
                    heightPx = scaleDpi * _barcodeInfo.ScaleY * _barcodeInfo.DefaultHeight / _barcodeInfo.ScaleX;
                }
                else if (_myBarcode.BarcodeType == BarcodeType.Gs1DataBarStackedOmnidirectional)
                {
                    // fixed height/width ratio of 50/69
                    heightPx = Math.Ceiling(widthPx / 50 * 69);
                }
                else
                {
                    heightPx = Math.Ceiling(size.Height / 25.4 * screenDpiX /* simplified version - we use X instead of Y value here */);
                }
            }

            if (_myBarcode.BarcodeType == BarcodeType.DAFT)
            {
                _myBarcode.IsTextVisible = false;
            }

            heightPx = CalculateAutoFontHeight(widthPx, heightPx);

            switch (_unit)
            {
                case "mils":
                    widthPx = _width != 0 ? (_width * _mils_mm) / _px_mm : widthPx;
                    heightPx = _height != 0 ? (_height * _mils_mm) / _px_mm : heightPx;
                    break;
                case "px":
                    widthPx = _width != 0 ? _width : widthPx;
                    heightPx = _height != 0 ? _height : heightPx;
                    break;
                case "mm":
                default:
                    widthPx = _width != 0 ? _width / _px_mm : widthPx;
                    heightPx = _height != 0 ? _height / _px_mm : heightPx;
                    break;
            }

            // limit sizes
            if (widthPx > 25400) widthPx = 25400;
            if (heightPx > 25400) heightPx = 25400;

            _myBarcode.BoundingRectangle = new Rectangle(0, 0, (int)Math.Ceiling(widthPx), (int)Math.Ceiling(heightPx));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Calculates the height of the font.
    /// </summary>
    /// <param name="widthPx">The width px.</param>
    /// <param name="heightPx">The height px.</param>
    /// <returns></returns>
    private double CalculateAutoFontHeight(double widthPx, double heightPx)
    {

        double scaleDpi = (double)_myBarcode.Dpi / 96;

        bool is2DCode = _myBarcode.CalculateNumberOfRows() > 1;
        double horizontalModules = (is2DCode) ? _myBarcode.CalculateXColumnsOf2DBarcode() : _myBarcode.CalculateNumberOfModules();

        // --- FONT HEIGHT ---

        // auto font size with this formula: FontSize = ModWidth / 0.339 * 10;
        double fontHeight = 10 * ((25.4 / 96) * widthPx / horizontalModules) / 0.339;

        // reduce auto font for high density codes like GS-1 DataBar
        string barcodeName = _barcodeInfo.BarcodeType.ToString();
        if (barcodeName.Contains("Gs1DataBar"))
        {
            if (barcodeName.Contains("Limited"))
                fontHeight *= 0.7;
            else
                fontHeight *= 0.9;
        }

        // limit of font size to 25% of bar code height
        double fontHeightPx = 96 * fontHeight / 72;

        if (fontHeightPx > (heightPx / 4))
            fontHeight *= (heightPx / 4) / fontHeightPx;

        // lower limit is 7 pt
        if (fontHeight < (7.0 * scaleDpi))
            fontHeight = 7.0 * scaleDpi;

        // now set font height
        _myBarcode.FontHeight = (int)Math.Ceiling(fontHeight);

        // add font height to bar code height to have a valid bounding rectangle
        bool addFontHeight = false;
        switch (_myBarcode.BarcodeType)
        {
            // required for Postal Codes 
            case BarcodeType.UspsPostnet5:
            case BarcodeType.UspsPostnet9:
            case BarcodeType.UspsPostnet11:
            case BarcodeType.UspsIntelligentMail:
            case BarcodeType.AustralianPostCustom:
            case BarcodeType.RM4Scc:
            case BarcodeType.KoreanPostalAuthority:
            case BarcodeType.Planet12:
            case BarcodeType.JapanesePostal:
            case BarcodeType.KIX:

                addFontHeight = true;
                break;

            // required for Composite Codes with HRT
            case BarcodeType.Gs1DataBar:
            case BarcodeType.Gs1DataBarLimited:
            case BarcodeType.Gs1DataBarExpanded:
            case BarcodeType.UpcA:
            case BarcodeType.Ean13:
            case BarcodeType.Ean8:
            case BarcodeType.UpcE:
            case BarcodeType.GS1_128:
                if (_myBarcode.CompositeSymbol.CCType != CompositeComponentTypes.None)
                    addFontHeight = true;
                break;
        }
        if (addFontHeight)
        {
            fontHeightPx = 96 * fontHeight / 72;
            heightPx += fontHeightPx * 1.2;
        }

        return heightPx;
    }
    /// <summary>
    /// Gets the POST and GET parameters
    /// </summary>
    private void InitFromQueryString()
    {
        foreach (string key in _request.Form.AllKeys)
        {
            InitMemberFromQueryString(key, _request.Form.Get(key));
        }

        foreach (string key in _request.QueryString.AllKeys)
        {
            InitMemberFromQueryString(key, _request.QueryString.Get(key));
        }
    }

    /// <summary>
    /// Inits the member from query string.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    private void InitMemberFromQueryString(string key, string value)
    {
        try
        {
            NumberFormatInfo numFormat = new CultureInfo("en-US").NumberFormat;

            switch (key.ToLower())
            {
                case "code":
                    _code = value;
                    break;
                case "composite":
                    _composite = value;
                    break;
                case "text":
                    if (_data == null)
                    {
                        _data = value;
                    }
                    break;
                case "data":
                    _data = value;
                    break;
                case "dpi":
                    _dpi = value;
                    break;
                case "modulewidth":
                    _moduleWidth = value;
                    break;
                case "unit":
                    _unit = value;
                    break;
                case "translate-esc":
                    _translateEscape = value;
                    break;
                case "printdatatext":
                    _printDataText = bool.Parse(value);
                    break;
                case "hrt":
                    _humanReadableText = value;
                    break;
                case "format":
                    _imageFormat = value;
                    break;
                case "rotation":
                    _rotation = value;
                    break;
                case "width":
                    string width = value.Replace(',', '.');
                    _width = double.Parse(width, numFormat);
                    break;
                case "height":
                    string height = value.Replace(',', '.');
                    _height = double.Parse(height, numFormat);
                    break;
                case "scalex":
                    string scaleX = value.Replace(',', '.');
                    _scaleX = int.Parse(scaleX, numFormat);
                    break;
                case "scaley":
                    string scaleY = value.Replace(',', '.');
                    _scaleY = int.Parse(scaleY, numFormat);
                    break;
                default: break;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error in Parameter '" + key + "': " + ex.Message);
        }
    }

    /// <summary>
    /// Gets a validated DPI value.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <returns></returns>
    private int GetValidatedDPI(string p)
    {
        Int32 dpi = 0;

        try { dpi = Int32.Parse(p); }
        catch { };

        if (dpi < DPI_MIN)
        {
            throw new Exception(String.Format("DPI setting is too low - The minimum for this application is {0}", DPI_MIN));
        }

        if (dpi > DPI_MAX)
        {
            throw new Exception(String.Format("DPI setting is too high - The maximum for this application is {0}", DPI_MAX));
        }

        return dpi;
    }

    /// <summary>
    /// Sets the width of the module.
    /// </summary>
    private void SetModuleWidth()
    {
        string mode;

        _moduleWidth = _moduleWidth.Trim().ToLower();
        _unit = _unit.Trim().ToLower();

        if (_moduleWidth.Equals("fit", StringComparison.OrdinalIgnoreCase)
            || _moduleWidth.Equals("min", StringComparison.OrdinalIgnoreCase))
            mode = _moduleWidth;
        else if (_unit.Equals("fit", StringComparison.OrdinalIgnoreCase)
            || _unit.Equals("min", StringComparison.OrdinalIgnoreCase))
            mode = _unit;
        else if (_unit.Equals("mm")
            || _unit.Equals("px")
            || _unit.Equals("mils"))
            mode = "custom";
        else
            mode = "auto";

        switch (mode)
        {
            case "min":
                _myBarcode.SizeMode = SizeMode.MinimalModuleWidth;
                break;                
            case "custom":
                _myBarcode.SizeMode = SizeMode.CustomModuleWidth;
                _moduleWidth = _moduleWidth.Replace(',', '.');

                if (String.IsNullOrEmpty(_moduleWidth))
                    throw new Exception("Please specify a module width!");

                float moduleWidth = float.Parse(_moduleWidth, new CultureInfo("en-US").NumberFormat);

                if (moduleWidth < 0)
                {
                    moduleWidth *= -1;
                }

                switch (_unit)
                {
                    case "mils":
                        _myBarcode.ModuleWidth = (float)(moduleWidth * _mils_mm);
                        break;
                    case "px":
                        _myBarcode.ModuleWidth = (float)(moduleWidth * 25.4 / _myBarcode.Dpi);
                        break;
                    case "mm":
                    default:
                        _myBarcode.ModuleWidth = moduleWidth;
                        break;
                }
                break;
            
            case "fit":
            case "auto":
            default:
                _myBarcode.SizeMode = SizeMode.FitToBoundingRectangle;
                break;
        }
    }


    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}
