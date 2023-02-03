using System;
using System.Drawing;

namespace Chess_Cs
{
    public class Rook : Piece
    {
        public Rook(int x, int y, bool black) : base(x, y, black)
        {
            if (black)
            {
                img = Image.FromFile("BRook.png");
                name = "BRook";
            }
            else
            {
                img = Image.FromFile("WRook.png");
                name = "WRook";
            }
        }
        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (((Math.Abs(newLocation.X - PosX) > 0) && (Math.Abs(newLocation.Y - PosY) == 0)) || ((Math.Abs(newLocation.X - PosX) == 0) && (Math.Abs(newLocation.Y - PosY) > 0)))
            {
                CanMove = true;
            }
            return CanMove;
        }
    }
}
