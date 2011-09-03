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
        public Byte Image { get; set; }
        public String Value { get; set; }
        public String Discount { get; set; }
        public String Details { get; set; }
        public String Terms { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Int32 NumberOfCoupons { get; set; }
        public String BottomAdvertisement { get; set; }
        public List<Category> Categories { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Enabled { get; set; }
    }
}
