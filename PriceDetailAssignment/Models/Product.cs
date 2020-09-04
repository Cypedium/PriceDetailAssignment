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
       
        public DateTime Created { get; set; }
        
        public DateTime Modified { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string CatalogEntryCode {get; set;}
        
        [Column(TypeName = "nvarchar(5)")]
        public string MarketId { get; set; }
        
        [Column(TypeName = "nvarchar(5)")]
        public string CurrencyCode { get; set; }
        
        public DateTime ValidFrom { get; set; }
        
        public DateTime ValidUntil { get; set; }

        //[Column(TypeName = "decimal")]
        public decimal UnitPrice { get; set; }
    }
}
