using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTodo
{
    class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }   
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
    class Program
    {
        static Dictionary<string, decimal> bankAccounts = new Dictionary<string, decimal>();
        static Dictionary<string, List<Transaction>> transactionHistory
                                                 = new Dictionary<string, List<Transaction>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to ABC Bank\n......................");
            while (true)
            {
                PrintMenu();
                string userInput = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Invalid Input, Please try again");
                    continue;
                }
                switch (userInput)
                {
                    case "L":
                        Loginaccount();
                        break;
                    case "A":
                        Addaccount();
                        break;
                    case "C":
                        Checkbalance();
                        break;
                    case "D":

                        Depositbalance();
                        break;
                    case "W":
                        Withdrawbalance();
                        break;
                    case "S":
                        Statement(); 
                        break;
                    case "E":
                        Console.WriteLine("Thank you for using ABC Bank");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Please try again");
                        break;

                }

            }



        }


        static void PrintMenu()
        {
            Console.WriteLine("What do you want to do");
            Console.WriteLine("[L]ogin Account");
            Console.WriteLine("[A]dd Account");
            Console.WriteLine("[C]heck Balance");
            Console.WriteLine("[D]eposit Balance");
            Console.WriteLine("[W]ithdraw Balance");
            Console.WriteLine("[S]tatement");
            Console.WriteLine("[E]xit");
        }

        static void Addaccount()
        {
            Console.WriteLine("Enter Your Account Number");
            string accountNumber = Console.ReadLine().ToUpper();
            if (bankAccounts.ContainsKey(accountNumber))
            {
                Console.WriteLine(accountNumber + ":Account already exists , Please Login");

            }
            else
            {
                bankAccounts.Add(accountNumber,500);
                Console.WriteLine("Account added successfully\n" + "Account Number is : " + accountNumber + " Balance is 500");
                transactionHistory.Add(accountNumber, new List<Transaction>

                {
                    new Transaction
                    {

                    Date = DateTime.Now,
                    Type="Openning",
                    Amount = 500 ,
                    Balance = 500
                    }
                });
            }
        }
        static void Loginaccount()
        {
            Console.WriteLine("Login Your Account Number");
            string accountNumber = Console.ReadLine().ToUpper();
            if (bankAccounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Login Successful");
                Console.WriteLine("Your Account Balance is " + bankAccounts[accountNumber]);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }

        }
        static void Checkbalance()
        {
                Console.WriteLine("Enter Your Account Number to Check Balance");
                string accountNumber = Console.ReadLine().ToUpper();
                if (bankAccounts.ContainsKey(accountNumber))
                {
                    Console.WriteLine("Your Account Balance is " + bankAccounts[accountNumber]);
                 
                }
                else
                {
                    Console.WriteLine("Account does not exist");
                }
        }

        static void Depositbalance()
        {
            Console.WriteLine("Enter Your Account Number to Deposit Balance");
            string accountNumber = Console.ReadLine().ToUpper();
            if (bankAccounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Enter Amount to Deposit");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("Deposit amount must be greater than 0");
                    return;
                }

                bankAccounts[accountNumber] += amount;
                Console.WriteLine("Deposit Successful. New Balance is " + bankAccounts[accountNumber]);
                transactionHistory[accountNumber].Add(new Transaction
                { 
                    Date = DateTime.Now,
                    Type="Deposit",
                    Amount = amount ,
                    Balance = bankAccounts[accountNumber]

                });
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }
        static void Withdrawbalance()
        {
            Console.WriteLine("Enter Your Account Number to Withdraw Balance");
            string accountNumber = Console.ReadLine().ToUpper();
            if (bankAccounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Enter Amount to Withdraw");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("Withdraw amount must be greater than 0");
                    return;
                }
                if (bankAccounts[accountNumber] >= amount)
                {
                    bankAccounts[accountNumber] -= amount;
                    Console.WriteLine("Withdrawal Successful. New Balance is " + bankAccounts[accountNumber]);
                    transactionHistory[accountNumber].Add(new Transaction { 
                        
                        Date = DateTime.Now,
                        Type="Withdraw",
                        Amount= amount ,
                        Balance = bankAccounts[accountNumber] 
                    });
                }
                else
                {
                    Console.WriteLine("Insufficient Balance");
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }
        static void Statement()
        {
            Console.WriteLine("Enter Your Account Number");
            string accountNumber = Console.ReadLine().ToUpper();
            if (bankAccounts.ContainsKey(accountNumber))
            {
                Console.WriteLine($"Statement of Account : {accountNumber}");
                Console.WriteLine("................................");
                foreach (var tr in transactionHistory[accountNumber])
                {
                    
                    Console.WriteLine( $"{tr.Date}|{tr.Type}|Amount : {tr.Amount}|Balance : {tr.Balance}");
                   
                }
                Console.WriteLine("................................");
                Console.WriteLine($"Current Balance : {bankAccounts[accountNumber]}");
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }
    }
}
