using System;
using System.Drawing;

namespace Chess_Cs
{
    public class Pawn : Piece
    {
        public Pawn(int x, int y, bool black) : base(x, y, black)
        {
            if (black)
            {
                img = Image.FromFile("BPawn.png");
                name = "BPawn";
            }
            else
            {
                img = Image.FromFile("WPawn.png");
                name = "WPawn";
            }
        }
        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (newLocation.X - PosX == 0) 
            {
                if (((name == "WPawn") && (newLocation.Y - PosY == -1)) || ((name == "BPawn") && (newLocation.Y - PosY == 1)))
                {
                    CanMove = true;
                }
            }
            return CanMove;
        }

        public override bool Kill(Point newLocation)
        {
            if (Math.Abs(newLocation.X - PosX) == 1)
            {
                if (((name == "WPawn") && (newLocation.Y - PosY == -1)) || ((name == "BPawn") && (newLocation.Y - PosY == 1)))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
