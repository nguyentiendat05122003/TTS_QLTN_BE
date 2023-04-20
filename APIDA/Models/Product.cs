using System;
using System.Collections.Generic;

namespace APIPCHY.Models
{

    public partial class Product
    {
        public string ProductId { get; set; } = null!;

        public string? ProductName { get; set; }

        public int? CategoryId { get; set; }

        public string? Picture { get; set; }

        public double? Price { get; set; }

        public string? Note { get; set; }

        public virtual Category? Category { get; set; }
    }

}


