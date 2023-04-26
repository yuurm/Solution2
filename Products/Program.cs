using System;
using System.Collections.Generic;
using System.Linq;
using Products;


namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляров продукта
            Product product1 = new Product(15.99m, "Apple");
            Product product2 = new Product(12.49m, "Banana");
            Product product3 = new Product(9.99m, "Orange");
            Product product4 = new Product(5.99m, "Grapess");

            // Создаем экземпляры GroceryBasket
            GroceryBasket basket1 = new GroceryBasket();
            basket1.Products.Add(product1);
            basket1.Products.Add(product2);
            basket1.Products.Add(product3);

            GroceryBasket basket2 = new GroceryBasket();
            basket2.Products.Add(product2);
            basket2.Products.Add(product3);

            GroceryBasket basket3 = new GroceryBasket();
            basket3.Products.Add(product1);
            basket3.Products.Add(product4);
            basket3.Products.Add(product4);

            // Добавление продуктовых корзин в список
            List<GroceryBasket> groceryBaskets = new List<GroceryBasket>();
            groceryBaskets.Add(basket1);
            groceryBaskets.Add(basket2);
            groceryBaskets.Add(basket3);

            // Выполняем операции с использованием LINQ

            // Выберите корзины, в которых сумма всех продуктов больше 100
            var basketsWithTotalGreaterThan100 = groceryBaskets.Where(basket => basket.Products.Sum(product => product.Price) > 100);
            Console.WriteLine("Baskets with total greater than 100:");
            foreach (var basket in basketsWithTotalGreaterThan100)
            {
                Console.WriteLine($"Basket: {basket}");
            }

            // Выберите продукты, название которых длиннее 5 символов и цена которых больше 10
            var productsWithNameLongerThan5AndPriceMoreThan10 = groceryBaskets.SelectMany(basket => basket.Products)
                .Where(product => product.Title.Length > 5 && product.Price > 10);
            Console.WriteLine("Products with name longer than 5 characters and price more than 10:");
            foreach (var product in productsWithNameLongerThan5AndPriceMoreThan10)
            {
                Console.WriteLine($"Product: {product}");
            }
            

            // Выбераем корзины с более чем 4 товарами
            var basketsWithMoreThan4Products = groceryBaskets.Where(basket => basket.Products.Count > 4);
            Console.WriteLine("Baskets with more than 4 products:");
            foreach (var basket in basketsWithMoreThan4Products)
            {
                Console.WriteLine($"Basket: {basket}");
            }

            // Выбераем продукты во всех корзинах, цена которых варьируется от 10 до 100
            var productsWithPriceInRange10To100 = groceryBaskets.SelectMany(basket => basket.Products)
                .Where(product => product.Price >= 10 && product.Price <= 100);
            Console.WriteLine("Products with price in range 10 to 100:");
            foreach (var product in productsWithPriceInRange10To100)
            {
                Console.WriteLine($"Product: {product}");
            }

            // Выбераем продукт в каждой корзине с самой высокой ценой
            var productsWithHighestPriceInBasket = groceryBaskets.Select(basket => basket.Products.OrderByDescending(product => product.Price).FirstOrDefault());
            Console.WriteLine("Products with highest price in basket:");
            foreach (var product in productsWithHighestPriceInBasket)
            {
                Console.WriteLine($"Product: {product}");
            }
                
            
            
            // Вычисляем общее количество всех продуктов в каждой корзине
            var basketTotalProducts = groceryBaskets.Select(basket => new { Basket = basket, Total = basket.Products.Sum(product => product.Price) });

            Console.WriteLine("Basket total products:");
            foreach (var basketTotal in basketTotalProducts)
            {
                Console.WriteLine($"Basket: {basketTotal.Basket}, Total: {basketTotal.Total}");
            }
            
            // Суммируем общее количество всех продуктов во всех корзинах
            var totalOfAllProductsInAllBaskets = groceryBaskets.SelectMany(basket => basket.Products).Sum(product => product.Price);
            Console.WriteLine($"Total of all products in all baskets: {totalOfAllProductsInAllBaskets}");

            
        }
    }
    
}


    
    
    
