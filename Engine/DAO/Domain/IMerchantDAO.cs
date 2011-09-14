using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Domain.Object;

namespace Engine.DAO.Domain
{
   public interface IMerchantDAO
    {
       Merchant GetMerchant(Int64 ID);
       List<Merchant> GetAllActiveMerchants();
       bool UpdateMerchant(Merchant merchant);
       bool AddMerchant(Merchant merchant);
    }
}
