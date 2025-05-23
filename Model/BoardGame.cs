using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Model
{
    public class BoardGame : Item
    {
        public string Edition { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }

        public BoardGame() // We MIGHT not need an empty constuctor anylonger, since I figured out how to make the FromString work with a "filled out" constuctor :D
        {
        }   
        public BoardGame(int? itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus, string edition, int minPlayers, int maxPlayers)
            : base(itemId, name, condition, approvalRequirement, storageStatus)
        {
            Edition = edition;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

        //Didn't end up using this constructor

        //public BoardGame(string edition, int minPlayers, int maxPlayers)
        //    : base(itemId: 0, "", Condition.New, NeedsApproval.No, InWarehouse.Available)
        //{
        //    Edition = edition;
        //    MinPlayers = minPlayers;
        //    MaxPlayers = maxPlayers;
        //}

        public override string ToString()
        {
            return $"BoardGame,{ItemId},{Name},{Condition},{ApprovalRequirement},{StorageStatus},{Edition},{MinPlayers},{MaxPlayers}";
        }

        public override Item FromString(string input)
        {
            string[] parts = input.Split(',');

            return new BoardGame(
                itemId: Int32.Parse(parts[0]),
                name: parts[1],
                condition: Enum.Parse<Condition>(parts[2]),
                approvalRequirement: Enum.Parse<NeedsApproval>(parts[3]),
                storageStatus: Enum.Parse<InWarehouse>(parts[4]),
                edition: parts[5],
                minPlayers: int.Parse(parts[6]),
                maxPlayers: int.Parse(parts[7])
            );

        }
    }
}
