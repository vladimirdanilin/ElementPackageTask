using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementPackageTask
{
    public class Chromosome
    {
        public int[] Genes { get; set; }
        public double Fitness { get; set; }

        public Chromosome(int[] genes, double fitness)
        {
            Genes = genes;
            Fitness = fitness;
        }
    }
}
