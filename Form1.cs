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

        Graphics graphics;
        Brush brushForElement;
        Brush brushForText;
        Color colorForElement;
        Color colorForText = Color.White;
        public Random rnd = new Random();



        private void Start_btn_Click(object sender, EventArgs e)
        {
            DrawElements();
        }

        private void DrawElements()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            InitialData elementSize = new InitialData(ElementSize.Text);
            Package package = new Package();
            //package.PackageStart();
            package.PackageStart(elementSize.ElementSizeMatrix);


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
                //graphics.DrawRectangle(pen, (float)item.coordinate.x, (float)item.coordinate.y, (float)item.width, (float)item.height);
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
    }
}
