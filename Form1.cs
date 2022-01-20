﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        Package package;
        Fitness fitness = new Fitness();
        InitialData adjacency;

        InitialData elementSize;
        int MaxNumOfGenerations = 1;

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



        private void Start_btn_Click(object sender, EventArgs e)
        {
            elementSize = new InitialData(ElementSize.Text);
            FitnessStagnation();
            package = new Package();
            package.PackageStart(elementSize.Matrix, BestSpecies[BestSpecies.Count-1].Genes, 150, 330);
            DrawElements();
        }

        void FitnessStagnation()
        {
            int n = 0;
            bool Stagnation = false;
            Population population = new Population(50);
            ListOfparentalSpecies = new List<Chromosome>();
            ListOfparentalSpecies = population.GenerateInitialPopulation(elementSize.Matrix.Length / 2, ListOfparentalSpecies);
            //BestSpecies.Add(ListOfSpeciesSORTED[0]);
            PrintListOfSpecies(ListOfparentalSpecies, "ListOfPARENTAL");
            PrintListOfSpecies(ListOfOffspringSpeciesMutated, "ListOfOffspringSpeciesMutated");
            while (Stagnation != true)
            {
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

                bool Exists = false;
                foreach (var item in BestSpecies)
                {
                    if (item.Genes == ListOfSpeciesSORTED[0].Genes)
                    {
                        Exists = true;   
                    }
                }
                if (Exists == false)
                {
                    BestSpecies.Add(ListOfSpeciesSORTED[0]);
                }

                if (BestSpecies.Count >= MaxNumOfGenerations)
                {
                    for (int i = BestSpecies.Count - 1; i >= BestSpecies.Count-MaxNumOfGenerations; i--)
                    {
                        if (BestSpecies[i].Fitness == BestSpecies[BestSpecies.Count - 1].Fitness)
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



            }
            //BestSpecies = BestSpecies.OrderBy(x => x.Fitness).ToList();
            PrintListOfSpecies(BestSpecies, "BEST SPECIES");
        }

        private void GenerateNewGeneration(Population population)
        {
            if (ListOfOffspringSpecies != null)
            {
                ListOfparentalSpecies.RemoveRange(0, ListOfparentalSpecies.Count);
                ListOfparentalSpecies.AddRange(ListOfOffspringSpeciesMutated);
            }
            ListOfOffspringSpecies = new List<Chromosome>();
            ListOfOffspringSpeciesMutated = new List<Chromosome>();
            ListOfOffspringSpecies = population.Crossover(elementSize.Matrix.Length/2, ListOfparentalSpecies, ListOfOffspringSpecies);
            ListOfOffspringSpeciesMutated = population.Mutation(elementSize.Matrix.Length / 2, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated, 50);
            ListOfSpeciesUNITED = new List<Chromosome>();
            ListOfSpeciesUNITED.AddRange(ListOfparentalSpecies);
            ListOfSpeciesUNITED.AddRange(ListOfOffspringSpeciesMutated);
            InitialData adjacencyExtra = new InitialData(Adjacency.Text);
            foreach (var item in ListOfSpeciesUNITED)
            {
                package = new Package();
                package.PackageStart(elementSize.Matrix, item.Genes, 150, 370);
                item.Fitness = fitness.Count(package.ElementsExtra, adjacencyExtra.Matrix);
            }
        }


        private void DrawElements() //Метод, рисющий элементы схемы
        {
            bitmapForElements = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmapForElements;
            graphics = Graphics.FromImage(pictureBox1.Image);

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

            //Fitness(x,y,width,height)
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
    }
}
