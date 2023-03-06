class appControl {
    private int userInt;

    bool continueExecution = true;
    User activeUser = null;

    public void RunApplication() {
        while(continueExecution) {
            DisplayMenu();
        }
    }
    private void DisplayMenu() {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        if(activeUser == null) {
            Console.WriteLine(" 1. Load User");
            Console.WriteLine(" 2. New User");
            Console.WriteLine(" 3. Quit");
            Console.WriteLine("Select a choice from the menu by entering the corrisponding number:");
            userInt = int.Parse(Console.ReadLine());

            switch(userInt) {
                case 1:
                    LoadUserFromFile();
                    break;
                case 2:
                    activeUser = new User();
                    break;
                case 3:
                    continueExecution = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                break;
            }
        }

        else {
            Console.WriteLine(" 1. View Goals");
            Console.WriteLine(" 2. New Goal");
            Console.WriteLine(" 3. Update Goal");
            Console.WriteLine(" 4. View User Stats");
            Console.WriteLine(" 5. Toggle Gamification");
            Console.WriteLine(" 6. Quit");
            Console.WriteLine("Select a choice from the menu by entering the corrisponding number:");
            userInt = int.Parse(Console.ReadLine());

            switch(userInt) {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    continueExecution = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
    
    private void LoadUserFromFile() {

    }

    private void WriteUserToFile() {

    }

    private string UserToJSON() {
        string UserJSON;
        
        return UserJSON;
    }
}