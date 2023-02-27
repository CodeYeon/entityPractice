using System;
using System.Collections.Generic;

namespace EntityPractice.Server.Models
{
    public partial class Category
    {
        public Category()
        {
            Menus = new HashSet<Menu>();
        }

        public int Idx { get; set; }
        public string? Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Color { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
