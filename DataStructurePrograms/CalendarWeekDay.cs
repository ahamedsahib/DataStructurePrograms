using System;
namespace DataStructurePrograms
{
    public class CalendarWeekDay<T>
    {
        public CalendarWeekDay<T> next;
        public CalendarWeekDay<T> head;
        public int date;


        public CalendarWeekDay() { }
        public CalendarWeekDay(int date)
        {
            this.date = date;

            this.next = null;
        }
       
        public void InsertAtLast(CalendarWeekDay<T> temp)
        {
            if (head == null)
            {
                head = temp;
            }
            else
            {
                CalendarWeekDay<T> traverse = this.head;
                while (traverse.next != null)
                {
                    traverse = traverse.next;
                }
                traverse.next = temp;

            }
        }

      

        public void DisplayWeek()
        {
            CalendarWeekDay<T> temp = head;
            while (temp != null)
            {
                if (temp.date > 0)
                {
                    if (temp.date < 10)
                    {
                        Console.Write($"  {temp.date } ");
                    }
                    else
                    {
                        Console.Write($"{temp.date}  ");
                    }

                }
                else
                {
                    Console.Write("  ");

                }
                 temp = temp.next;
            }
            Console.WriteLine("\n");
        }
    }
}
