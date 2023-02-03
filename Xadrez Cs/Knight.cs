using System.Drawing;

namespace Chess_Cs
{
    public class Knight : Piece
    {
        public Knight(int x, int y, bool black) : base(x, y, black)
        { 
            if (black)
            {
                img = Image.FromFile("BKnight.png");
                name = "BKnight";
            }
            else
            {
                img = Image.FromFile("WKnight.png");
                name = "WKnight";
            }
        }

        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (((newLocation.X - PosX == 1) && (newLocation.Y - PosY == 2))   ||
                ((newLocation.X - PosX == 1) && (newLocation.Y - PosY == -2))  ||
                ((newLocation.X - PosX == -1) && (newLocation.Y - PosY == 2))  ||
                ((newLocation.X - PosX == -1) && (newLocation.Y - PosY == -2)) ||
                ((newLocation.X - PosX == 2) && (newLocation.Y - PosY == 1))   ||
                ((newLocation.X - PosX == 2) && (newLocation.Y - PosY == -1))  ||
                ((newLocation.X - PosX == -2) && (newLocation.Y - PosY == 1))  ||
                ((newLocation.X - PosX == -2) && (newLocation.Y - PosY == -1)))
            {
                CanMove = true;
            }
            return CanMove;
        }
    }
}
