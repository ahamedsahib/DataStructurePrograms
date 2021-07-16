using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructurePrograms
{
    public class OrderdList<T> where T : IComparable
    {
        UnorderdList<T> unorderdList = new UnorderdList<T>();
        Node<T> head;
        public void OrderdListOperation()
        {
            string text = File.ReadAllText(@"/Users/Akshal/Projects/DataStructurePrograms/DataStructurePrograms/OrderdListItems.txt");
            string[] fileList = text.Split(" ");
            List<T> files = new List<T>();
            foreach (string i in fileList)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                files.Add(x);
            }

            foreach (var i in files)
            {

                unorderdList.InsertFront(i);
            }
            Console.WriteLine("The content in the File :\n");
            unorderdList.Display();

            Console.WriteLine("\nEnter the word need to be searched in file:");
            int Word = Convert.ToInt32(Console.ReadLine());
            T searchWord = (T)Convert.ChangeType(Word, typeof(T));

            //search word in linked list 
            if (unorderdList.Search(searchWord))
            {
                unorderdList.DeleteKeyElement(searchWord);
            }
            else
            {
                unorderdList.InsertFront(searchWord);
            }

            Console.WriteLine("\nThe content in the list is\n");
            unorderdList.Display();
            Console.WriteLine("The File after Ordered ");
            unorderdList.Sort();
            unorderdList.Display();
            //write contents from linked list to file
            string resultText = unorderdList.returnString();
            File.WriteAllText(@"/Users/Akshal/Projects/DataStructurePrograms/DataStructurePrograms/OrderdListItems.txt", resultText);
            Console.WriteLine("\nFile Updated Successfully!!!!!! ");
        }

    
    }
}
