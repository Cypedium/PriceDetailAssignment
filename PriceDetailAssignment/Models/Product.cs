using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models
{
    public class Product
    {
        [Key]
        public int PriceValuedId { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        [Required]
        [Column(TypeName="nvarchar(20)")]
        public string CatalogEntryCode {get; set;}
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string MarketId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string CurrencyCode { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        public DateTime ValidUntil { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
