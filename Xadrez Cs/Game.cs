using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_Cs
{
    internal class Game
    {
        public Piece[,] Pos = new Piece[8, 8];
        public bool BlackTurn = false;
        public Game() {
            Pos[0, 0] = new Rook(0,0,true);
            Pos[0, 1] = new Knight(0,1, true);
            Pos[0, 2] = new Bishop(0,2, true);
            Pos[0, 3] = new King(0,3, true);
            Pos[0, 4] = new Queen(0,4, true);
            Pos[0, 5] = new Bishop(0,5, true);
            Pos[0, 6] = new Knight(0,6, true); 
            Pos[0, 7] = new Rook(0,7, true);
            for (int i = 0; i < 8; i++)
            {
                Pos[1, i] = new Pawn(1,i, true);
                Pos[6, i] = new Pawn(6,i, false);
            }
            Pos[7, 0] = new Rook(7,0, false);
            Pos[7, 1] = new Knight(7,1, false);
            Pos[7, 2] = new Bishop(7,2, false);
            Pos[7, 3] = new King(7,3, false);
            Pos[7, 4] = new Queen(7,4, false);
            Pos[7, 5] = new Bishop(7,5, false);
            Pos[7, 6] = new Knight(7,6, false);
            Pos[7, 7] = new Rook(7,7, false);
        }


    }
}
