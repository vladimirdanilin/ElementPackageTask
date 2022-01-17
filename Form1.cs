using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ElementPackageTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double X;
        private double Y;
        Package package = new Package();
        Bitmap bitmapForElements;


        Graphics graphics;
        Brush brushForElement;
        Brush brushForText;
        Color colorForElement;
        Color colorForText = Color.White;
        Pen pen = new Pen(Color.Red);
        public Random rnd = new Random();



        private void Start_btn_Click(object sender, EventArgs e)
        {
            DrawElements();
        }

        private void DrawElements() //Метод, рисющий элементы схемы
        {
            bitmapForElements = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmapForElements;
            graphics = Graphics.FromImage(pictureBox1.Image);

            InitialData elementSize = new InitialData(ElementSize.Text);
            
            package.PackageStart(elementSize.Matrix);
                                  
            foreach (var item in package.Elements)
            {
                colorForElement = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                while (colorForText == colorForElement)
                {
                    colorForText = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }
                int index = package.Elements.FindIndex(x => x == item);
                brushForElement = new SolidBrush(colorForElement);
                brushForText = new SolidBrush(colorForText);
                graphics.FillRectangle(brushForElement, (float)item.coordinate.x, (float)item.coordinate.y, (float)item.width, (float)item.height);
                graphics.DrawString($"{index}", new Font("Arial", 7), brushForText, (float)(item.coordinate.x + item.width / 2 - Font.Size / 2), (float)(item.coordinate.y + item.height / 2 - Font.Height / 2));
            }
        }

        private void ElementSize_btn_Click(object sender, EventArgs e)
        {
            if (openSizeFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ElementSize.Text = @openSizeFileDialog1.FileName;
        }

        private void Adjacency_btn_Click(object sender, EventArgs e)
        {
            if (openAdjacencyFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Adjacency.Text = @openAdjacencyFileDialog1.FileName;
        }


        private void pictureBox1_Click(object sender, EventArgs e) //Метод, рисующий соединения элементов
        {
            Bitmap finalImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bitmap bitmapForLines = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmapForLines);

            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                X = mouseEventArgs.X;
                Y = mouseEventArgs.Y;
            }
            
            InitialData adjacency = new InitialData(Adjacency.Text);
            
            foreach (var item in package.Elements)
            {
                int index = package.Elements.FindIndex(x => x == item);
                
                if ((X > item.coordinate.x) && (X < item.coordinate.x + item.width) && (Y > item.coordinate.y) && (Y < item.coordinate.y + item.height))
                {

                    for (int j = 0; j < Math.Sqrt(adjacency.Matrix.Length); j++)
                    {
                        if ((adjacency.Matrix[index, j] != 0) && (index != j))
                        {
                            graphics.DrawLine(pen, (float)package.Elements[index].coordinate.x + (float)package.Elements[index].width / 2, (float)package.Elements[index].coordinate.y + (float)package.Elements[index].height / 2, (float)package.Elements[j].coordinate.x + (float)package.Elements[j].width / 2, (float)package.Elements[j].coordinate.y + (float)package.Elements[j].height / 2);
                        }
                    }

                }
            }

            using (Graphics g = Graphics.FromImage(finalImage))
            {               
                    g.DrawImage(bitmapForElements, 0,0);
                    g.DrawImage(bitmapForLines, 0,0);
            }

            pictureBox1.Image = finalImage;

        }
    }
}
