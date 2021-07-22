using System;
namespace DataStructurePrograms
{
    class PalindromeChecker<T> where T : IComparable
    {
        QueueOperation<T> queue = new QueueOperation<T>();
        Node<T> front;
        string temp = string.Empty;
        public void CheckPalindrome()
        {
            Console.WriteLine("Enter the string");
            //String
            string str = Console.ReadLine();

            //convert it to string
            char[] strArray = str.ToCharArray();


            foreach (char i in strArray)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                Enqueue(x);
            }
            while (Size() > 0)
            {
                Dequeue();
            }
            if (str.Equals(temp))
            {
                Console.WriteLine($"{str} is a palindrome");
            }
            else
            {
                Console.WriteLine($"{str} is not a palindrome");
            }

        }
        public void Enqueue(T data)
        {
            Node<T> temp = new Node<T>(data);
            if (this.front == null)
            {
                temp.next = null;
            }
            else
            {
                temp.next = this.front;
            }
            this.front = temp;
        }
        public void Dequeue()
        {
            if (this.front == null)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                temp = temp + this.front.data;
                front = front.next;
            }
        }
        public int Size()
        {
            int count = 0;
            Node<T> temp = this.front;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }
    }
}