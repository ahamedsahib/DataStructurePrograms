using System;
using System.Globalization;

namespace DataStructurePrograms
{
    public class Calendar
    {
        static int year, month;
        static int[,] calendar = new int[6, 7];
        private static DateTime date;

        public void FindCalendar()
        {
            Console.Write("Enter the year? ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the month (January = 1, etc): ");
            month = Convert.ToInt32(Console.ReadLine());
            date = new DateTime(year, month, 1);

            GetCalendar();
            PrintCalendar();
        }
        /// <summary>
        /// method to find and store calendar in 2d array
        /// </summary>
        public void GetCalendar()
        {
            int days = DateTime.DaysInMonth(year, month);
            int currentDay = 1;
            var dayOfWeek = (int)date.DayOfWeek;
            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                for (int j = 0; j < calendar.GetLength(1) && currentDay - dayOfWeek + 1 <= days; j++)
                {
                    if (i == 0 && month > j)
                    {
                        calendar[i, j] = 0;
                    }
                    else
                    {
                        calendar[i, j] = currentDay - dayOfWeek + 1;
                        currentDay++;
                    }
                }
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
    }
}
