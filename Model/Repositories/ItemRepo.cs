//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using GettingReal.Model.Interfaces;

//namespace GettingReal.Model.Repositories
//{
//    internal class ItemRepo : IItemRepo
//    {
//        private string _filePath;
//        public ItemRepo(string filePath)
//        {
//            _filePath = filePath;
//        }

//        private List<Item> GetAllItems = new List<Item>();
//        private List<Loan> GetLoanHistory = new List<Loan>();

//        public void AddItem(Item item)
//        {
//            // Add item
//            //Console.WriteLine("Skriv id: ");
//            //string itemId = Console.ReadLine();
//            //Console.WriteLine("Skriv navn: ");
//            //string name = Console.ReadLine();
//            //Console.WriteLine("Skriv tilstand: ");
//            //string condition = Console.ReadLine();

//            //GetAllItems.Add(new Item
//            //{
//            //    itemId = int.Parse(itemId),
//            //    name = name,
//            //    condition = condition,
//            //    needsApproval = false,
//            //    inWarehouse = true,
//            //    loan = null
//            //});
//            //Console.WriteLine($"Item {itemId} added with name {name} and condition {condition}");


//        }
//        public void EditItem(Item item)
//        {/*
//            // Edit item
//            var existingItem = GetAllItems.FirstOrDefault(i => i.itemId == item.itemId);
//            if (existingItem != null)
//            {
//                existingItem.itemId = item.itemId;
//                existingItem.name = item.name;
//                existingItem.condition = item.condition;
//                existingItem.needsApproval = item.needsApproval;
//                existingItem.inWarehouse = item.inWarehouse;
//                existingItem.loan = item.loan;
//            }
//            */
//        }
//        public void DeleteItem(Item item)
//        {
//            // Remove item

//        }
//        public void GetById(int itemId)
//        {
//            /*
//            // Get item by id
//            itemId = GetAllItems.FirstOrDefault(i => i.itemId == item.itemId);
//            if (itemId != null)
//            {
//                // Do something with the item
//            }
//            */
//        }

//        List<Item> IItemRepo.GetAllItems()
//        {
//            throw new NotImplementedException();
//        }

//        List<Loan> IItemRepo.GetLoanHistory()
//        {
//            throw new NotImplementedException();
//        }
//    }
    
//}
