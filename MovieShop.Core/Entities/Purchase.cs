﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Nullable<Guid> PurchaseNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDataTime { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
