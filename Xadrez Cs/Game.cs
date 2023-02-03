using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Cs
{
    internal class Game
    {
        public Piece[,] Pos = new Piece[8, 8];
        public bool BlackTurn = false;
        public bool gameOver = false;
        public Game() {
            Pos[0, 0] = new Rook(0,0,true);
            Pos[1, 0] = new Knight(1,0, true);
            Pos[2, 0] = new Bishop(2,0, true);
            Pos[3, 0] = new King(3,0, true);
            Pos[4, 0] = new Queen(4,0, true);
            Pos[5, 0] = new Bishop(5,0, true);
            Pos[6, 0] = new Knight(6,0, true); 
            Pos[7, 0] = new Rook(7,0, true);
            for (int i = 0; i < 8; i++)
            {
                Pos[i, 1] = new Pawn(i,1, true);
                Pos[i, 6] = new Pawn(i,6, false);
            }
            Pos[0, 7] = new Rook(0,7, false);
            Pos[1, 7] = new Knight(1,7, false);
            Pos[2, 7] = new Bishop(2,7, false);
            Pos[3, 7] = new King(3,7, false);
            Pos[4, 7] = new Queen(4,7, false);
            Pos[5, 7] = new Bishop(5,7, false);
            Pos[6, 7] = new Knight(6,7, false);
            Pos[7, 7] = new Rook(7,7, false);
        }

        public void Move(Point a, Point b)
        {
            bool CannotMove = false;
            if (Pos[a.X, a.Y] != null)
            {

                if ((((b.Y != a.Y) || (b.X != a.X)) && Pos[a.X, a.Y].Move(new Point(b.X, b.Y))) && !((Pos[a.X, a.Y].GetType().Name == "Pawn") && (Pos[b.X, b.Y] != null)))
                {

                    if (Pos[a.X, a.Y].PosX - b.X == 0)
                    {
                        if(Pos[a.X, a.Y].PosY - b.Y > 0)
                        {
                            for (int i = 1; i < Pos[a.X, a.Y].PosY - b.Y; i++)
                            {
                                if(Pos[a.X, a.Y - i] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 1; i < Math.Abs(Pos[a.X, a.Y].PosY - b.Y); i++)
                            {
                                if (Pos[b.X, b.Y - i] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                    }
                    else if (Pos[a.X, a.Y].PosY - b.Y == 0)
                    {
                        if (Pos[a.X, a.Y].PosX - b.X > 0)
                        {
                            for (int i = 1; i < Pos[a.X, a.Y].PosX - b.X; i++)
                            {
                                if (Pos[a.X-i, a.Y] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 1; i < Math.Abs(Pos[a.X, a.Y].PosX - b.X); i++)
                            {
                                if (Pos[b.X-i, b.Y] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                    }
                    else if(Math.Abs(Pos[a.X, a.Y].PosY - b.Y) == Math.Abs(Pos[a.X, a.Y].PosX - b.X))
                    {

                        if ((Pos[a.X, a.Y].PosY - b.Y > 0) && (Pos[a.X, a.Y].PosX - b.X > 0))
                        {
                            for (int i = 1; i < Math.Abs(Pos[a.X, a.Y].PosX - b.X); i++)
                            {
                                if (Pos[b.X + i, b.Y + i] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                        else if ((Pos[a.X, a.Y].PosY - b.Y > 0) && (Pos[a.X, a.Y].PosX - b.X < 0))
                        {
                            for (int i = 1; i < Math.Abs(Pos[a.X, a.Y].PosX - b.X); i++)
                            {
                                if (Pos[b.X - i, b.Y + i] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                        else if ((Pos[a.X, a.Y].PosY - b.Y < 0) && (Pos[a.X, a.Y].PosX - b.X > 0))
                        {
                            for (int i = 1; i < Math.Abs(Pos[a.X, a.Y].PosX - b.X); i++)
                            {
                                if (Pos[b.X + i, b.Y - i] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                        else  
                        {
                            for (int i = 1; i < Math.Abs(Pos[a.X, a.Y].PosX - b.X); i++)
                            {
                                if (Pos[b.X - i, b.Y - i] != null)
                                {
                                    CannotMove = true;
                                }
                            }
                        }
                    }
                    if (!CannotMove)
                    {
                        if (Pos[b.X, b.Y] != null)
                        {
                            if (((Pos[b.X, b.Y].black) && (Pos[a.X, a.Y].black)) || (!(Pos[b.X, b.Y].black) && !(Pos[a.X, a.Y].black))) { }
                            else
                            {

                                    Pos[b.X, b.Y] = Pos[a.X, a.Y];
                                    Pos[a.X, a.Y] = null;
                                    Pos[b.X, b.Y].PosX = b.X;
                                    Pos[b.X, b.Y].PosY = b.Y;
                                    BlackTurn = !BlackTurn;
                                
                            }
                        }
                        else
                        {

                            Pos[b.X, b.Y] = Pos[a.X, a.Y];
                            Pos[a.X, a.Y] = null;
                            Pos[b.X, b.Y].PosX = b.X;
                            Pos[b.X, b.Y].PosY = b.Y;
                            BlackTurn = !BlackTurn;
                        }
                    }
                }else if((!Pos[a.X, a.Y].Move(new Point(b.X, b.Y))) && (Pos[b.X, b.Y]!=null)){
                    if (Pos[a.X, a.Y].GetType().Name == "Pawn")
                    {
                        if (Pos[a.X, a.Y].Kill(new Point(b.X, b.Y)))
                        {
                            Pos[b.X, b.Y] = Pos[a.X, a.Y];
                            Pos[a.X, a.Y] = null;
                            Pos[b.X, b.Y].PosX = b.X;
                            Pos[b.X, b.Y].PosY = b.Y;
                            BlackTurn = !BlackTurn;
                        }
                    }
                }
            }

            bool WKing = false;
            bool BKing = false;
            foreach (Piece falseKing in Pos)
            {
                if (falseKing != null)
                {
                    if (falseKing.GetType().Name == "King")
                    {
                        if (falseKing.name == "WKing")
                        {
                            WKing = true;
                        }
                        else
                        {
                            BKing = true;
                        }
                    }
                } 
            }

            if ((!WKing) || (!BKing))
            {
                gameOver = true;
            }



        }



    }
}
