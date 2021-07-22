using System;

namespace DataStructurePrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Data Structure Programs");
            // UnorderdList<string> unorderdList = new UnorderdList<string>();
            //unorderdList.UnorderdListOperation();
            //OrderdList<int> orderdList = new OrderdList<int>();
            //orderdList.OrderdListOperation();
            //BankingCashCounter<string> cashCounter = new BankingCashCounter<string>();
            //cashCounter.CashCounter();
            //PalindromeChecker<string> palindromeChecker = new PalindromeChecker<string>();
            //palindromeChecker.CheckPalindrome();
            HashSearch<int> hashSearch = new HashSearch<int>();
            hashSearch.SearchNumber();
        }
    }
}
