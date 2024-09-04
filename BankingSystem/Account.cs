using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public abstract class Account
    {
        private string accountNumber;
        private double balance;
        public Account(string accountnumber, double balance)
        {
            this.accountNumber = accountnumber;
            this.balance = balance;
        }
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public abstract double CalculateInterest();
    }
    public class SavingAccount : Account, ITransaction
    {
        private double interestRate;
        public SavingAccount(string accountNumber, double balance, double interestRate) : base(accountNumber, balance) 
        {
            this.interestRate = interestRate;
        }
        public double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }
        public override double CalculateInterest()
        {
            return Balance * (InterestRate / 100);
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine("Deposited " + amount + " \nNew balance: " + Balance);
            }
            else
            {
                Console.WriteLine("Deposit Amount must be Positive");
            }
        }
        public void Withdraw(double amount)
        {
            if(amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Withdraw"+ amount+ " \nNew balance"+ Balance);
                
            }
            else if(amount < 0)
            {
                Console.WriteLine("Withdraw amount must be positive.");
            }
            else
            {
                Console.WriteLine("Insufficient Fund");
            }
        }
    public class CheckingAccount : Account, ITransaction
    {
        private double overdraftLimit;
        public CheckingAccount(string accountNumber, double balance, double overdraftLimit) : base(accountNumber, balance)
        {
            this.overdraftLimit = overdraftLimit;
        }
        public double OverdraftLimit
        {
            get { return overdraftLimit; }
            set { overdraftLimit = value; }
        }
        public override double CalculateInterest()
        {
            return Balance * 0.1;
        }
        public void Deposit(double amount)
            {
                if(amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine("Deposited " + amount + " \nNew balance: " + Balance);
                }
                else
                {
                    Console.WriteLine("Deposit Amount must be positive");
                }
            }
        public void Withdraw(double amount)
        {
                if (amount > 0 && amount <= Balance + overdraftLimit)
                {
                    Balance -= amount;
                    Console.WriteLine("Withdraw " + amount + " \nNew balance: " + Balance);
                }
                else if (amount <= 0)
                {
                    Console.WriteLine("Amount must be Positive");
                }

                else
                {
                    Console.WriteLine("Insufficient funds or overdraft limit exceeded.");
                }
        }
    }
        public class Test
        {
            static void Main(string[] args)
            {
                SavingAccount sa = new SavingAccount("0987654321", 1000.0, 5.0);
                CheckingAccount ca = new CheckingAccount("1234567890", 1000, 7.0);

                //Performing Transaction

                //Transaction on Saving Account
                Console.WriteLine("Saving Account");
                sa.Deposit(1000);
                sa.Withdraw(200);
                Console.WriteLine("Interest: "+ sa.CalculateInterest());

                Console.WriteLine("\n");

                //Transaction on Checking Account
                Console.WriteLine("Checking Account");
                ca.Deposit(200);
                ca.Withdraw(600);
                Console.WriteLine("Interest: "+ ca.CalculateInterest());
                Console.ReadLine();

            }

        }

        
    }
}
