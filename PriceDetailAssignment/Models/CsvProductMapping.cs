using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace PriceDetailAssignment.Models
{
    public class NullTypeConverter : BaseConverter<DateTime?>
    {
        private readonly ITypeConverter<DateTime?> converter;

        public NullTypeConverter()
            : this(new NullableDateTimeConverter())
        { }
        public NullTypeConverter(ITypeConverter<DateTime?> converter)
        {
            this.converter = converter;
        }
        public override bool TryConvert(string value, out DateTime? result)
        {
            result = default(DateTime?);

            if (string.Equals("NULL", value))
            {
                return true;
            }
            return converter.TryConvert(value, out result);
        }
    }

    //private class NullTypeConverter : BaseConverter<double?>
    //{
    //    private readonly ITypeConverter<double?> converter;

    //    public NullTypeConverter()
    //        : this(new NullableDoubleConverter())
    //    {
    //    }

    //    public NullTypeConverter(ITypeConverter<double?> converter)
    //    {
    //        this.converter = converter;
    //    }

    //    public override bool TryConvert(string value, out double? result)
    //    {
    //        result = default(double?);

    //        if (string.Equals("NULL", value))
    //        {
    //            return true;
    //        }

    //        return converter.TryConvert(value, out result);
    //    }
    //}

    public class CsvProductMapping : CsvMapping<Product>
    {
        public CsvProductMapping() : base()
        {
            MapProperty(0, x => x.PriceValuedId);
            MapProperty(1, x => x.Created);
            MapProperty(2, x => x.Modified);
            MapProperty(3, x => x.CatalogEntryCode);
            MapProperty(4, x => x.MarketId);
            MapProperty(5, x => x.CurrencyCode);
            MapProperty(6, x => x.ValidFrom);
            MapProperty(7, x => x.ValidUntil, new NullTypeConverter());
            MapProperty(8, x => x.UnitPrice);
        }      
    }
    //public class CsvProductMappingWithCustomConverter : CsvMapping<Product>
    //{
    //    public CsvProductMappingWithCustomConverter()
    //    {
    //        MapProperty(0, x => x.PriceValuedId);
    //        MapProperty(1, x => x.Created);
    //        MapProperty(2, x => x.Modified);
    //        MapProperty(3, x => x.CatalogEntryCode);
    //        MapProperty(4, x => x.MarketId);
    //        MapProperty(5, x => x.CurrencyCode);
    //        MapProperty(6, x => x.ValidFrom);
    //        CsvPropertyMapping<Product, DateTime?> CsvProductMapping = MapProperty(7, x => x.ValidUntil, new NullableDateTimeConverter());
    //        MapProperty(8, x => x.UnitPrice);
    //    }
    //}
}
