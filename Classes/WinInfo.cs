using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIc_Tac_Toe_Game.Entitiws;

namespace TIc_Tac_Toe_Game.Classes
{
    // клас, який дає нам інформацію про виграш (як саме це сталося(тип) та якщо гравець закресив рядок чи стовбець зміна буде показувати який саме)
    //потрібно для того, щоб потім знати де провести"виграшну лінію"
    public class WinInfo
    {
        public WinType type { get; set; }
        public int number { get; set; }
    }
}
