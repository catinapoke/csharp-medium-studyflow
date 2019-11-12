using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSolving
{
    class ShopItem 
    {
        private string _name;
        private int _cost;
        private int _level;

        public string Name { get => _name; }
        public int Cost { get => _cost; }
        public int Level { get => _level; }

        ShopItem(string name, int cost = 0, int level = 0)
        {
            _name = name;
            _cost = cost;
            _level = level;
        }
    }

    class ShopItemList: List<ShopItem>
    {
        private int CompareNames(ShopItem item1, ShopItem item2)
        {
            if (item1.Name == null)
            {
                if (item2.Name == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (item2.Name == null)
                {
                    return 1;
                }
                else
                {
                    int retval = item1.Name.Length.CompareTo(item2.Name.Length);

                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return item1.Name.CompareTo(item2.Name);
                    }
                }
            }
        }

        void SortByName()
        {
            this.Sort(CompareNames);
        }

        void SortByCost()
        {
            this.Sort((ShopItem item1, ShopItem item2) => { return ((item1.Cost > item2.Cost) ? 1 : (item1.Cost == item2.Cost ? 0 : -1)); });
        }

        void SortByLevel()
        {
            this.Sort((ShopItem item1, ShopItem item2) => { return ((item1.Level > item2.Level) ? 1 : (item1.Level == item2.Level ? 0 : -1)); });
        }
    }
}
