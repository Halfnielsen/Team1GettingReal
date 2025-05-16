using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Model.Interfaces
{
    internal interface IItemRepo
    {
        public void AddItem(Item item);

        public void EditItem(Item editItem);

        public void DeleteItem(Item item);

        //Ændrede void til return item.
        public Item GetById(string itemId);
        public List<Item> GetAllItems();

        //Ændrede parameter til item
        public List<Loan> GetLoanHistory(Item item);
    }
}
