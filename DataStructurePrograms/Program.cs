﻿using System;

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
            BalancedParantheses<string> balancedParantheses = new BalancedParantheses<string>();
            balancedParantheses.CheckParanthesis();
        }
    }
}
