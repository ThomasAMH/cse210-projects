using System;

//Main program
class KKitchen_Main
{
    static void Main(string[] args)
    {
        Console.Clear();            

        Console.WriteLine("Hello, and welcome to KKitchen: your one-stop shop for meal planning! (Press Enter to continue)");
        Console.ReadLine();
        Console.WriteLine("Let's get you set up. What's your name?");

        string promptString = "What's your name? \n";
        string userInput = Console.ReadLine();

        ValidatedUserInput validatedUserInput;
        validatedUserInput = UserInputValidator.ValidateStringIsNotEmpty(promptString, userInput);
        
        
        //Attempt to load the user, and, if it fails, set up a new one.
        FileManipulator fm = new FileManipulator();

        if(!fm.DoesUserFolderExist(validatedUserInput.validatedNonEmptyString)) {
            User.SetNewUser(validatedUserInput.validatedNonEmptyString);
        } else {
            User.LoadUser(validatedUserInput.validatedNonEmptyString);
        }
        //If the user is still default, quit
        if(User.IsDefaultUser()) {return;}

        //Main Menu
        Console.Clear();
        string menuMainOptions = "1. My Recipies \n" + "2. My Ingredients \n"+  "3. Meal Planning \n";

        while(true) {
            Console.WriteLine(menuMainOptions);
            userInput = Console.ReadLine();
            validatedUserInput = UserInputValidator.ValidateIntegerInRange(1, 3, menuMainOptions, userInput);

            if(validatedUserInput.isEscapeString) {return;}

            switch(validatedUserInput.validatedUserInt) {
                //Recipies Menu
                case 1:
                    Console.Clear();
                    string recipeMenuOptions = "1. Add Recipies\n" + "2. View Recipies\n" + "3. Modify Recipies\n" + "4. Remove Recipies\n";
                    Console.Write(recipeMenuOptions);
                    userInput = Console.ReadLine();
                    validatedUserInput = UserInputValidator.ValidateIntegerInRange(1, 4, recipeMenuOptions, userInput);

                    if(validatedUserInput.isEscapeString) {return;}

                    //Recipies Submenu
                    switch(validatedUserInput.validatedUserInt) {
                        case 1:

                        break;

                        case 2:

                        break;

                        case 3:

                        break;

                        case 4:

                        break;

                        default:

                        break;
                    }
                break;

                //Ingredients menu
                case 2:
                    Console.Clear();
                    string ingredientMenuOptions = "1. Add Ingredients\n" + "2. View Ingredients\n" + "3. Modify Ingredients\n" + "4. Remove Ingredients\n";
                    Console.Write(ingredientMenuOptions);
                    userInput = Console.ReadLine();
                    validatedUserInput = UserInputValidator.ValidateIntegerInRange(1, 4, ingredientMenuOptions, userInput);

                    if(validatedUserInput.isEscapeString) {return;}
                    switch(validatedUserInput.validatedUserInt) {
                        case 1:
                            Ingredient newIngredient = new Ingredient();
                            User.AddIngredient(newIngredient);                            
                        break;

                        case 2:


                        break;

                        case 3:

                        break;

                        case 4:

                        break;

                        default:

                        break;
                    }
                break;
                    
                case 3:
                    
                break;
                    
                default:
                    
                break;
            }
        }
    }
                        // case 1:

                        // break;

                        // case 2:

                        // break;

                        // case 3:

                        // break;

                        // case 4:

                        // break;

                        // default:

                        // break;
}