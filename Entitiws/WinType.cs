using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIc_Tac_Toe_Game.Entitiws
{
    //перерахування для 3 видів виграшу, який буваєі
    public enum WinType
    {
        Row,
        Column,
        MainDiagonal,
        AntiDIagonal
    }
}
