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

namespace Xadrez_Cs
{
    public partial class Form1 : Form
    {
        Game game;
        Point PosA;
        Point PosB;
        int []posA = new int[2] { 50, 50 };
        int []posB = new int[2] { 50, 50 };

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

            if (posA != null)
            {
                g.DrawRectangle(Pens.Red, PosA.X * 100, PosA.Y * 100,100,100);
                g.DrawRectangle(Pens.Yellow, PosB.X * 100, PosB.Y * 100, 100, 100);
            }



        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(((e.Location.X>i*100) && (e.Location.X < (i+1) * 100)) && ((e.Location.Y > j * 100) && (e.Location.Y < (j + 1) * 100)))
                    {
                        PosA.X = i;
                        PosA.Y = j;
                    }
                }
            }
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        { 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((e.Location.X > i * 100) && (e.Location.X < (i + 1) * 100)) && ((e.Location.Y > j * 100) && (e.Location.Y < (j + 1) * 100)))
                    {
                        PosB.X = i;
                        PosB.Y = j;
                        game.Move(PosA, PosB);
                        PosA = PosB = new Point();
                    }
                }
            }
            Invalidate();
        }




    }
}
