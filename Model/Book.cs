using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GettingReal.Model
{
    public class Book : Item
    {
        public string Author { get; set; }
        public string Edition { get; set; }
        public string System { get; set; }

        public Book() : base()
        {

        }

        public Book(int itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus, string author, string edition, string system)
            : base(itemId, name, condition, approvalRequirement, storageStatus)
        {
            Author = author;
            Edition = edition;
            System = system;
        }

        public Book(string author, string edition, string system)
        : base(itemId: 0, "", Condition.New, NeedsApproval.No, InWarehouse.Available)
        {
            Author = author;
            Edition = edition;
            System = system;
        }


    }

}
