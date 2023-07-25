using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIc_Tac_Toe_Game.Entitiws;

namespace TIc_Tac_Toe_Game.Classes
{
    //клас, який показує як закінчилася гра(який гравець виграв та як)
    public class GameResult
    {
        public Player winner { get; set; }
        public WinInfo winInfo { get; set; }
    }
}
