using System;
using System.Collections.Generic;

namespace EntityPractice.Server.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Idx { get; set; }
        public decimal? Total { get; set; }
        public bool? IsDone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
