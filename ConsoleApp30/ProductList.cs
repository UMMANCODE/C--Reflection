using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30 {
    internal class ProductList {
        public Product[] products = {
            new(), new("product", 10, Product.ProductType.Baker), new(), new(), new()
        };

        public Product this[int index] {
            get => products[index];
            set {
                if (CheckValue(value))
                    products[index] = value;
            }
        }

        private bool CheckValue(Product pdt) {
            foreach (Product product in products) {
                if (product == null) {
                    return false;
                }

                if (product.No == pdt.No) {
                    return false;
                }
            }
            return true;
        }
    }
}
