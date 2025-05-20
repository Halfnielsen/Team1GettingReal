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
/*
        public MemoryItemRepo()
        {
            //Redigere evt. ID, når IdGenerator er klar. :)
            //Sample Book 1
            Book book1 = new Book(1234, "Dune", Condition.Used, NeedsApproval.Yes, InWarehouse.Available, "Frank Herbert", "1st","Literature");
            items.Add(book1);

            //Sample Book 2
            Book book2 = new Book(42069, "Players Handbook", Condition.New, NeedsApproval.Yes, InWarehouse.Available, "WoTC", "5th", "DnD");
            items.Add(book2);

            //Sample Game 1
            BoardGame game1 = new BoardGame(666, "Betrayal At House On The Hill", Condition.Bad, NeedsApproval.Yes, InWarehouse.NotAvailable, "4th", 2, 8);
            items.Add(game1);

            //Sample Game 2
            BoardGame game2 = new BoardGame(999, "Coup", Condition.Used, NeedsApproval.No, InWarehouse.Available, "2nd", 3, 6);
            items.Add(game2);

            //Sample Equipment 1
            LiveEquipment equipment1 = new LiveEquipment(360, "Chain Mail", Condition.Used, NeedsApproval.Yes, InWarehouse.NotAvailable, EquipmentType.Other, "FiR");
            items.Add(equipment1);

            //Sample Equipment 2
            LiveEquipment equipment2 = new LiveEquipment(920, "Gladius", Condition.New, NeedsApproval.Yes, InWarehouse.Available, EquipmentType.Sword, "Non-FiR");
            items.Add(equipment2);
        }
*/
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
        public Item GetById(int itemId) //I changed int to string here :)
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
