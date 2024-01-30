using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30 {
    internal class Product {
        private static uint _staticNo = 0;
        public readonly uint No;
        public string? Name;
        public double Price;
        public ProductType Type;

        public enum ProductType {
            Baker,
            Drink,
            Meat,
            Diary
        }

        public Product(string? name, double price, ProductType type)
            : this() { 
            Name = name;
            Price = price;
            Type = type;
        }
        public Product() {
            _staticNo++;
            No = _staticNo;
        }

        public override string? ToString() {
            return $"\nNo: {No}\nName: {Name}\nPrice: {Price}\nType: {Type}\n";
        }
    }
}
