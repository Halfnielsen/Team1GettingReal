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

        public Book(int? itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus, string system, string edition)
            : base(itemId, name, condition, approvalRequirement, storageStatus)
        {
            System = system;
            Edition = edition; //Er ikke helt sikker på om der mangler noget i forhold til OM
            
        }

        //Didn't end up using this constructor

        //public Book(string author, string edition, string system)
        //: base(itemId: 0, "", Condition.New, NeedsApproval.No, InWarehouse.Available)
        //{
        //    Author = author;
        //    Edition = edition;
        //    System = system;
        //}

        public override string ToString()
        {
            return $"Book,{ItemId},{Name},{Condition},{ApprovalRequirement},{StorageStatus},{System},{Edition}";
        }

        public override Item FromString(string input)
        {
            string[] parts = input.Split(',');

            return new Book(
                itemId: Int32.Parse(parts[0]),
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
