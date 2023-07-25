using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIc_Tac_Toe_Game.Classes;
using TIc_Tac_Toe_Game.Entitiws;

namespace TIc_Tac_Toe_Game.GameLogic
{
    public class GameState
    {
        //створюємо наше поле для гри,теперішнього гравця, скільки разів вже було зроблено якийсь рух та зміну, яка показує чи закінчена гра
        public Player[,] gameGrid { get; set; }
        public Player currentPlayer { get; set; }
        public int turnCheck { get; set; }
        public bool gameOver { get; set; }

        //події, для руху який робиться (приймає рядок і стовпець), коли гра закінчилася, починається нова гра
        public event Action<int, int> OnMoveMade;
        public event Action<GameResult> OnGameOver;
        public event Action OnNewGame;

        //конструктор, який ініціалізує початкові змінні
        public GameState()
        {
            gameGrid = new Player[3, 3];
            currentPlayer = Player.O;
            turnCheck = 0;
            gameOver = false;
        }

        //helpers method
        //перевіряж чи може гравець поставити свій знак на цьому квадратику, і відповідно якщо гра не закінчена та квадратик не зайнятий іншим гравцем, поверне true
        private bool PlayerCanMakeMove(int r, int c)
        {
           /* if (!gameOver && gameGrid[r, c] == Player.None)
            {
                return true;
            }

            return false;*/

            return !gameOver && gameGrid[r, c] == Player.None;
        }

    }
}
