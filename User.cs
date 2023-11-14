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
        //public int DailyLimit { get; set; }



        //CONSTRUCTORS

        public User(string cardNumber, string pin, int balance)
        {
            CardNumber = cardNumber;
            PIN = pin;
            Balance = balance;
            //DailyLimit = dailyLimit;
        }


        // ======================  METHODS ====================  



        public void ShowBalance()
        {
            Console.WriteLine($" The current balance is: {Balance}");
        }

        public bool DailyLimitReached()
        {
            bool isLimitReached = false;
            string transactionLogFile = $"TransactionHistoryLog-{CardNumber}.txt";
            DateTime currentDate = DateTime.Now.Date;
            int dailyLimit = 0;

            if (File.Exists(transactionLogFile))
            {
                // Read log file
                string[] logEntries = File.ReadAllLines(transactionLogFile);

                // Calculate number of transactions for current day
                foreach (string logEntry in logEntries)
                {

                    if (logEntry.StartsWith(currentDate.ToString("yyyy-MM-dd")))//parse i DateTime
                    {
                        dailyLimit++;
                    }
                    // else { dailyLimit = 0; } //?reset dailylimit?
                }
            }
            if (dailyLimit >= 10)//daugiau lygu del propgramavimo netyciuku
            {
                isLimitReached = true;
            }



            return isLimitReached;
        }


        public void Withdraw()
        {
            Console.WriteLine(
                "╔══════════════════════════════════════════╗" + "\r\n" +
                "║           HOW MUCH TO WITHDRAW?          ║\r\n" +
                "╚══════════════════════════════════════════╝" +
                "");

            int howMuchWithdraw = 0;
            try
            {
                howMuchWithdraw = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex) { Console.WriteLine(ex.Message); }
            catch (InvalidCastException ex) { Console.WriteLine(ex.Message); }

            if (howMuchWithdraw > 1000)
            {
                Console.WriteLine("You cannot withdraw more than 1000 at once");
            }
            else if (howMuchWithdraw < 0)
            {
                Console.WriteLine("You cannot withdraw a negative ammount");
            }
            else
            {

                if (howMuchWithdraw <= Balance && !DailyLimitReached())//DailyLimitReached() == false
                {
                    DateTime currentTime = DateTime.Now.Date;
                    string transactionLogFile = $"TransactionHistoryLog-{CardNumber}.txt";

                    Console.WriteLine($" Withrawing {howMuchWithdraw} from the Balance of {Balance}");
                    Balance -= howMuchWithdraw;
                    ShowBalance();
                    //TransactionHistory++;


                    //log transaction
                    string logEntry = $"{currentTime:yyyy-MM-dd} - Withdrawal: ${howMuchWithdraw}, Remaining Balance: ${Balance}, CARD: {CardNumber}";
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
        }

        public void PrintRecentTransactions()
        {
            string logFileName = $"TransactionHistoryLog-{CardNumber}.txt";


            try
            {
                if (File.Exists(logFileName))
                {
                    string[] logEntries = File.ReadAllLines(logFileName);
                    int startIndex = 0;
                    if (logEntries.Length >= 5)
                    {
                        startIndex = logEntries.Length - 5;
                    }


                    Console.WriteLine("5 MOST RECENT TRANSACTIONS: ");
                    for (int i = startIndex; i < logEntries.Length; i++)
                    {
                        Console.WriteLine(logEntries[i]);
                    }
                }
            }
            catch (IndexOutOfRangeException e) { Console.WriteLine(e.Message); }
        }

        public void Deposit()
        {
            Console.WriteLine(
                "╔══════════════════════════════════════════╗" + "\r\n" +
                "║           HOW MUCH TO DEPOSIT?           ║\r\n" +
                "╚══════════════════════════════════════════╝" +
                "");

            int howMuchDeposit = 0;
            try
            {
                howMuchDeposit = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex) { Console.WriteLine(ex.Message); }
            catch (InvalidCastException ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine($"Depositting {howMuchDeposit} to the Balance of {Balance}");
            Balance += howMuchDeposit;
            ShowBalance();


            DateTime currentTime = DateTime.Now.Date;
            string transactionLogFileMaster = "TransactionHistoryLog.txt";
            string transactionLogFileSeperate = $"TransactionHistoryLog-{CardNumber}.txt";

            //log transaction
            string logEntry = $"{currentTime:yyyy-MM-dd} - Deposit: ${howMuchDeposit}, Remaining Balance: ${Balance}, CARD: {CardNumber}";
            // Append the log entry to the transaction history file

            using (StreamWriter writer = File.AppendText(transactionLogFileMaster))
            {
                writer.WriteLine(logEntry);
            }

            using (StreamWriter writer = File.AppendText(transactionLogFileSeperate))
            {
                writer.WriteLine(logEntry);
            }
        }


        // ================== END OF METHODS ==================

    }
}
