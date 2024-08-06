using SWAD_Assignment2_Team3;

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Option1();
            }
            else if (input == "2")
            {
                Option2();
            }
            else if (input == "3")
            {
                Option3();
            }
            else if (input == "4")
            {
                exit = true;
                Console.WriteLine("Exiting the program...");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }

    static void Option1()
    {
        Console.WriteLine("You selected Option 1.");
        // Add your logic for Option 1 here
    }

    static void Option2()
    {
        Console.WriteLine("You selected Option 2.");
        // Add your logic for Option 2 here
    }

    static void Option3()
    {
        Console.WriteLine("You selected Option 3.");
        // Add your logic for Option 3 here
    }
