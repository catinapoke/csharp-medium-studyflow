using System;
using System.Collections.Generic;
using System.Linq;

//2. Поиск
//Создайте класс Product в котором укажите поля: цена, id, имя, количество.Создайте List
//“Products” в который поместите пару тестовых продуктов.Воспользуйтесь методом Where для
//поиска продуктов у которых цена меньше 100 и количество больше 5
//https://msdn.microsoft.com/ru-ru/library/x0b5b5bc(v=vs.110).aspx

namespace TaskSolving
{
    internal class Product
    {
        private int _id;
        private string _name;
        private int _cost;
        private int _count;

        public int Id { get => _id; }
        public string Name { get => _name; }
        public int Cost { get => _cost; }
        public int Count { get => _count; }

        public Product(int id, string name, int cost = 0, int count = 0)
        {
            _id = id;
            _name = name;
            _cost = cost;
            _count = count;
        }

        public override string ToString()
        {
            return base.ToString() + ": " + String.Format("Id: {0}, Name: {1}, Cost: {2}, Count: {3}", _id, _name, _cost, _count);
        }
    }

    internal class Day3Task2
    {
        public static void SolveTask()
        {
            List<Product> products = new List<Product>();
            Random rand = new Random();

            for (int i = 0; i < 25; i++)
            {
                products.Add(new Product(i, String.Format("item #{0}", i), rand.Next(-200, 200), rand.Next(0, 15)));
            }

            IEnumerable<Product> selectedProducts = products.Where((Product product) => { return product.Cost < 100 && product.Count > 5; });

            foreach (Product p in selectedProducts)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}