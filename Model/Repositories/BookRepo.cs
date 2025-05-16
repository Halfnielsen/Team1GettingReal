using GettingReal.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Model.Repositories
{
    class BookRepo : IItemRepo
    {
        private readonly List<Book> books = new List<Book>();
        public void AddItem(Item book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            
            books.Add((Book)book);
        }

        public void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void EditItem(Item item)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Item GetById(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<Loan> GetLoanHistory(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
