using System;
using System.Collections.Generic;

namespace EntityPractice.Server.Models
{
    public partial class OrderItem
    {
        public int Idx { get; set; }
        public int? OrderId { get; set; }
        public int? MenuId { get; set; }
        public int? Qty { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Menu? Menu { get; set; }
        public virtual Order? Order { get; set; }
    }
}
