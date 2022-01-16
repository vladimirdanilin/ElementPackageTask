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
        public double[,] Matrix { get; set; }
        public string Path { get; set; }
        public InitialData(string path)
        {
            Path = path;
            GetElementSizes();
        }
        
        void GetElementSizes()
        {
            int lengthOfString;
            string[] strings = File.ReadAllLines(@Path);
            lengthOfString = strings[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Count();
            Matrix = new double[strings.Length, lengthOfString];
            for (int i = 0; i < strings.Length; i++)
            {
                double[] row = strings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                for (int j = 0; j < lengthOfString; j++)
                {
                    Matrix[i, j] = row[j];
                }

            }
            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < lengthOfString; j++)
                {
                    Console.Write(Matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        
    }
}
