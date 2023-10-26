using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;

namespace L2___Cash_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== TO DO =====
            //get; set - del privatumo
            //print to file: users,pins,balances


            #region Guids
            /*
             * Guid randomCardNumberGenerator = Guid.NewGuid();
            List<Guid> randomCardNumbers = new List<Guid>();
            int howManyUsers = 10;
            List<Guid> allUsersList = new List<Guid>();
            for (int i = 0; i < howManyUsers; i++)
            {
                allUsersList.Add(randomCardNumberGenerator);
            }

            allUsersList.ForEach(x => { Console.WriteLine(x); });
            */
            #endregion

            // ===== USERS =====


            //(string cardNumber, string pin, int balance, int dailyLimit)

            #region FailedDictionary



            //Dictionary<string, string> usersCardnPins = new Dictionary<string, string>() { };
            //usersCardnPins.Add("X", "0000");

            //User currentUser = new User("X", "0000", 1500, 0);
            //User user1 = new User("X XX XXX", "0000", 1500, 0);
            //User user2 = new User("b69d8293 - 7b62 - 4520 - 93aa - 3ece99882036", "1234", 123456789, 0);
            //User user3 = new User("8c5eb7d6 - 3ae3 - 452a - b551 - 283fc20d9253", "5678", 987654321, 0);
            //User user4 = new User("eb311901-4582-481a-b697-13b52e4d2349", "4321", 20231026, 0);
            //User user5 = new User("c88e180e-b996-40eb-8f38-98abc8db2ba1", "8765", 14101223, 0);
            //User user6 = new User("f3b5228d-937f-4407-af03-d0bce35ae269", "0101", 1993, 0);
            #endregion

            #region AllUsers           
            List<User> users = new List<User>();

            User currentUser = new User("X", "0000", 1500, 0);
            User user1 = new User("X XX XXX", "0000", 1500, 0);
            User user2 = new User("b69d8293-7b62-4520-93aa-3ece99882036", "1234", 123456789, 0);
            User user3 = new User("8c5eb7d6-3ae3-452a-b551-283fc20d9253", "5678", 987654321, 0);
            User user4 = new User("eb311901-4582-481a-b697-13b52e4d2349", "4321", 20231026, 0);
            User user5 = new User("c88e180e-b996-40eb-8f38-98abc8db2ba1", "8765", 14101223, 0);
            User user6 = new User("f3b5228d-937f-4407-af03-d0bce35ae269", "0101", 1993, 0);

            users.Add(currentUser);
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);
            users.Add(user6);

            //print to file
            //private delegate string userData(string toPrint);

            //userData printer = delegate (DisplayEachUserData(users));

            var dataToPrint = DisplayEachUserData(users);
            File.WriteAllText("AllUserData.txt", dataToPrint);

            string userDataFromFile = File.ReadAllText("AllUserData.txt");

            //    string content = File.ReadAllText("path.txt");
            //File.WriteAllText("anotherPath.txt", content);

            //var contentLines = File.ReadLines("path.txt");//IEnumerable<string> vietoj var  - gali buti
            //for (int i = 0; i < contentLines.Count(); i++)
            //{
            //    if (contentLines.ElementAt(i).Contains("Main"))
            //    {
            //        Console.WriteLine($"Main metodas prasideda eiluteje  {i + 1}");//+1 nes prasideda nuo 0 tik kompai
            //    }
            //}




            #endregion
            //string userCardInput = Console.ReadLine();
            //string userPinInput = Console.ReadLine();

            //User userSelected = users.SingleOrDefault(user => user.CardNumber == userCardInput && user.PIN == userPinInput);//vienas atrinktas
            //tiktu toks koks yra, jei nebutu papildomu reikalavimu

            // ===================== BEGINNING ===================== 
            User userSelected;
            bool loggedIn = Login(users, out userSelected);//LOGIN METHOD


            Console.Clear();
            if (loggedIn)
            {
                // You can now access the user who has logged in using userSelected
                Console.WriteLine("User has logged in: " + userSelected.CardNumber);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();


                Menu(userSelected);
            }



            // ================================================= END OF MAIN =============================================   
        }
        // ===================================================== METHODS =================================================

        public static bool Login(List<User> users, out User userSelected)
        {
            bool isLoggedIn = false;
            int attemptsToLogin = 0;
            int maxAttemptsToLogin = 3;
            string userCardInput;
            string userPinInput;

            do
            {
                Console.Clear();
                Console.WriteLine("Please insert your card!");
                userCardInput = Console.ReadLine();

                userSelected = users.SingleOrDefault(user => user.CardNumber == userCardInput);

                if (userSelected != null)
                {
                    Console.WriteLine("Enter PIN number:");
                    userPinInput = Console.ReadLine();

                    if (userPinInput == userSelected.PIN)
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

            Console.WriteLine($"User has logged in:  {userSelected.CardNumber}");

            return isLoggedIn;


        }

        public static void Menu(User userSelected)
        {
            Console.WriteLine(
                "╔══════════════════════════════════════════╗" + "\r\n" +
                "║        WELCOME TO YOUR ATM               ║\r\n" +
                "║                                          ║\r\n" +
                "║   1. Show Balance                        ║\r\n" +
                "║   2. Show Transactions                   ║\r\n" +
                "║   3. Withdraw                            ║\r\n" +
                "║   4. Deposit                             ║\r\n" +
                "║   5. Quit                                ║\r\n" +
                "║                                          ║\r\n" +
                "║   Please select an option by entering    ║\r\n" +
                "║   the number, then press [Enter].        ║\r\n" +
                "║                                          ║\r\n" +
                "╚══════════════════════════════════════════╝");

            string userMenuChoice = Console.ReadLine();
            switch (userMenuChoice)
            {
                case ("1"):
                    userSelected.ShowBalance();
                    break;
                case ("2"):
                    userSelected.PrintRecentTransactions();
                    break;
                case ("3"):
                    userSelected.Withdraw();
                    break;
                case ("4"):
                    userSelected.Deposit();
                    break;
                case ("5"):
                    Quit();
                    break;
                case ("quit"):
                    Quit();
                    break;

            }
        }

        public static void KickOut()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You've been disconnected");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static void Quit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you. Come again.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static string DisplayEachUserData(List<User> users)
        {
            StringBuilder result = new StringBuilder();

            foreach (User user in users)
            {
                result.AppendLine($"{user.CardNumber}, PIN: {user.PIN}, Balance: {user.Balance}, Daily Limit: {user.DailyLimit}");
            }

            return result.ToString();
        }

        // ================================================= END OF METHODS ==============================================


    }
}