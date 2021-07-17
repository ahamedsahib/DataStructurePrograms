using System;
namespace DataStructurePrograms
{
    public class QueueOperation<T>
    {
        Node<T> front;
        Node<T> rear;
        public void Enqueue(T val)
        {
                Node<T> temp = new Node<T>(val);
                if (this.front == null)
                {

                    this.front = temp;
                    this.rear = temp;
                    temp.next = null;
                }
                else
                {
                    this.rear.next = temp;
                    this.rear = temp;
                }
        }

            public void Dequeue()
            {
                if (this.front == null)
                {
                    Console.WriteLine("Queue is Empty");
                    return;
                }
                else
                {

                    this.front = this.front.next;
                    return;
                }

            }

            public void Display()
            {
                Console.WriteLine("\n");
                Node<T> temp = this.front;
                while (temp != null)
                {
                    Console.Write($"|__{temp.data}__|");
                    temp = temp.next;
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
