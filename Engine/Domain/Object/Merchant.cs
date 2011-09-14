using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Domain.Object
{
    public class Merchant
    {
        public Int64 ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MerchantName { get; set; }
        public String Description { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Enabled { get; set; }
    }
}
