using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Vairty
{
    public class Guarantee
    {
        [Key]
        public int GuaranteeId { get; set; }
        [MaxLength(40)]
        public string Title { get; set; }

        public List<Variant> Variants { get; set; }

    }
}
