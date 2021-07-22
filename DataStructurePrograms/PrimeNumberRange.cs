using System;
namespace DataStructurePrograms
{
    public class PrimeNumberRange<T> where T:IComparable
    {
        QueueOperation<T> queue = new QueueOperation<T>();
        public static int range = 0, index = 0;
        // 2d - Array for storing prime numbers 
        public T[,] primeNumbers = new T[10, 100];
        public T[,] AnagramNumbers = new T[10, 100];
        public T[,] notAnagramNumbers = new T[10, 100];
        Node<T> top = null;



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
                    primeNumbers[range, index] = (T)Convert.ChangeType(i, typeof(T));
                    index++;
                }
                count++;
            }
            FindAnagram();
            Console.WriteLine("Anagram numbers in range");
            Print(AnagramNumbers);
            //Console.WriteLine("Anagrams in reverse order");
            //DisplayList();
            Console.WriteLine("Anagrams Using Queue");
            queue.Display();
        }

        /// <summary>
        /// Print the ARRAY
        /// </summary>
        public void Print(T[,] array)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (array[i, j].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
                    {
                        Console.WriteLine(array[i, j]);
                    }
                }
                Console.WriteLine("***************************************");
            }
        }
        public void FindAnagram()
        {
            int index = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (primeNumbers[i, j].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
                    {
                        char[] charArr = primeNumbers[i, j].ToString().ToCharArray();
                        Array.Sort(charArr);
                        string str1 = new String(charArr);
                        int firstNum = Convert.ToInt32(str1);
                        int secondNum = 0;
                        int k;
                        for (k = j + 1; k < 100; k++)
                        {
                            char[] charArr1 = primeNumbers[i, k].ToString().ToCharArray();
                            Array.Sort(charArr1);
                            string str2 = new String(charArr1);
                            secondNum = Convert.ToInt32(str2);
                            if (firstNum == secondNum)
                            {
                                break;
                            }
                        }
                        if (firstNum == secondNum)
                        {
                            AnagramNumbers[i, index++] = primeNumbers[i, j];
                            AnagramNumbers[i, index++] = primeNumbers[i, k];
                            //Insert(primeNumbers[i, j]);
                            //Insert(primeNumbers[i, k]);
                            queue.Enqueue(primeNumbers[i, j]);
                            queue.Enqueue(primeNumbers[i, k]);

                        }

                    }
                }

            }
            int flag;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    flag = 0;
                    if (primeNumbers[i, j].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
                    {
                        for (int p = 0; p < 10 && flag != 1; p++)
                        {
                            for (int q = 0; q < 100; q++)
                            {
                                if (primeNumbers[i, j].CompareTo(AnagramNumbers[p, q]) == 0)
                                {
                                    flag = 1;
                                    break;
                                }
                            }
                        }
                        if (flag == 0)
                        {
                            notAnagramNumbers[i, j] = primeNumbers[i, j];

                        }
                    }
                }

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
        public void Insert(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (this.top == null)
            {
                newNode.next = null;
            }
            else
            {
                newNode.next = this.top;
            }
            this.top = newNode;
        }
        public void DisplayList()
        {
            Node<T> temp = this.top;
            while (temp != null)
            {
                Console.WriteLine($"|__{temp.data}__|");
                temp = temp.next;
            }
        }
    }
}
