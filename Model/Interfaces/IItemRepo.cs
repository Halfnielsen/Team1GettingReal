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

        public void EditItem(Item item);

        public void DeleteItem(Item item);

        public void GetById(int itemId);
        public List<Item> GetAllItems();
        public List<Loan> GetLoanHistory();
    }
}
