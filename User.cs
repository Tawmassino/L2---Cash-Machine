using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2___Cash_Machine
{
    internal class User
    {
        //FIELDS

        //PROPERTIES

        public string CardNumber { get; set; }
        public string PIN { get; set; }
        public int Balance { get; set; }
        //public int TransactionHistory { get; set; }


        public int DailyLimit { get; set; }



        //CONSTRUCTORS

        public User(string cardNumber, string pin, int balance)
        {
            CardNumber = cardNumber;
            PIN = pin;
            Balance = balance;
        }
        public User(int transactionHistory, int dailyLimit)
        {
            //TransactionHistory = transactionHistory;
            DailyLimit = dailyLimit;
        }

        // ======================  METHODS ====================  

        public bool Login()
        {
            bool isLoggedIn = false;
            int attemptsToLogin = 0;
            int maxAttemptsToLogin = 3;

            do
            {
                Console.WriteLine("Please insert your card!");
                string userCardInput = Console.ReadLine();

                if (userCardInput == CardNumber)
                {
                    Console.WriteLine("Enter PIN number:");
                    string userPin = Console.ReadLine();

                    if (userPin == PIN)
                    {
                        isLoggedIn = true;
                        return isLoggedIn;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect PIN. Please try again.");
                        attemptsToLogin++;
                    }
                }
                else if (userCardInput == null)
                {
                    Console.WriteLine("Please insert your card!");
                }
                else
                {
                    Console.WriteLine("This card is not registered");
                    attemptsToLogin++;
                }

                if (attemptsToLogin >= maxAttemptsToLogin)
                {
                    KickOut();
                    return false;
                }

            } while (attemptsToLogin < maxAttemptsToLogin);

            return isLoggedIn;

        }

        public void KickOut()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You've been disconnected");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void ShowBalance()
        {
            Console.WriteLine($" The current balance is: {Balance}");
        }

        public bool DailyLimitReached()
        {
            bool isLimitReached = false;
            string transactionLogFile = "TransactionHistoryLog.txt";
            DateTime currentDate = DateTime.Now.Date;

            if (File.Exists(transactionLogFile))
            {
                // Read the log file
                string[] logEntries = File.ReadAllLines(transactionLogFile);

                // Calculate the number of transactions for the current day
                foreach (string logEntry in logEntries)
                {
                    if (logEntry.StartsWith(currentDate.ToString("yyyy-MM-dd")))
                    {
                        DailyLimit++;
                    }
                }
            }
            if (DailyLimit == 10)
            {
                isLimitReached = true;
            }
            return isLimitReached;
        }


        public void Withdraw(int howMuchWithdraw)//ar cia tas pats bool
        {

            if (howMuchWithdraw <= Balance && DailyLimitReached() == false)
            {
                DateTime currentTime = DateTime.Now.Date;
                string transactionLogFile = "TransactionHistoryLog.txt";

                Console.WriteLine($" Withrawing {howMuchWithdraw} from the Balance of {Balance}");
                Balance -= howMuchWithdraw;
                ShowBalance();
                //TransactionHistory++;


                DailyLimit++;
                //log transaction
                string logEntry = $"{currentTime:yyyy-MM-dd} - Withdrawal: ${howMuchWithdraw}, Remaining Balance: ${Balance}";
                // Append the log entry to the transaction history file

                using (StreamWriter writer = File.AppendText(transactionLogFile))
                {
                    writer.WriteLine(logEntry);
                }
            }
            else
            {
                Console.WriteLine("Unable withdraw. Either insufficient balance or daily limit reached.");
            }
        }

        public void PrintRecentTransactions()
        {
            string logFileName = "TransactionHistoryLog.txt";
            if (File.Exists(logFileName))
            {
                string[] logEntries = File.ReadAllLines(logFileName);
                int startIndex = logEntries.Length - 5;//imam nuo paskutines vietos #5 israsa


                Console.WriteLine(" 5 MOST RECENT TRANSACTIONS: ");

                for (int i = startIndex; i < logEntries.Length; i++)
                {
                    Console.WriteLine(logEntries[i]);
                }
            }
        }

        public void Deposit(int howMuchDeposit)
        {

        }

        // ================== END OF METHODS ==================

    }
}
