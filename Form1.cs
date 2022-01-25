using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ElementPackageTask.Package;

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
        private int NumOfSpecies = 50; // Default
        private int MaxNumOfGenerations = 2; //Default кол-во поколений, на протяжении которого значение функции пригодности неизменно
        private int Mutation = 100; // Default процент мутации
        private double PCBWidth = 370; // Default ширина платы
        private double PCBHeight = 370; // Default высота платы
        private int k; //Кол-во поколений, на котором работа программы останавливается
        Package package;
        Fitness fitness = new Fitness();
        InitialData adjacency;

        InitialData elementSize;

        Bitmap bitmapForElements;


        Graphics graphics;
        Brush brushForElement;
        Brush brushForText;
        Color colorForElement;
        Color colorForText = Color.White;
        Pen pen = new Pen(Color.Red);
        public Random rnd = new Random();
        public List<Chromosome> ListOfparentalSpecies;
        public List<Chromosome> ListOfOffspringSpecies;
        public List<Chromosome> ListOfOffspringSpeciesMutated = new List<Chromosome>();
        public List<Chromosome> ListOfSpeciesUNITED;
        public List<Chromosome> ListOfSpeciesSORTED = new List<Chromosome>();
        public List<Chromosome> BestSpecies = new List<Chromosome>();
        private List<Chromosome> BestSpecies1 = new List<Chromosome>();



        private void Start_btn_Click(object sender, EventArgs e)
        {
            ProgramResultLabel.Text = "";
            elementSize = new InitialData(ElementSize.Text);
            FitnessStagnation();
            package = new Package();
            if (BestSpecies[BestSpecies.Count - 1].Fitness != double.MaxValue)
            {
                package.PackageStart(elementSize.Matrix, BestSpecies[BestSpecies.Count - 1].Genes, PCBWidth, PCBHeight);
                PrintResult(false);
            }
            else
            {
                //List<Chromosome> BestSpecies1 = new List<Chromosome>();
                BestSpecies1.AddRange(BestSpecies);
                BestSpecies1.OrderBy(x => x.Fitness).ToList();
                package.PackageStart(elementSize.Matrix, BestSpecies1[0].Genes, PCBWidth, PCBHeight);
                PrintResult(true);
            }
            
            DrawElements();
            SaveResult();
        }

        private void PrintResult(bool mistake)
        {
            if (mistake == false)
            {
                //for (int i = BestSpecies.Count - 1; i >= BestSpecies.Count - MaxNumOfGenerations; i--)
                //{
                    ProgramResultLabel.Text += "\n";
                    foreach (var gene in BestSpecies[BestSpecies.Count - 1].Genes)
                    {
                        ProgramResultLabel.Text += gene;
                        ProgramResultLabel.Text += " \t";
                    }
                    ProgramResultLabel.Text += "\t \t FITNESS = ";
                    //ProgramResultLabel.Text += BestSpecies[i].Fitness;
                    ProgramResultLabel.Text += BestSpecies[BestSpecies.Count - 1].Fitness;
                //}
            }
            else
            {
                if (BestSpecies1[0].Fitness != double.MaxValue)
                {
                    foreach (var gene in BestSpecies1[0].Genes)
                    {
                        ProgramResultLabel.Text += gene;
                        ProgramResultLabel.Text += " ";
                    }
                    ProgramResultLabel.Text += "\t FITNESS = ";
                    ProgramResultLabel.Text += BestSpecies1[0].Fitness;
                }
                else
                {
                    ProgramResultLabel.Text = "Измените размеры PCB";
                }
                
                
            }
            
        } //Печать результата

        void FitnessStagnation() //Неизменность F на протяжении опр-го числа поколений
        {
            int n = 0;
            bool Stagnation = false;

            Population population = new Population(NumOfSpecies);
            ListOfparentalSpecies = new List<Chromosome>();
            ListOfparentalSpecies = population.GenerateInitialPopulation(elementSize.Matrix.Length / 2, ListOfparentalSpecies);
            //BestSpecies.Add(ListOfSpeciesSORTED[0]);
            PrintListOfSpecies(ListOfparentalSpecies, "ListOfPARENTAL");
            PrintListOfSpecies(ListOfOffspringSpeciesMutated, "ListOfOffspringSpeciesMutated");
            while (Stagnation != true)
            {
                k++;
                List<Chromosome> TestList = new List<Chromosome>();
                GenerateNewGeneration(population);
                PrintListOfSpecies(ListOfparentalSpecies, "ListOfPARENTAL");
                PrintListOfSpecies(ListOfOffspringSpeciesMutated, "ListOfOffspringSpeciesMutated");

                TestList.AddRange(ListOfSpeciesUNITED);
                ListOfSpeciesSORTED = TestList.OrderBy(x => x.Fitness).ToList();
                int r = ListOfSpeciesSORTED.Count() / 2;
                int m = ListOfSpeciesSORTED.Count() / 2;
                ListOfSpeciesSORTED.RemoveRange(r, m);
                PrintListOfSpecies(BestSpecies, "BEST SPECIES");

                //if (ListOfSpeciesSORTED[0].Fitness != double.MaxValue)
                //{
                    BestSpecies.Add(ListOfSpeciesSORTED[0]);
                //}

                if (BestSpecies.Count >= MaxNumOfGenerations)
                {
                    for (int i = BestSpecies.Count - 1; i >= BestSpecies.Count-MaxNumOfGenerations; i--)
                    {
                        if ((BestSpecies[i].Fitness == BestSpecies[BestSpecies.Count - 1].Fitness)/*&&(BestSpecies[i].Fitness != double.MaxValue)*/)
                        {
                            n++;
                        }
                    }
                
                if (n >= MaxNumOfGenerations)
                    {
                        Stagnation = true;
                    }
                    n = 0;
                }

                if (k == 500) // ?????????????????
                {
                    Stagnation = true;
                }



            }
         



            PrintListOfSpecies(BestSpecies, "BEST SPECIES");
        }

        private void GenerateNewGeneration(Population population)
        {
            if (ListOfOffspringSpecies != null)
            {
                ListOfparentalSpecies.RemoveRange(0, ListOfparentalSpecies.Count);
                ListOfparentalSpecies.AddRange(ListOfSpeciesSORTED);
            }
            ListOfOffspringSpecies = new List<Chromosome>();
            ListOfOffspringSpeciesMutated = new List<Chromosome>();
            ListOfOffspringSpecies = population.Crossover(elementSize.Matrix.Length/2, ListOfparentalSpecies, ListOfOffspringSpecies);
            ListOfOffspringSpeciesMutated = population.Mutation(elementSize.Matrix.Length / 2, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated, Mutation);
            ListOfSpeciesUNITED = new List<Chromosome>();
            ListOfSpeciesUNITED.AddRange(ListOfparentalSpecies);
            ListOfSpeciesUNITED.AddRange(ListOfOffspringSpeciesMutated);
            InitialData adjacencyExtra = new InitialData(Adjacency.Text);
            foreach (var item in ListOfSpeciesUNITED)
            {
                package = new Package();
                package.PackageStart(elementSize.Matrix, item.Genes, PCBWidth, PCBHeight);
                item.Fitness = fitness.Count(package.ElementsExtra, adjacencyExtra.Matrix);
                bool mistake = false;

                foreach (var item1 in package.ElementsExtra)
                {
                    if (((item1.position.x + item1.width) > PCBWidth) || ((item1.position.y + item1.height) > PCBHeight))
                    {
                        mistake = true;
                    }
                }

                if (mistake == true)
                {
                    item.Fitness = double.MaxValue;
                }
            }
        } //Метод, создающий новое поколение (без генерации начального поколения)


        private void DrawElements() //Метод, рисющий элементы схемы
        {
            bitmapForElements = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmapForElements;
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.DrawRectangle(pen, 0, 0, (float)PCBWidth, (float)PCBHeight);
            foreach (var item in package.Elements)
            {
                colorForElement = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                while (colorForText == colorForElement)
                {
                    colorForText = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }
                int index = package.ElementsExtra.FindIndex(x => x == item);
                brushForElement = new SolidBrush(colorForElement);
                brushForText = new SolidBrush(colorForText);
                graphics.FillRectangle(brushForElement, (float)item.position.x, (float)item.position.y, (float)item.width, (float)item.height);
                graphics.DrawString($"{index}", new Font("Arial", 7), brushForText, (float)(item.position.x + item.width / 2 - Font.Size / 2), (float)(item.position.y + item.height / 2 - Font.Height / 2));
            }

        }

        private void ElementSize_btn_Click(object sender, EventArgs e)
        {
            if (openSizeFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ElementSize.Text = @openSizeFileDialog1.FileName;
        } //Ввод матрицы размеров элементов с формы

        private void Adjacency_btn_Click(object sender, EventArgs e)
        {
            if (openAdjacencyFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Adjacency.Text = @openAdjacencyFileDialog1.FileName;
        } //Ввод матрицы смежности с формы


        private void pictureBox1_Click(object sender, EventArgs e) //Метод, рисующий соединения элементов
        {
            Bitmap finalImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bitmap bitmapForLines = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmapForLines);
            adjacency = new InitialData(Adjacency.Text);


            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                X = mouseEventArgs.X;
                Y = mouseEventArgs.Y;
            }
            
            
            foreach (var item in package.ElementsExtra)
            {
                int index = package.ElementsExtra.FindIndex(x => x == item);
                
                if ((X > item.position.x) && (X < item.position.x + item.width) && (Y > item.position.y) && (Y < item.position.y + item.height))
                {

                    for (int j = 0; j < Math.Sqrt(adjacency.Matrix.Length); j++)
                    {
                        if ((adjacency.Matrix[index, j] != 0) && (index != j))
                        {
                            graphics.DrawLine(pen, (float)package.ElementsExtra[index].position.x + (float)package.ElementsExtra[index].width / 2, (float)package.ElementsExtra[index].position.y + (float)package.ElementsExtra[index].height / 2, (float)package.ElementsExtra[j].position.x + (float)package.ElementsExtra[j].width / 2, (float)package.ElementsExtra[j].position.y + (float)package.ElementsExtra[j].height / 2);
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

        private void PrintListOfSpecies(List<Chromosome> list, string text)
        {
            Console.WriteLine(text);
            foreach (var item in list)
            {
                foreach (var gene in item.Genes)
                {
                    Console.Write(gene + " ");
                }
                Console.Write($" FITNESS = {item.Fitness}");
                Console.WriteLine();
            }
        }

        private void NumSpecies_TextChanged(object sender, EventArgs e)
        {
            int numOfSpecies;
            if (int.TryParse(NumSpecies.Text, out numOfSpecies))
            {
                NumOfSpecies = numOfSpecies;
            }
        } //Ввод кол-ва поколений с формы

        private void PCBwidth_TextChanged(object sender, EventArgs e)
        {
            double pcbWidth;
            if (double.TryParse(PCBwidth.Text, out pcbWidth))
            {
                PCBWidth = pcbWidth;
            }
        } //Ввод ширины платы с формы

        private void PCBheight_TextChanged(object sender, EventArgs e)
        {
            double pcbHeight;
            if (double.TryParse(PCBheight.Text, out pcbHeight))
            {
                PCBHeight = pcbHeight;
            }
        } //Ввод высоты платы с формы

        private void NumOfGConst_TextChanged(object sender, EventArgs e)
        {
            int mnumOfGenerations;
            if (int.TryParse(NumOfGConst.Text, out mnumOfGenerations))
            {
                MaxNumOfGenerations = mnumOfGenerations;
            }
        } //Ввод кол-ва поколений с формы, на протяжении которого F неизменно

        private void MutationPercent_TextChanged(object sender, EventArgs e)
        {
            int mutation;
            if (int.TryParse(MutationPercent.Text, out mutation))
            {
                Mutation = mutation;
            }
        } //Ввод процента мутации

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Save.Text = @folderBrowserDialog1.SelectedPath;
        } //Выбор пути сохранения результата

        private void SaveResult()
        {
            if (Save.Text != "Выберите путь сохранения файла")
            {
                string path = string.Concat(Save.Text, "\\Result.txt");
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {

                    foreach (var item in package.ElementsExtra)
                    {
                        sw.WriteLine($"Width = {item.width} Height = {item.height} X = {item.position.x} Y = {item.position.y}");
                        sw.WriteLine($"DOWN x = {item.position.down.x} y = {item.position.down.y} width = {item.position.down.width} height = {item.position.down.height}");
                        sw.WriteLine($"RIGHT x = {item.position.right.x} y = {item.position.right.y} width = {item.position.right.width} height = {item.position.right.height}");
                        sw.WriteLine();
                    }
                    sw.WriteLine($"{ProgramResultLabel.Text}");


                }
            }
        } //Сохранение 

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
