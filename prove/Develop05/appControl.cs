using System.Text.Json;
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
            WriteUserToFile();
            Console.WriteLine(" 1. View Goals");
            Console.WriteLine(" 2. New Goal");
            Console.WriteLine(" 3. Update Goal");
            Console.WriteLine(" 4. View User Points");
            Console.WriteLine(" 5. Toggle Gamification");
            Console.WriteLine(" 6. Quit");
            Console.WriteLine("Select a choice from the menu by entering the corrisponding number:");
            userInt = int.Parse(Console.ReadLine());

            switch(userInt) {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Sure thing. What kind of goals do you want to see?");
                    Console.WriteLine(" 1. Simple Goals");
                    Console.WriteLine(" 2. Eternal Goals");
                    Console.WriteLine(" 3. Checklist Goals");
                    Console.WriteLine(" 4. All Non-Completed Goals");
                    Console.WriteLine(" 5. Completed Goals");
                    Console.WriteLine(" 6. Back");
                    userInt = int.Parse(Console.ReadLine());
                    switch(userInt) {
                        case 1:
                            activeUser.DisplayGoalOfType("Simple");
                            break;
                        case 2:
                            activeUser.DisplayGoalOfType("Eternal");
                            break;
                        case 3:
                            activeUser.DisplayGoalOfType("Checklist");
                            break;
                        case 4:
                            activeUser.DisplayGoalOfType("Simple");
                            activeUser.DisplayGoalOfType("Eternal");
                            activeUser.DisplayGoalOfType("Checklist");
                            break;
                        case 5:
                            activeUser.DisplayCompletedGoals();
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                    break;
                case 2:
                    activeUser.NewGoal();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("As you wish. What kind of goal do you want to update?");
                    Console.WriteLine(" 1. Simple Goals");
                    Console.WriteLine(" 2. Eternal Goals");
                    Console.WriteLine(" 3. Checklist Goals");
                    Console.WriteLine(" 4. Back");
                    userInt = int.Parse(Console.ReadLine());
                    switch(userInt) {
                        case 1:
                            activeUser.DisplayGoalOfType("Simple");
                            Console.WriteLine("Now, enter the number of the goal you'd like to modify:");
                            userInt = int.Parse(Console.ReadLine());
                            activeUser.UpdateGoal("Simple", userInt);
                            break;
                        case 2:
                            activeUser.DisplayGoalOfType("Eternal");
                            Console.WriteLine("Now, enter the number of the goal you'd like to modify:");
                            userInt = int.Parse(Console.ReadLine());
                            activeUser.UpdateGoal("Eternal", userInt);
                            break;
                        case 3:
                            activeUser.DisplayGoalOfType("Checklist");
                            Console.WriteLine("Now, enter the number of the goal you'd like to modify:");
                            userInt = int.Parse(Console.ReadLine());
                            activeUser.UpdateGoal("Checklist", userInt);
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                    break;
                case 4:
                    activeUser.DisplayPoints();
                    break;
                case 5:
                    activeUser.ToggleGamification();
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
        Console.Clear();
        Console.WriteLine("What is the user's name?");
        string userString = Console.ReadLine();
        List<string> fileData = new List<string>();

        // try {
            foreach(string line in System.IO.File.ReadLines(userString+".txt")) {
                fileData.Add(line);
            }
            activeUser = new User(fileData);
            Console.WriteLine("Welcome, " + activeUser.userName + "!");
            Console.WriteLine("Press Enter to continue");
            string unused = Console.ReadLine();

        // } catch {
        //     Console.WriteLine("I have no data on a user with that name!");
        //     Console.WriteLine("Press Enter to continue");
        //     string unused = Console.ReadLine();
        // }


    }

    private async void WriteUserToFile() {
        string objectString = activeUser.PackageObject();
        await File.WriteAllTextAsync(activeUser.userName+".txt", objectString);
    }
}