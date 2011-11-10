using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using TECIT.TBarCode;

namespace TECIT.OnlineBarcodes
{
    /// <summary>
    /// Summary description for BarcodeInfo
    /// </summary>
    public class BarcodeInfo
    {
        // key used in drop down list
        public String Identifier;

        // barcode size
        public int ScaleX;
        public int ScaleY;
        public int DefaultHeight;

        // barcode type
        public BarcodeType BarcodeType;
        public CompositeComponentTypes CompositeComponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BarcodeInfo"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="barcodeType">Type of the barcode.</param>
        /// <param name="compositeComponent">The composite component.</param>
        /// <param name="scaleX">The scale X.</param>
        /// <param name="scaleY">The scale Y.</param>
        /// <param name="defaultH">The default H.</param>
        public BarcodeInfo(string identifier, BarcodeType barcodeType, CompositeComponentTypes compositeComponent,
                            int scaleX, int scaleY, int defaultHeight)
        {

            this.Identifier = identifier;

            // set barcode type
            this.BarcodeType = barcodeType;
            this.CompositeComponent = compositeComponent;

            // set barcode size
            if (scaleX <= 0)
                this.ScaleX = 2;
            else
                this.ScaleX = scaleX;

            if (scaleY <= 0)
                this.ScaleY = 2;
            else
                this.ScaleY = scaleY;

            if (defaultHeight <= 0)
                DefaultHeight = 100;
            else
                this.DefaultHeight = defaultHeight;


        }
    }
}