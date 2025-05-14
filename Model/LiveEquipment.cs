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

        public LiveEquipment(int itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus, EquipmentType type, string owner)
            : base(itemId, name, condition, approvalRequirement, storageStatus)
        {
            Type = type;
            Owner = owner;
        }

        public LiveEquipment(EquipmentType type, string owner)
            : base(itemId: 0, "", Condition.New, NeedsApproval.No, InWarehouse.Available)
        {
            Type = type;
            Owner = owner;
        }
    
    }

    public enum EquipmentType
    {
        Sword,
        Shield,
        Other
    }
}
