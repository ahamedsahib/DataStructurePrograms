using System;
using System.Collections.Generic;

namespace DataStructurePrograms
{
    public class BankingCashCounter<T>
    {
        QueueOperation<T> queue = new QueueOperation<T>();
        
        //Methid for performing cash Counter operations
        public void CashCounter()
        {
            int count=0;
            //list of persons to insert into the queue
            List<string> persons = new List<string> { "Person1", "Person2", "Person3" };
            // array to store the person's Balance
            int[] balance = { 10000,500,2000000 };
            foreach (string i in persons)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                //insert into queue
                queue.Enqueue(x);
            }
            queue.Display();
            foreach (var details in persons)
                {
                    Operation(details, (int)balance.GetValue(count));
                    queue.Display();
                    count++;
                }

        }
        public void Operation(string person, int balance)
        {
            //ask user whether he needs to deposit or withdraw
            Console.WriteLine("\n1.Deposit\n2.Withdraw\n3.Exit\n4.Enter your option");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                //case for deposit
                case 1:
                    Console.WriteLine("Enter Amount to Deposit");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    balance += amount;
                    Console.WriteLine($"Deposited {amount}");
                    Console.WriteLine($"Total Bank Balance : {balance}");
                    //remove person from the queue after his operation performed
                    queue.Dequeue();
                    break;
                //case for withdraw
                case 2:

                    int amountWithdraw;
                    while (true)
                    {
                        Console.WriteLine("Enter Amount to Withdraw");
                        amountWithdraw = Convert.ToInt32(Console.ReadLine());
                        //Check whether balance is present or not
                        if (amountWithdraw.CompareTo(balance)>0)
                        {
                            Console.WriteLine("Bank Balance Insufficient");
                        }
                        else
                        {
                            balance -= amountWithdraw;
                            break;
                        }
                    }
                    Console.WriteLine($" Withdrawed {amountWithdraw} from your Account");
                    Console.WriteLine($"Total Bank Balance Remaining :{balance}");
                    //remove person from the queue after his operation performed
                    queue.Dequeue();
                    break;
                case 3:
                    //remove person from the queue if he wants to exit
                    queue.Dequeue();
                    break;
            }
        }
    }
}
