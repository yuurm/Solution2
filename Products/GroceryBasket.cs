using System.Collections.Generic;

namespace Products
{
    class GroceryBasket
    {
        public List<Product> Products { get; set; }
        
        public GroceryBasket()
        {
            
            Products = new List<Product>();
        }
    }
}