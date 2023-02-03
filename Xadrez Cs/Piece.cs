using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Cs
{
    public abstract class Piece
    {
        public int PosX;
        public int PosY;
        public bool Alive = true;
        public bool black;
        public string name;
        public Image img;
        public bool CanMove;

        public Piece(int x, int y, bool b)
        {
            black = b;
            PosX = x;
            PosY = y;
        }

        public virtual bool Move(Point location)
        {
            return CanMove;
        }

        public virtual bool Kill(Point point)
        {
            return false;
        }
    }
}
