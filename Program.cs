namespace L2___Cash_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== TO DO =====
            //get; set - del privatumo
            //

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
            //X XX XXX
            //b69d8293 - 7b62 - 4520 - 93aa - 3ece99882036
            //8c5eb7d6 - 3ae3 - 452a - b551 - 283fc20d9253
            //eb311901-4582-481a-b697-13b52e4d2349
            //c88e180e-b996-40eb-8f38-98abc8db2ba1
            //f3b5228d-937f-4407-af03-d0bce35ae269




            Console.Clear();
            //welcome menu

            Console.WriteLine(
                "╔══════════════════════════════════════════╗" + "\r\n" +
                "║        WELCOME TO YOUR ATM               ║\r\n" +
                "║                                          ║\r\n" +
                "║   1. Show Balance                        ║\r\n" +
                "║   2. Show Transactions                   ║\r\n" +
                "║   3. Withdraw                            ║\r\n" +
                "║   4. Logout                              ║\r\n" +
                "║   5. Quit                                ║\r\n" +
                "║                                          ║\r\n" +
                "║   Please select an option by entering    ║\r\n" +
                "║   the number, then press [Enter].        ║\r\n" +
                "║                                          ║\r\n" +
                "╚══════════════════════════════════════════╝");


            // ================================================= END OF MAIN =================================================   
        }
        // ===================================================== METHODS =================================================

        #region ColorMethods
        public static void Clear()
        {
            Console.Clear();
        }
        //------------meth
        public static void ColorYellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        //------------meth
        public static void ColorRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        //------------meth
        public static void ColorGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        //------------meth
        public static void ResetClr()
        {
            Console.ResetColor();
        }
        //------------meth
        #endregion

        // ================================================= END OF METHODS ==============================================


    }
}