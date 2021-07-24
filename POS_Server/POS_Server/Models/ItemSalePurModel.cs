﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class ItemSalePurModel
    {
        public int? itemId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public string type { get; set; }
        public string image { get; set; }
        public Nullable<decimal> taxes { get; set; }
        public Nullable<byte> isActive { get; set; }
        public Nullable<int> min { get; set; }
        public Nullable<int> max { get; set; }
        public Nullable<int> categoryId { get; set; }
        public string categoryName { get; set; }
        public Nullable<int> parentId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> minUnitId { get; set; }
        public Nullable<int> maxUnitId { get; set; }
        public Boolean canDelete { get; set; }


        // offer item
        public Nullable<decimal> desPrice { get; set; }
        public Nullable<int> isNew { get; set; }
        public Nullable<int> isOffer { get; set; }
        // unit item
        public Nullable<decimal> price { get; set; }
        public Nullable<int> unitId { get; set; }
        public string unitName { get; set; }
        public string offerName { get; set; }
        public Nullable<int> offerId { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public byte? isActiveOffer { get; set; }
        public Nullable<int> itemUnitId { get; set; }
        public Nullable<short> defaultSale { get; set; }
        public string discountType { get; set; }
        public Nullable<decimal> discountValue { get; set; }
        public Nullable<decimal> priceTax { get; set; }
        public Nullable<short> defaultPurchase { get; set; }

        public string parentName { get; set; }
        public string minUnitName { get; set; }
        public string maxUnitName { get; set; }
    }
}