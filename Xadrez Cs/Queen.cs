using System;
using System.Drawing;

namespace Chess_Cs
{
    public class Queen : Piece
    {
        public Queen(int x, int y, bool black) : base(x, y, black)
        {
            
            if (black)
            {
                img = Image.FromFile("BQueen.png");
                name = "BQueen";
            }
            else
            {
                img = Image.FromFile("WQueen.png");
                name = "WQueen";
            }
        }

        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (((Math.Abs(newLocation.X - PosX) > 0) && (Math.Abs(newLocation.Y - PosY) == 0)) || ((Math.Abs(newLocation.X - PosX) == 0) && (Math.Abs(newLocation.Y - PosY) > 0)) || (Math.Abs(newLocation.X - PosX) == Math.Abs(newLocation.Y - PosY)))
            {
                CanMove = true;
            }
            return CanMove;
        }
    }
}
