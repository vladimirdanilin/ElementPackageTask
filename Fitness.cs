using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElementPackageTask.Package;

namespace ElementPackageTask
{
    public class Fitness
    {
        public Fitness()
        {

        }

        public double Count(List<Element> listOfElements, double[,] adjmatrix)
        { //Подсчет значения функции пригодности каждой особи
            double Sum = 0;

            for (int i = 0; i < Math.Sqrt(adjmatrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(adjmatrix.Length); j++)
                {
                    if ((adjmatrix[i,j] != 0))
                    {
                        Sum += Math.Sqrt(Math.Pow(listOfElements[i].position.x - listOfElements[j].position.x, 2) + Math.Pow(listOfElements[i].position.y - listOfElements[j].position.y, 2)) * adjmatrix[i,j];
                        adjmatrix[j, i] = 0; //Исключаем симметричность
                    }

                }
            }
            Console.WriteLine($"SUM = {Sum}");
      
            return Sum;
        }


    }
}
