using System;
using System.Collections.Generic;

namespace EntityPractice.Server.Models
{
    public partial class Menu
    {
        public Menu()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Idx { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryIdx { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Category? CategoryIdxNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
