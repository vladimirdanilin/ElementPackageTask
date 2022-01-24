using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementPackageTask
{
    public class Population
    {
        int NumOfSpecies { get; set; }
        Random random = new Random(DateTime.Now.Millisecond);

        public Population(int numOfSpecies)
        {
            NumOfSpecies = numOfSpecies;
        }
        public Population()
        {
        }

        public List<Chromosome> GenerateInitialPopulation(int numOfElements, List<Chromosome> listOfParentalSpecies)
        {
            int[] genes = new int[numOfElements];
            int[] genes1 = new int[numOfElements];

            for (int i = 0; i < NumOfSpecies; i++)
            {

                for (int j = 0; j < genes.Length; j++)
                {
                        genes[j] = j;
                }
                //Меняем местами гены в рандомном порядке
                genes1 = genes.OrderBy(item => random.Next()).ToArray();
                Chromosome chromosome = new Chromosome(genes1, 0);
                listOfParentalSpecies.Add(chromosome);
            }
            return listOfParentalSpecies;
        }

        public List<Chromosome> Crossover(int numOfElements, List<Chromosome> listOfParentalSpecies, List<Chromosome> listOfOffspringSpecies)
        {
            int[] female = new int[numOfElements];
            int[] male = new int[numOfElements];
            int[] offspring1 = new int[numOfElements];
            int[] offspring2 = new int[numOfElements];
            for (int i = 0; i < NumOfSpecies / 2; i++)
            { 
                int f = random.Next(0, listOfParentalSpecies.Count);
                int m = random.Next(0, listOfParentalSpecies.Count);
                while (f == m)
                {
                    f = random.Next(0, listOfParentalSpecies.Count);
                }
                female = listOfParentalSpecies.ElementAt(f).Genes;
                male = listOfParentalSpecies.ElementAt(m).Genes;
                offspring1 = Breeding(female, male, numOfElements);
                offspring2 = Breeding(male, female, numOfElements);

                Chromosome chromosome1 = new Chromosome(offspring1, 0);
                Chromosome chromosome2 = new Chromosome(offspring2, 0);
                listOfOffspringSpecies.Add(chromosome1);
                listOfOffspringSpecies.Add(chromosome2);
            }
            return listOfOffspringSpecies;



        }

        public int[] Breeding(int[] parent1, int[] parent2, int numOfElements)
        {
            int r = random.Next(0, numOfElements); //Граница генов.
            int[] offspring = new int[numOfElements];
            for (int i = 0; i < r; i++)
            {
                offspring[i] = parent1[i];
            }

            for (int i = r; i < numOfElements; i++)
            {
                foreach (var gene in parent2)
                {
                    if (!offspring.Contains(gene))
                    {
                        offspring[i] = gene;
                    }
                }
            }

            return offspring;
        }

        public List<Chromosome> Mutation(int numOfElements, List<Chromosome> listOfOffspringSpecies, List<Chromosome> listOfOffspringSpeciesMutated, double percentOfMutation)
        {
            int[] arr;

            foreach (var offspring in listOfOffspringSpecies)
            {
                int a = random.Next(0, numOfElements);
                int b = random.Next(a + 1, numOfElements);
                if (b - a < 2)
                {
                    b = random.Next(a + 1, numOfElements);
                }
                int mut = Convert.ToInt32(Math.Round((b - a) * percentOfMutation / 100));
                arr = new int[mut];
                Array.Copy(offspring.Genes, a, arr, 0, arr.Length);

                arr = arr.Reverse().ToArray();


                Array.Copy(arr, 0, offspring.Genes, a, arr.Length);


                listOfOffspringSpeciesMutated.Add(offspring);

            }
            return listOfOffspringSpeciesMutated;
        }
    }
}
