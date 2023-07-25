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

        private bool IsGridFull()
        {
            return turnCheck == 9;
        }

        private void SwitchPlayer()
        {
            /*if (currentPlayer == Player.X)
            {
                currentPlayer = Player.O;
            }
            else
            {
                currentPlayer = Player.X;
            }*/

            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
        }

        private bool AreSquaresMarked((int, int)[] squares, Player player)
        {
            foreach ((int r, int c) in squares) 
            {
                if (gameGrid[r, c] != player)
                {
                    return false;
                } 
            }

            return true;
        }

        private bool DidMoveWin(int r, int c, out WinInfo winInfo)
        {
            (int, int)[] row = new[] { (r, 0), (r, 1), (r, 2) };
            (int, int)[] col = new[] { (0, c), (1, c), (2, c) };
            (int, int)[] mainDiag = new[] { (0, 0), (1, 1), (2, 2) };
            (int, int)[] antiDiag = new[] { (0, 2), (1, 1), (2, 0) };

            if (AreSquaresMarked(row, currentPlayer))
            {
                winInfo = new WinInfo { type = WinType.Row, number = r };
                return true;
            }
            else if (AreSquaresMarked(col, currentPlayer))
            {
                winInfo = new WinInfo { type = WinType.Column, number = c };
                return true;
            }
            else if (AreSquaresMarked(mainDiag, currentPlayer))
            {
                winInfo = new WinInfo { type = WinType.MainDiagonal};
                return true;
            }
            else if (AreSquaresMarked(antiDiag, currentPlayer))
            {
                winInfo = new WinInfo { type = WinType.AntiDIagonal };
                return true;
            }

            winInfo = null;
            return false;
        }

        private bool DidMoveEndGame(int r, int c, out GameResult gameResult)
        {
            if (DidMoveWin(r, c, out WinInfo winInfo))
            {
                gameResult = new GameResult { winner = currentPlayer, winInfo = winInfo };
                return true;
            }

            if (IsGridFull())
            {
                gameResult = new GameResult { winner = Player.None };
                return true;
            }

            gameResult = null;
            return false;
        }

        //тепер "збираємо" всі наші хелперс методи до купи, щоб зробитит рух
        public void MakeMove(int r, int c)
        {
            if (!PlayerCanMakeMove(r, c))
            {
                return;
            }

            gameGrid[r, c] = currentPlayer;
            turnCheck++;

            if(DidMoveEndGame(r, c, out GameResult gameResult))
            {
                gameOver = true;
                OnMoveMade?.Invoke(r, c);
                OnGameOver?.Invoke(gameResult);
            }
            else
            {
                SwitchPlayer();
                OnMoveMade?.Invoke(r, c);
            }
        }

        public void Reset()
        {
            gameGrid = new Player[3, 3];
            currentPlayer = Player.O;
            turnCheck = 0;
            gameOver = false;
            OnNewGame?.Invoke();
        }
    }
}
