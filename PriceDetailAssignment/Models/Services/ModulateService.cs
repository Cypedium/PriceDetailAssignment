using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models.Services
{
    public class ModulateService
    {
        public static List<Product> CatalogEntryCodes(List<Product> catalogEntryCodes, string market_Id, string currency_Code)
        {
            if (string.IsNullOrEmpty(catalogEntryCodes.ToString()))
                {
                    return catalogEntryCodes;
                }
            
            catalogEntryCodes.Sort(delegate (Product x, Product y)
                    {
                        if (x.PriceValuedId == 0 && y.PriceValuedId == 0) return 0;
                        else if (x.PriceValuedId == 0) return -1;
                        else if (y.PriceValuedId == 0) return 1;
                        else return x.PriceValuedId.CompareTo(y.PriceValuedId);
                    });

            List<Product> catalogEntryCodes_Market_sv = new List<Product>();
            catalogEntryCodes_Market_sv = catalogEntryCodes.Where(x => x.MarketId == market_Id && x.CurrencyCode == currency_Code).ToList();

            int array_Length = catalogEntryCodes_Market_sv.Count();

            Product[] array = new Product[array_Length];
            array = catalogEntryCodes_Market_sv.ToArray();
            
            if (array.Length != 1)
            {
                for (int i = 0; i<array.Length - 1; i++) //shifting values
                {
                    DateTime dateTime_true = (DateTime)array[0].ValidUntil; 
                
                    if (array[i].PriceValuedId != 0 || i< 3)
                    {
                        if (array[i].ValidUntil == null || array[i].ValidUntil == dateTime_true)
                        {
                            array[i].ValidUntil = array[i + 1].ValidFrom;
                        }
                        else if (array[i].ValidUntil > array[i + 1].ValidFrom)
                        {
                            array[i].ValidUntil = array[i + 1].ValidFrom;
                        }
                    }
                }

                //Add new Product row(s) if neccessery-----------------------------------------------------------------
                for (int x = 0; x<array.Length -1; x++)
                {
                
                    if (array[x].ValidUntil != array[x + 1].ValidFrom)
                    {
                        Product newProduct_Row = new Product()
                        {
                            PriceValuedId = 0, //Need to change value to my ghoost
                            Created = array[x].Created,
                            Modified = array[x].Modified,
                            CatalogEntryCode = array[x].CatalogEntryCode,
                            MarketId = array[x].MarketId,
                            CurrencyCode = array[x].CurrencyCode,
                            ValidFrom = array[x].ValidFrom, //Gets the right value from this x product in array
                            ValidUntil = array[x].ValidUntil,
                            UnitPrice = array[x].UnitPrice
                        };

                        List<Product> arrayList = new List<Product>();
                        arrayList = array.ToList(); // Convert array to List to add product

                        arrayList.Add(newProduct_Row);
                        array = arrayList.ToArray(); // Convert back

                        array.Last().UnitPrice = array.First().UnitPrice;
                        array.Last().ValidFrom = array[x].ValidUntil; //Gets the right value from the last product in list
                        array.Last().ValidUntil = array[x + 1].ValidFrom; //Gets the right value from next x product in list

                        break;
                    }
                }
                //Added new Product row(s)-----------------------------------------------------------------------------------

                //Sort the Current List by DateTime ValidFrom
                List<Product> finishedList = new List<Product>();
                finishedList = array.ToList();

                finishedList.Sort(delegate (Product a, Product b)
                {
                    if (a.ValidFrom == null && b.ValidFrom == null) return 0;
                    else if (a.ValidFrom == null) return -1;
                    else if (b.ValidFrom == null) return 1;
                    else
                    {
                        return DateTime.Compare((DateTime) a.ValidFrom, (DateTime) b.ValidFrom);
                    }
                });
                //Sort finished----------------------------------------------------------------------------------------------
            
                array = finishedList.ToArray();

                //Add Last Product Row----------------------------------------------------------------------------------------
                for (int y = 0; y<array.Length; y++) 
                {

                    if (array[y] == array.Last())
                    {
                        Product newProduct_Row = new Product()
                        {
                            PriceValuedId = 0, //Need to change value to my ghoost
                            Created = array[y].Created,
                            Modified = array[y].Modified,
                            CatalogEntryCode = array[y].CatalogEntryCode,
                            MarketId = array[y].MarketId,
                            CurrencyCode = array[y].CurrencyCode,
                            ValidFrom = array[y].ValidFrom, //Gets the right value from this x product in array
                            ValidUntil = array[y].ValidUntil,
                            UnitPrice = array[y].UnitPrice
                        };

                        List<Product> arrayList = new List<Product>();
                        arrayList = array.ToList(); // Convert array to List to add product

                        arrayList.Add(newProduct_Row);
                        array = arrayList.ToArray(); // Convert back

                        array.Last().UnitPrice = array.First().UnitPrice;
                        array.Last().ValidFrom = array[y].ValidUntil; //Gets the right value from the last product in list
                        array.Last().ValidUntil = null; //Gets the right value from next x product in list

                        break;
                    }
                }
                //Added Last Product Row-----------------------------------------------------------------------------------------
            }
            else
            {
                array.Last().ValidUntil = null; 
            }

            List<Product> finishedList_After_LastProductRow = new List<Product>();
            finishedList_After_LastProductRow = array.ToList();
            return finishedList_After_LastProductRow;
        }
    }
}
        
