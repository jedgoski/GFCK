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
using System.Collections;
using TECIT.TBarCode;

namespace TECIT.OnlineBarcodes
{
    /// <summary>
    /// friendlyUrls 
    /// </summary>
    public enum friendlyUrl { Null, Url1, Url2, Url3 }

    /// <summary>
    /// Summary description for StandardBarcodes
    /// </summary>
    public static class StandardBarcodes
    {
        private static Dictionary<String, BarcodeInfo> m_BarcodeInfo = null;
        private static bool _initialized = false;
        private static string _lock = "StandardBarcodes";

        // set default barcode
        public const String DefaultBarcodeId = "Code128";

        /// <summary>
        /// Inits this instance.
        /// </summary>
        private static void Init()
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (!_initialized)
                    {
                        Add(new BarcodeInfo("Aztec", BarcodeType.Aztec, CompositeComponentTypes.None, 4, 4, 0));
                        Add(new BarcodeInfo("DataMatrix", BarcodeType.DataMatrix, CompositeComponentTypes.None, 4, 4, 0));
                        Add(new BarcodeInfo("MicroPDF417", BarcodeType.MicroPdf417, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("PDF417", BarcodeType.Pdf417, CompositeComponentTypes.None, 2, 3, 0));
                        Add(new BarcodeInfo("QRCode", BarcodeType.QRCode, CompositeComponentTypes.None, 4, 4, 0));
                        Add(new BarcodeInfo("Code128", BarcodeType.Code128, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("Code25IL", BarcodeType.Code2Of5Interleaved, CompositeComponentTypes.None, 0, 0, 80));
                        Add(new BarcodeInfo("Code39", BarcodeType.Code39, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("Code93", BarcodeType.Code93, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("EAN8", BarcodeType.Ean8, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("EAN13", BarcodeType.Ean13, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("EANUCC128", BarcodeType.EanUcc128, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("UPCA", BarcodeType.UpcA, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("UPCE", BarcodeType.UpcE, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("AustralianPost", BarcodeType.AustralianPostCustom, CompositeComponentTypes.None, 2, 1, 20));
                        Add(new BarcodeInfo("JapanesePostal", BarcodeType.JapanesePostal, CompositeComponentTypes.None, 2, 2, 14));
                        Add(new BarcodeInfo("PostNet5", BarcodeType.UspsPostnet5, CompositeComponentTypes.None, 2, 1, 12));
                        Add(new BarcodeInfo("PostNet9", BarcodeType.UspsPostnet9, CompositeComponentTypes.None, 2, 1, 12));
                        Add(new BarcodeInfo("PostNet11", BarcodeType.UspsPostnet11, CompositeComponentTypes.None, 2, 1, 12));
                        Add(new BarcodeInfo("USPSOneCode", BarcodeType.UspsIntelligentMail, CompositeComponentTypes.None, 2, 1, 20));
                        Add(new BarcodeInfo("RSS14", BarcodeType.Gs1DataBar, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("RSS14Stacked", BarcodeType.Gs1DataBarStacked, CompositeComponentTypes.None, 3, 3, 0));
                        Add(new BarcodeInfo("RSS14StackedOmni", BarcodeType.Gs1DataBarStackedOmnidirectional, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("RSSLimited", BarcodeType.Gs1DataBarLimited, CompositeComponentTypes.None, 0, 0, 0));
                        Add(new BarcodeInfo("RSSExpanded", BarcodeType.Gs1DataBarExpanded, CompositeComponentTypes.None, 1, 1, 0));
                        Add(new BarcodeInfo("RSSExpandedStacked", BarcodeType.Gs1DataBarExpandedStacked, CompositeComponentTypes.None, 2, 2, 0));
                        Add(new BarcodeInfo("EAN8CCA", BarcodeType.Ean8, CompositeComponentTypes.Auto, 2, 2, 0));
                        Add(new BarcodeInfo("EAN13CCA", BarcodeType.Ean13, CompositeComponentTypes.Auto, 2, 2, 0));
                        Add(new BarcodeInfo("GS1-128CCA", BarcodeType.GS1_128, CompositeComponentTypes.Auto, 0, 0, 0));
                        Add(new BarcodeInfo("RSS14CCA", BarcodeType.Gs1DataBar, CompositeComponentTypes.Auto, 3, 3, 0));
                        Add(new BarcodeInfo("RSS14StackedCCA", BarcodeType.Gs1DataBarStacked, CompositeComponentTypes.Auto, 3, 3, 0));
                        Add(new BarcodeInfo("RSS14StackedOmniCCA", BarcodeType.Gs1DataBarStackedOmnidirectional, CompositeComponentTypes.Auto, 0, 0, 0));
                        Add(new BarcodeInfo("RSSLimitedCCA", BarcodeType.Gs1DataBarLimited, CompositeComponentTypes.Auto, 0, 0, 0));
                        Add(new BarcodeInfo("RSSExpandedCCA", BarcodeType.Gs1DataBarExpanded, CompositeComponentTypes.Auto, 2, 2, 0));
                        Add(new BarcodeInfo("RSSExpandedStackedCCA", BarcodeType.Gs1DataBarExpandedStacked, CompositeComponentTypes.Auto, 2, 2, 0));
                        Add(new BarcodeInfo("UPCACCA", BarcodeType.UpcA, CompositeComponentTypes.Auto, 2, 2, 0));
                        Add(new BarcodeInfo("UPCECCA", BarcodeType.UpcE, CompositeComponentTypes.Auto, 0, 0, 0));

                        _initialized = true;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the specified bcinfo.
        /// </summary>
        /// <param name="bcinfo">The bcinfo.</param>
        static private void Add(BarcodeInfo bcinfo)
        {
            try
            {
                if (m_BarcodeInfo == null)
                    m_BarcodeInfo = new Dictionary<string, BarcodeInfo>();

                m_BarcodeInfo.Add(bcinfo.Identifier, bcinfo);
            }
            catch
            {
                // should only happen if the info was already added to the dictioniary
            }

        }

        /// <summary>
        /// Gets the barcode info.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static BarcodeInfo GetBarcodeInfo(string id)
        {
            if (!_initialized)
                Init();

            // todo maybe an Exception would be better
            if (m_BarcodeInfo.ContainsKey(id))
                return m_BarcodeInfo[id];
            else
                throw new Exception(String.Format("The barcode symbology {0} is unknown, please check your parameters.", id));
        }

        /// <summary>
        /// Gets the barcode infos dictionary.
        /// </summary>
        /// <value>The barcode infos.</value>
        public static Dictionary<String, BarcodeInfo> BarcodeInfos
        {
            get
            {
                if (!_initialized)
                    Init();
                return m_BarcodeInfo;
            }
        }
    }
}