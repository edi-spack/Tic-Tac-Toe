using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] mat = new int[3, 3];
        int padding = 40, square = 150, turn = 1, game_over = 0, pos_left = 9;

        private void OnClick(object sender, MouseEventArgs e)
        {
            int i, j;
            i = e.X / square;
            j = e.Y / square;
            if (i >= 0 && i <= 2 && j >= 0 && j <= 2 && mat[i, j] == 0 && game_over == 0)
            {
                mat[i, j] = turn;
                turn = 3 - turn;
                pos_left--;
                Redraw();
            }
            else if(game_over == 1)
            {
                this.Text = "Tic Tac Toe";
                for(i = 0; i <= 2; i++)
                {
                    for(j = 0; j <= 2; j++)
                    {
                        mat[i, j] = 0;
                    }
                }
                game_over = 0;
                pos_left = 9;
                Redraw();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
            int i, j;
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Pen blackPen = new Pen(Color.Black, 4.0f);
            Pen redPen = new Pen(Color.Red, 10.0f);
            Pen bluePen = new Pen(Color.Blue, 10.0f);
            Pen greenPen = new Pen(Color.Green, 6.0f);
            g.DrawLine(blackPen, square, 0, square, 3 * square);
            g.DrawLine(blackPen, 2 * square, 0, 2 * square, 3 * square);
            g.DrawLine(blackPen, 0, square, 3 * square, square);
            g.DrawLine(blackPen, 0, 2 * square, 3 * square, 2 * square);

            if(turn == 1)
            {
                this.Text = "Tic Tac Toe: X is next";
            }
            else if(turn == 2)
            {
                this.Text = "Tic Tac Toe: 0 is next";
            }

            for (i = 0; i <= 2; i++)
            {
                for (j = 0; j <= 2; j++)
                {
                    if (mat[i, j] == 1)
                    {
                        g.DrawLine(bluePen, i * square + padding, j * square + padding, (i + 1) * square - padding, (j + 1) * square - padding);
                        g.DrawLine(bluePen, (i + 1) * square - padding, j * square + padding, i * square + padding, (j + 1) * square - padding);
                    }
                    else if (mat[i, j] == 2)
                    {
                        g.DrawEllipse(redPen, i * square + padding, j * square + padding, square - 2 * padding, square - 2 * padding);
                    }
                }
            }

            for (i = 0; i <= 2 && game_over == 0; i++)
            {
                if (mat[i, 0] != 0 && mat[i, 0] == mat[i, 1] && mat[i, 0] == mat[i, 2])
                {
                    game_over = 1;
                    g.DrawLine(greenPen, i * square + square / 2, padding / 2, i * square + square / 2, 3 * square - padding / 2);
                }
                else if (mat[0, i] != 0 && mat[0, i] == mat[1, i] && mat[0, i] == mat[2, i])
                {
                    game_over = 1;
                    g.DrawLine(greenPen, padding / 2, i * square + square / 2, 3 * square - padding / 2, i * square + square / 2);
                }
            }
            if (mat[0, 0] != 0 && mat[0, 0] == mat[1, 1] && mat[0, 0] == mat[2, 2] && game_over == 0)
            {
                game_over = 1;
                g.DrawLine(greenPen, padding / 2, padding / 2, 3 * square - padding / 2, 3 * square - padding / 2);
            }
            else if (mat[2, 0] != 0 && mat[2, 0] == mat[1, 1] && mat[2, 0] == mat[0, 2] && game_over == 0)
            {
                game_over = 1;
                g.DrawLine(greenPen, 3 * square - padding / 2, padding / 2, padding / 2, 3 * square - padding / 2);
            }

            if (pos_left == 0)
            {
                game_over = 1;
            }

            if (game_over == 1)
            {
                this.Text = "CLICK ANYWHERE TO PLAY AGAIN";
            }
        }
    }
}
