using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace GFCK.handlers
{
    public partial class barcode_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            iTextSharp.text.pdf.BarcodeQRCode qrcode = new BarcodeQRCode("testing", 50, 50, null);
            iTextSharp.text.Image img1 = qrcode.GetImage();
            Document doc = new Document();

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("css") + "/Images.pdf", FileMode.Create));
                doc.Open();
                doc.Add(new Paragraph("GIF"));

                doc.Add(img1);
                MemoryStream ms = new MemoryStream(img1.OriginalData);
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);

               // img = returnImage.Save(new Stream(), System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
            }
            finally
            {
                doc.Close();
            }
        }
    }
}