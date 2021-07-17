using System;
namespace DataStructurePrograms
{
    public class StackOperation<T>
    {
        Node<T> top;

        public void Push(T data)
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


        public void Peek()
        {
            if (this.top == null)
            {
                Console.WriteLine("Stack doesn't contains any value");
            }
            else
            {
                Console.WriteLine($"Top element of stack is {this.top.data}");
            }
        }
        public void Pop()
        {
            if (this.top == null)
            {
                Console.WriteLine("Stack doesn't contains any value");
            }
            else
            {

                Console.WriteLine($"Popped element => {top.data}");
                top = top.next;
            }
        }

        public void Display()
        {
            Node<T> temp = this.top;
            while (temp != null)
            {
                Console.WriteLine($"|__{temp.data}__|");
                temp = temp.next;
            }
        }
        public int ElementsCountOfStack()
        {
            int count = 0;
            Node<T> temp = this.top;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }
    }
}
