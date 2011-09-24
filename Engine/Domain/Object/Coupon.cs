using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Domain.Object
{
   public class Coupon
    {
        public Int64 ID { get; set; }
        public Int64 MerchantID { get; set; }
        public Int64 TemplateID { get; set; }
        public Int64 CategoryID { get; set; }
        public String CategoryName { get; set; }
        public Byte[] Image { get; set; }
        public String Value { get; set; }
        public String Discount { get; set; }
        public String Details { get; set; }
        public String Terms { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool GlutenFreeFacility { get; set; }
        public bool ContainGluten20PPM { get; set; }
        public bool LessThan5PPM { get; set; }
        public bool CaseinFree { get; set; }
        public bool SoyFree { get; set; }
        public bool NutFree { get; set; }
        public bool EggFree { get; set; }
        public bool CornFree { get; set; }
        public bool YeastFree { get; set; }
        public bool Barcode1Enabled { get; set; }
        public Int64 Barcode1TypeID { get; set; }
        public String Barcode1TypeName { get; set; }
        public String Barcode1Value { get; set; }
        public bool Barcode2Enabled { get; set; }
        public Int64 Barcode2TypeID { get; set; }
        public String Barcode2TypeName { get; set; }
        public String Barcode2Value { get; set; }
        public Int32 NumberOfCoupons { get; set; }
        public String BottomAdvertisement { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
