using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf.qrcode;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace GFCK.handlers
{
    /// <summary>
    /// Summary description for barcode
    /// </summary>
    public class barcode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           // iTextSharp.text.pdf.BarcodeQRCode qrcode = new BarcodeQRCode("just testing  the barcode", 50, 50, null);
            //iTextSharp.text.Image img = qrcode.GetImage();

            try
            {
                Barcode39 bc39 = new Barcode39();

                bc39.Code = "1234";
                System.Drawing.Image bc = bc39.CreateDrawingImage(System.Drawing.Color.Black,System.Drawing.Color.White);
                
                context.Response.ContentType = "image/gif";
                bc.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
                
                //MemoryStream ms = new MemoryStream(img.RawData);
                //System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                //returnImage.Save("img.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //context.Response.ContentType = "image/jpeg";
                //context.Response.BinaryWrite(ms.ToArray());

            }
            catch (Exception ex)
            {
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