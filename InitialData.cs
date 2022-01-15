using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementPackageTask
{
    public class InitialData
    {
        public double[,] ElementSizeMatrix { get; set; }
        public string Path { get; set; }
        public InitialData(string path)
        {
            Path = path;
            GetElementSizes();
        }
        
        void GetElementSizes()
        {
            
            string[] strings = File.ReadAllLines(@Path);
            ElementSizeMatrix = new double[strings.Length, 2];
            for (int i = 0; i < strings.Length; i++)
            {
                double[] row = strings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                for (int j = 0; j < 2; j++)
                {
                    ElementSizeMatrix[i, j] = row[j];
                }

            }
        }
    }
}
