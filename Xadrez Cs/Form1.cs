using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Cs
{
    public partial class Form1 : Form
    {
        Game game;
        Point PosA = new Point(50,50);
        Point PosB = new Point(50, 50);

        public Form1()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            SolidBrush brush = new SolidBrush(Color.LightGray);
            Font ft = new Font("Arial", 10);
           
            

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    g.FillRectangle(brush, i * 100, j * 100, 100, 100);
                    if(game.Pos[i, j] != null)
                    {
                        g.DrawImage(game.Pos[i, j].img, i * 100+10, j * 100,90,100);
                    }
                    if (brush.Color == Color.LightGray)
                    {
                        brush.Color = Color.Black;
                    }
                    else
                    {
                        brush.Color = Color.LightGray;
                    }
                    
                }
                if (brush.Color == Color.LightGray)
                {
                    brush.Color = Color.Black;
                }
                else
                {
                    brush.Color = Color.LightGray;
                }
            }

            if (PosA.X != 50)
            {
                g.DrawRectangle(Pens.Red, PosA.X * 100, PosA.Y * 100,100,100);
                g.DrawRectangle(Pens.Yellow, PosB.X * 100, PosB.Y * 100, 100, 100);
            }

            if (game.BlackTurn)
            {
                g.DrawString("Turn: Black", ft, Brushes.Red, 0, 0);
            }
            else
            {
                g.DrawString("Turn: White", ft, Brushes.Red, 0, 0);
            }

            Font gameover = new Font("Arial", 30);

            if (game.gameOver)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                RectangleF r = new RectangleF(0, 0, Width, Height);

                if (game.BlackTurn)
                {
                    g.DrawString("White Win", gameover, Brushes.Red,r, sf);
                }
                else
                {
                    g.DrawString("Black Win", gameover, Brushes.Red, r, sf);
                }
            }



        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!game.gameOver){
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (((e.Location.X > i * 100) && (e.Location.X < (i + 1) * 100)) && ((e.Location.Y > j * 100) && (e.Location.Y < (j + 1) * 100)))
                        {
                            PosA.X = i;
                            PosA.Y = j;
                        }
                    }
                }
                Invalidate();
            }   
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!game.gameOver)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (((e.Location.X > i * 100) && (e.Location.X < (i + 1) * 100)) && ((e.Location.Y > j * 100) && (e.Location.Y < (j + 1) * 100)))
                        {
                            PosB.X = i;
                            PosB.Y = j;
                            if (game.Pos[PosA.X, PosA.Y] != null)
                            {
                                if (((game.Pos[PosA.X, PosA.Y].black) && (game.BlackTurn)) || ((!game.Pos[PosA.X, PosA.Y].black) && (!game.BlackTurn)))
                                {
                                    game.Move(PosA, PosB);
                                }
                            }
                        }
                    }
                }
                PosA = PosB = new Point(50, 50);
                Invalidate();
            }
        }
    }
}
