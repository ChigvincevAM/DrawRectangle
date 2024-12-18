using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawRectangle
{
       public partial class Form1 : Form
    {
        private int[,] rectangleMatrix = {
            {1, 1, 1},
            {1, 0, 1},
            {1, 1, 1}
        };

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int cellSize = 50; // Размер ячейки
            int offsetX = 50; // Сдвиг по X
            int offsetY = 50; // Сдвиг по Y

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < rectangleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleMatrix.GetLength(1); j++)
                {
                    if (rectangleMatrix[i, j] == 1)
                    {
                        g.DrawRectangle(pen, offsetX + j * cellSize, offsetY + i * cellSize, cellSize, cellSize);
                    }
                }
            }
        }
    }

}