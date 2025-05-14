using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal.Model.Repositories;

namespace GettingReal.Model
{
    public abstract class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public Condition Condition { get; set; }
        public NeedsApproval ApprovalRequirement { get; set; }
        public InWarehouse StorageStatus { get; set; }
        
              
        
        public List<Loan> Loan { get; set; } = new();

        public Item(int itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus)
        { 
            ItemId = itemId;
        }

        public Item()
        {
        }


    }
    
    //ændre til dansk enum

    public enum Condition
    {
        New,
        Used,
        Bad
    }

    public enum NeedsApproval
    {
        Yes,
        No
    }

    public enum InWarehouse
    {
        Available,
        NotAvailable
    }
}
