using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_MenuRepository
{
    public class MenuItemsRepository
    {
        private List<MenuItems> _listofMenuItems = new List<MenuItems>();

        // Create
        public void AddMenuItemToList(MenuItems item)
        {
            _listofMenuItems.Add(item);
        }

        // Read
        public List<MenuItems> GetMenuItemsList()
        {
            return _listofMenuItems;
        }

        // Update
        public bool UpdateExistingMenuItem(string originalMenuName, MenuItems newItem)
        {
            // Find The Item
            MenuItems oldItem = GetMenuItems(originalMenuName);
            
            // Update The Item
            if(oldItem != null)
            {
                oldItem.MenuName = newItem.MenuName;
                oldItem.MenuNumber = newItem.MenuNumber;
                oldItem.MenuDescription = newItem.MenuDescription;
                oldItem.MenuIngredients = newItem.MenuIngredients;
                oldItem.MenuPrice = newItem.MenuPrice;
                
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveItemFromList(string menuName)
        {
            MenuItems item = GetMenuItems(menuName);

            if(item == null)
            {
                return false;
            }

            int initialCount = _listofMenuItems.Count;
            _listofMenuItems.Remove(item);

            if(initialCount > _listofMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        // Helper Method
        public MenuItems GetMenuItems(string menuName)
        {
            foreach(MenuItems item in _listofMenuItems)
            {
                if(item.MenuName.ToLower() == menuName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }

    }
}
