using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace GettingReal.Model
{
    public class Book : Item
    {
        public string System { get; set; }
        public string Edition { get; set; }

        public Book() : base() // We MIGHT not need an empty constuctor anylonger, since I figured out how to make the FromString work with a "filled out" constuctor :D
        {

        }

        public Book(string itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus, string system, string edition)
            : base(itemId, name, condition, approvalRequirement, storageStatus)
        {
            System = system;
            Edition = edition;
            
        }

        //Didn't we agree to remove this?
        //public Book(string author, string edition, string system)
        //: base(itemId: 0, "", Condition.New, NeedsApproval.No, InWarehouse.Available)
        //{
        //    Author = author;
        //    Edition = edition;
        //    System = system;
        //}
        public override string GetPrefix()
        {
            return "BO";
        }
        public override string ToString()
        {
            return $" Book,{ItemId},{Name},{Condition},{ApprovalRequirement},{StorageStatus},{System},{Edition}";
        }

        public override Item FromString(string input)
        {
            string[] parts = input.Split(',');

            return new Book(
                itemId: parts[0],
                name: parts[1],
                condition: Enum.Parse<Condition>(parts[2]),
                approvalRequirement: Enum.Parse<NeedsApproval>(parts[3]),
                storageStatus: Enum.Parse<InWarehouse>(parts[4]),
                system: parts[5],
                edition: parts[6]
            );
           
        }
    }

}
