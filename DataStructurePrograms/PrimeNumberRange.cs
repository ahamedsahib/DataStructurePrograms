using System;
namespace DataStructurePrograms
{
    public class PrimeNumberRange
    {
        public static int range = 0, index = 0;
        // 2d - Array for storing prime numbers 
        public int[,] primeNumbers = new int[10, 100];

       
        // Find prime in range
        public void FindPrimeInRange()
        {
            int start = 0, end = 1000, count = 0;

            for (int i = start + 1; i <= end; i++)
            {
                if (count > 100)
                {
                    count = 0;
                    index = 0;
                    range++;
                }

                if (FindPrime(i))
                {
                    primeNumbers[range, index] = i;
                    index++;
                }
                count++;
            }

        }

        /// <summary>
        /// Print the ARRAY
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (primeNumbers[i, j] != 0)
                    {
                        Console.WriteLine(primeNumbers[i, j]);
                    }
                }
                Console.WriteLine("***************************************************");
            }
        }
        /// <summary>
        /// Find number whether prime or not
        /// </summary>
        
        public bool FindPrime(int i)
        {
            bool isPrime = false;
            if (i == 1)
            {
                isPrime = false;
            }
            else if (i == 2)
            {
                isPrime = true;
            }
            else if (i % 2 != 0)
            {
                int f = 0;
                for (int j = 3; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        f = 1;
                        break;
                    }
                }
                if (f != 1)
                {
                    isPrime = true;
                }
            }
            return isPrime;
        }
    }
}
