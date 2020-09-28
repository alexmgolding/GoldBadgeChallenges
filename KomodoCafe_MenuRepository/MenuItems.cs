using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_MenuRepository
{
    public class MenuItems
    {
        public int MenuNumber { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string MenuIngredients { get; set; }
        public decimal MenuPrice { get; set; } 

        public MenuItems() { }

        public MenuItems(int menuNumber, string menuName, string menuDescription, string menuIngredients, decimal menuPrice)
        {
            MenuNumber = menuNumber;
            MenuName = menuName;
            MenuDescription = menuDescription;
            MenuIngredients = menuIngredients;
            MenuPrice = menuPrice;
        }
    }
}
