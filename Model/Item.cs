using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GettingReal.Model.Repositories;
using Microsoft.VisualBasic.FileIO;

namespace GettingReal.Model
{
    public abstract class Item
    {
        public string ItemId { get; protected set; } // I made item into a string, enabling it to contain letters.
        public string Name { get; set; }
        public Condition Condition { get; set; }
        public NeedsApproval ApprovalRequirement { get; set; }
        public InWarehouse StorageStatus { get; set; }

        //For Id Generation:
        private static Random _random = new Random();
        private static HashSet<string> usedItemIds = new HashSet<string>(); 



        public List<Loan> Loan { get; set; } = new();

        public Item(string itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus)
        {
            ItemId = itemId ?? GenerateUniqueId(); //this gives the item an Id when we make it or just reads it from the file.
            Name = name;
            Condition = condition;
            ApprovalRequirement = approvalRequirement;
            StorageStatus = storageStatus;
        }

        public Item() // We MIGHT not need an empty constuctor anylonger, since I figured out how to make the FromString work with a "filled out" constuctor :D
        {
        }



        // For Generating ItemId:
        public abstract string GetPrefix(); //To generate prefix. Forces the sub-classes to fill out custom prefix.

        public string GenerateUniqueId() // Generating random Id with prefix that is defined in the individual sub-classes :o) 
        {
            string prefix = GetPrefix();
            string id;

            do
            {
                int number = _random.Next(1000, 9999); //I think a 4 digit number after the prefix should be sufficient, but if not, we can always change it to: 10000, 99999
                id = prefix + number.ToString();
            } while (usedItemIds.Contains(id));

            usedItemIds.Add(id);
            return id;
        }

        // For fileRepo
        public abstract string ToString();

        public static Item FromDataString(string data)
        {
            var parts = data.Split(',');
            var type = parts[0];  // e.g. "BoardGame"
            var rest = string.Join(",", parts.Skip(1)); // rest of the line without type

            return type switch
            {
                "BoardGame" => new BoardGame().FromString(rest),
                "LiveEquipment" => new LiveEquipment().FromString(rest),
                "Book" => new Book().FromString(rest),
                _ => throw new ArgumentException($"Unknown item type: {type}")
            };
        }
        public abstract Item FromString(string input);
    }
    
    //ændre til dansk enum

    public enum Condition
    {
       Ny,
       God,
       Brugt,
       Ødelagt
    }

    public enum NeedsApproval
    {
        Ja,
        Nej
    }

    public enum InWarehouse
    {
        Hjemme,
        Udlånt
       
    }
}
