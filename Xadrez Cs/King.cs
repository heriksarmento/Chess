using System;
using System.Drawing;

namespace Chess_Cs
{
    public class King : Piece
    {
        public King(int x, int y, bool black) : base(x, y, black)
        {
            if (black)
            {
                img = Image.FromFile("BKing.png");
                name = "BKing";
            }
            else
            {
                img = Image.FromFile("WKing.png");
                name = "WKing";
            }
        }

        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if ((Math.Abs(newLocation.X - PosX)<=1) && (Math.Abs(newLocation.Y - PosY) <= 1))
            {
                CanMove = true;
            }
            return CanMove; 
        }
    }
}
