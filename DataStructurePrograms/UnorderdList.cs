using System;
using System.IO;

namespace DataStructurePrograms
{
    public class UnorderdList<T> where T : IComparable
    {
        Node<T> head;
        public void UnorderdListOperation()
        {
            string text = File.ReadAllText(@"/Users/Akshal/Projects/DataStructurePrograms/DataStructurePrograms/ListUnorderdItems.txt");
            string[] fileList = text.Split(" ");

            foreach (string i in fileList)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                InsertFront(x);
            }
            Console.WriteLine("The content in the File :\n");
            Display();

            Console.WriteLine("\nEnter the word need to be searched in file:");
            string Word = Console.ReadLine();
            T searchWord = (T)Convert.ChangeType(Word, typeof(T));

            //search word in linked list 
            if (Search(searchWord))
            {
                DeleteKeyElement(searchWord);
            }
            else
            {
                InsertFront(searchWord);
            }

            Console.WriteLine("\nThe content in the list is\n");
            Display();

            //write contents from linked list to file
            string resultText = returnString();
            File.WriteAllText(@"/Users/Akshal/Projects/DataStructurePrograms/DataStructurePrograms/ListUnorderdItems.txt", resultText);
            Console.WriteLine("\nFile Updated Successfully!!!!!! ");
        }


        public void InsertFront(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.next = this.head;
            this.head = newNode;

        }
        public void DeleteKeyElement(T data)
        {
            if (this.head != null)
            {
                Node<T> temp = this.head;
                Node<T> prev = null;
                while (temp != null)
                {

                    if ((temp.data).CompareTo(data) == 0)
                    {
                        prev.next = temp.next;
                        break;
                    }
                    prev = temp;
                    temp = temp.next;
                }

            }

        }
        public bool Search(T value)
        {
            Node<T> temp = this.head;
            while (temp != null)
            {
                if (temp.data.Equals(value))
                {
                    Console.WriteLine($"\n{value} Found");
                    return true;
                }
                temp = temp.next;
            }
            return false;

        }
        public string returnString()
        {
            Node<T> temp = this.head;

            string finaltext = String.Empty;
            while (temp != null)
            {
                if (temp.next != null)
                {
                    finaltext = finaltext + temp.data + " ";

                }
                else
                {
                    finaltext = finaltext + temp.data;
                }

                temp = temp.next;
            }
            return finaltext;
        }
        public void Display()
        {
            Node<T> temp = this.head;
            while (temp != null)
            {
                if (temp.next != null)
                {
                    Console.Write($"{temp.data} ");

                }
                else
                {
                    Console.Write(temp.data);
                }

                temp = temp.next;
            }

        }
        public void Sort()
        {
            Node<T> i;
            Node<T> j;
            T temp;
            for (i = this.head; i != null; i = i.next)
            {
                for (j = i.next; j != null; j = j.next)
                {

                    if ((i.data).CompareTo(j.data) > 0)
                    {
                        temp = i.data;
                        i.data = j.data;
                        j.data = temp;
                    }
                }

            }
        }
    }
}
