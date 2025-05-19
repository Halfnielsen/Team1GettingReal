using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GettingReal.Model
{
    public class LiveEquipment : Item
    {
        public EquipmentType Type { get; set; }
        public string Owner { get; set; } 


        public LiveEquipment()
        {
        }

        public LiveEquipment(int? itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus, EquipmentType type, string owner)
            : base(itemId, name, condition, approvalRequirement, storageStatus)
        {
            Type = type;
            Owner = owner;
        }

        //Didn't we agree to remove this?
        //public LiveEquipment(EquipmentType type, string owner)
        //    : base(itemId: "0", "", Condition.Ny, NeedsApproval.Nej, InWarehouse.Udlånt)
        //{
        //    Type = type;
        //    Owner = owner;
        //}
       
        public override string ToString()
        {
            return $"{ItemId},{Name},{Condition},{ApprovalRequirement},{StorageStatus},{Type},{Owner}";
        }

        public override Item FromString(string input)
        {
            string[] parts = input.Split(',');

            return new LiveEquipment(
                itemId: Int32.Parse(parts[0]),
                name: parts[1],
                condition: Enum.Parse<Condition>(parts[2]),
                approvalRequirement: Enum.Parse<NeedsApproval>(parts[3]),
                storageStatus: Enum.Parse<InWarehouse>(parts[4]),
                type: Enum.Parse<EquipmentType>(parts[4]),
                owner: parts[5]
                
            );

        }
    }

    public enum EquipmentType // Took the ones from MVP :)
    {
        Lejr,
        Kostume,
        Våben,
        Pynt,
        Accessories, //Should this be "Tilbehør" instead? (I just took the exact name from the mvp
        Spisegrej
    }
}
