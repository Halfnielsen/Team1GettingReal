using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal.Model.Interfaces;
using System.IO;
using GettingReal.Model;
using System.Linq;

namespace GettingReal.Model.Repositories
{
    internal class FileItemRepo : IItemRepo
    {
        

        private readonly string _filePath;

        public FileItemRepo(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public void AddItem(Item item)
        {
            List<Item> items = GetAllItems().ToList();
            items.Add(item);
            try
            {
                File.AppendAllText(_filePath, item.ToString() + Environment.NewLine);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Fejl ved skrivning til fil: {ex.Message}");
            }
        }

        public void DeleteItem(Item item)
        {
            List<Item> items = GetAllItems().ToList();
            items.RemoveAll(p => p.ItemId == item.ItemId);
            EditItem(item);
        }

        public void EditItem(Item editItem)
        {
            List<Item> items = GetAllItems().ToList();
            try
            {
                File.WriteAllLines(_filePath, items.Select(p => p.ToString()));
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Fejl ved skrivning til fil: {ex.Message}");
            }
        }

        public List<Item> GetAllItems()
        {
            try
            {
                return File.ReadAllLines(_filePath)
                           .Where(line => !string.IsNullOrEmpty(line)) // Undgå tomme linjer
                           .Select(Item.FromDataString)
                           .ToList();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Fejl ved læsning af fil: {ex.Message}");
                return new List<Item>();
            }
        }

        public Item GetById(string itemId)
        {
            return GetAllItems().FirstOrDefault(p => p.ItemId == itemId);
        }

        public List<Loan> GetLoanHistory(Item item)
        {
            throw new NotImplementedException(); //I wasn't quite sure what to do here :o) Loan History isn't in our MVP so Im keeping it blank for now.
        }
    }
}
