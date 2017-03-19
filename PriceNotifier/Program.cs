using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace PriceNotifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var active = true;
            do
            {
                Console.Write("Enter filepath: ");
                var input = Console.ReadLine();

                // if (Int64.TryParse(input, out long upc) && input.Length == 12)
                if(File.Exists(input))
                {
                    var csv = new CsvReader(File.OpenText(input));
                    var prods = csv.GetRecords<Product>();
                    // var prod = new GoogleShoppingScraper(input).GetProductInformation();
                    // Console.WriteLine($"{prod.Upc} | {prod.Name} | {prod.Price}");

                    Console.WriteLine("UPC: YOUR PRICE >= TOP GOOGLE PRICE");
                    foreach (var prod in prods)
                    {
                        var topProduct = new GoogleShoppingScraper(prod.Upc).GetProductInformation();
                        if (topProduct.Price <= prod.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{prod.Upc}: ${prod.Price} >= ${topProduct.Price}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{prod.Upc}: ${prod.Price} <= ${topProduct.Price}");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"INVALID FILEPATH: '{input}'");
                }

            } while (active);
        }
    }
}
