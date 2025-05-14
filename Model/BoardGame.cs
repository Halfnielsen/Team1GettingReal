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

        public BoardGame()
        {
        }   
        public BoardGame(int itemId, string name, Condition condition, NeedsApproval approvalRequirement, InWarehouse storageStatus, string edition, int minPlayers, int maxPlayers)
            : base(itemId, name, condition, approvalRequirement, storageStatus)
        {
            Edition = edition;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }
        public BoardGame(string edition, int minPlayers, int maxPlayers)
            : base(itemId: 0, "", Condition.New, NeedsApproval.No, InWarehouse.Available)
        {
            Edition = edition;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }
        
    }
}
