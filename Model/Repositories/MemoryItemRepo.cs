using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal.Model.Interfaces;

namespace GettingReal.Model.Repositories
{
    public class MemoryItemRepo : IItemRepo
    {
        //Memory list for items
        public List<Item> items = new List<Item>();

        //Add item to list
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        //Remove item from list
        public void DeleteItem(Item item)
        {
            items.Remove(item);
        }

        //Update item on matching ID
        public void EditItem(Item editItem)
        {
            foreach(Item item in items)
            {
                if(item.ItemId == editItem.ItemId)
                {
                    //Generic Properties
                    item.Name = editItem.Name;
                    item.Condition = editItem.Condition;
                    item.ApprovalRequirement = editItem.ApprovalRequirement;
                    item.StorageStatus = editItem.StorageStatus;

                    //Book
                    if(item is Book book && editItem is Book editBook)
                    {
                        book.Edition = editBook.Edition;
                        book.System = editBook.System;
                    }
                    //BoardGame
                    else if(item is BoardGame game && editItem is BoardGame editGame)
                    {
                        game.Edition = editGame.Edition;
                        game.MinPlayers = editGame.MinPlayers;
                        game.MaxPlayers = editGame.MaxPlayers;
                    }
                    //LiveEquipment
                    else if(item is LiveEquipment equipment && editItem is LiveEquipment editEquipment)
                    {
                        //Skulle vi kalde den noget andet end type? Husk at ændre her hvis det er :)
                        equipment.Type = editEquipment.Type;
                        equipment.Owner = editEquipment.Owner;
                    }
                    return;
                }
            }

            throw new Exception("Genstand ikke fundet");
        }

        //Return item list
        public List<Item> GetAllItems()
        {
            return items;
        }

        //Get item by ID
        public Item GetById(string itemId) //I changed int to string here :)
        {
            foreach(Item item in items)
            {
                if(itemId == item.ItemId)
                {
                    return item;
                }
            }
            throw new Exception("Ingen genstande fundet med det ID");
        }

        //Return item loan list
        public List<Loan> GetLoanHistory(Item item)
        {
            return item.Loan;
        }
    }
}
