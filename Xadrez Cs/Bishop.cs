using System;
using System.Drawing;

namespace Chess_Cs
{
    public class Bishop : Piece
    {
        public Bishop(int x, int y, bool black) : base(x, y, black)
        {
            
            if (black)
            {
                img = Image.FromFile("BBishop.png");
                name = "BBishop";
            }
            else
            {
                img = Image.FromFile("WBishop.png");
                name = "WBishop";
            }
        }
        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (Math.Abs(newLocation.X - PosX) == Math.Abs(newLocation.Y - PosY))
            {
                CanMove = true;
            }
            return CanMove;
        }

    }
}
