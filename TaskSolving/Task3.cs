using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Разберитесь с инкапсуляцией
namespace TaskSolving
{
    class Bag
    {
        public List<Item> Items;
        public int MaxWeidth;

        public void AddItem(string name, int count)
        {
            int currentWeidth = Items.Sum(item => item.Count);
            Item targetItem = Items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
                throw new InvalidOperationException();

            if (currentWeidth + count > MaxWeidth)
                throw new InvalidOperationException();

            targetItem.Count += count;
        }
    }

    class Item
    {
        public int Count;
        public string Name;
    }
}
