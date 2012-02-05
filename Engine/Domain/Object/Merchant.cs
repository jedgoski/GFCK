using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Domain.Object
{
    public class Merchant
    {
        public Int64 ID { get; set; }
        public Guid UserID { get; set; }
        public String MerchantName { get; set; }
        public String UserName { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Description { get; set; }

        public String FirstNameBilling { get; set; }
        public String LastNameBilling { get; set; }
        public String EmailBilling { get; set; }
        public String PhoneNumberBilling { get; set; }
        public String Address { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String DescriptionBilling { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
