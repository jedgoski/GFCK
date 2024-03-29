﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Domain.Object;

namespace Engine.DAO.Domain
{
    public interface ICouponDAO
    {
        List<CouponPrint> GetCouponPrintsForCouponID(Int64 couponID);
        bool AddCouponPrint(CouponPrint couponPrint);
        bool UpdateCoupon(Coupon coupon);
        List<Coupon> GetAllCouponsForMerchantID(Int64 ID);
        List<Coupon> GetAllCouponsByCategory(int categoryID, string filter, string ipAddress);
        List<Coupon> GetAllCouponsByCategory(int categoryID, string filter, string searchText, string ipAddress);
        Coupon GetCoupon(Int64 ID);
        int AddCoupon(Coupon coupon);
        List<CouponPrint> GetCouponPrintsByMerchantID(Int64 merchantID, DateTime startDate, DateTime endDate);

    }
}
