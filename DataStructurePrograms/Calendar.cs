using System;
using System.Collections.Generic;
using System.Globalization;

namespace DataStructurePrograms
{
    public class Calendar
    {
        static int year, month;
        static int[,] calendar = new int[6, 7];
        private static DateTime date;
        public static Queue<CalendarWeekDay<Calendar>> weekQueue = new Queue<CalendarWeekDay<Calendar>>();


        public void FindCalendar()
        {
            Console.Write("Enter the year? ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the month (Jan=1,Feb=2 etc): ");
            month = Convert.ToInt32(Console.ReadLine());
            date = new DateTime(year, month, 1);

            GetMonth();
            PrintCalendar();
            Console.WriteLine("\n*************Display calendar using queue************");
            DisplayCalendarQueue();
        }
        /// <summary>
        /// method to find and store calendar in 2d array
        /// </summary>
        public void GetMonth()
        {
            int days = DateTime.DaysInMonth(year, month);
            int currentDay = 1;
            var dayOfWeek = (int)date.DayOfWeek;
            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                CalendarWeekDay<Calendar> cal = new CalendarWeekDay<Calendar>();
                for (int j = 0; j < calendar.GetLength(1) && currentDay - dayOfWeek + 1 <= days; j++)
                {
                    if (i == 0 && month > j)
                    {
                        calendar[i, j] = 0;
                    }
                    else
                    {
                        calendar[i, j] = currentDay - dayOfWeek + 1;
                        CalendarWeekDay<Calendar> calenderObjects = new CalendarWeekDay<Calendar>(calendar[i, j]);
                        cal.InsertAtLast(calenderObjects);
                        currentDay++;
                    }
                }
                weekQueue.Enqueue(cal);
            }
        }

        /// <summary>
        /// Method to print calendar
        /// </summary>
        public void PrintCalendar()
        {
            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}");
            Console.WriteLine("Mon Tue Wed Thu Fri Sat Sun");

            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                for (int j = 0; j < calendar.GetLength(1); j++)
                {
                    if (calendar[i, j] > 0)
                    {

                        if (calendar[i, j] < 10)
                        {
                            Console.Write($" {calendar[i, j]}  ");
                        }
                        else
                        {
                            Console.Write($"{calendar[i, j]}  ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }
        }
        public void DisplayCalendarQueue()
        {
            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}");
            Console.WriteLine("Mon Tue Wed Thu Fri Sat Sun");
            foreach (var i in weekQueue)
            {
                i.DisplayWeek();
            }
        }
    }
}
