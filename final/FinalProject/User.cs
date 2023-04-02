using System.Text;
static class User {
    static private string _userName = "Default";
    static private List<Recipe> _userRecipes = new List<Recipe>();
    static private List<Ingredient> _userIngredients = new List<Ingredient>();
    static private int _nextIngredientID = 0;
    static private bool _isDefaultUser = true;

    //Increment each time this is accessed
    static public int GetNextIngredientID() {
        _nextIngredientID = _nextIngredientID + 1;
        return _nextIngredientID;
    }

    static public bool IsDefaultUser() {
        return _isDefaultUser;
    }

    static public void SetNewUser(string userName) {
        ValidatedUserInput validatedUserInput;
        string promptString = "Looks like you're new around here. Should we make you a profile? \n" + "1. Yes \n" + "2. No\n";

        Console.WriteLine(promptString);
        string userInput = Console.ReadLine();

        validatedUserInput = UserInputValidator.ValidateIntegerInRange(1, 2, promptString, userInput);

        if(validatedUserInput.isEscapeString) {return;}

        switch(validatedUserInput.validatedUserInt) {
            case 1:
                Console.WriteLine($"Alright! I'll see to it. (Press Enter to continue)");
                Console.ReadLine();
                FileManipulator fm = new FileManipulator();
                fm.CreateUserFolder(userName);
                _userName = userName;
                _isDefaultUser = false;
                
            break;
            case 2:
                Console.WriteLine("Very well. See you later!");
                Console.ReadLine();
            break;
            default:
                Console.WriteLine("Error in User! How did you get here??");
            break;
        }
    }

    static public void LoadUser(string userName) {
        FileManipulator fmanip = new FileManipulator();
        _userName = userName;

        LoadIngredients();
        
        _nextIngredientID = _userIngredients[_userIngredients.Count-1].getID();
        _isDefaultUser = false;
    }

    static private void LoadIngredients() {
        FileManipulator fm = new FileManipulator();
        fm
    }

    static public void AddIngredient(Ingredient newIngredient) {
        //This adds the ingredient to the array of ingredients, then calls the "autosave" feature to rewrite user's ingredients file to reflect the current array.
        _userIngredients.Add(newIngredient);
        FileManipulator fm = new FileManipulator();
        fm.UpdateIngredientFile(_userIngredients);
    }

    static public void ViewIngredients() {
        //Display a list of each ingredient, let the user pick one, then display the details for it.
        
        string userInput;
        string prompt = "Select an ingredient to see more details on: \n" + GetIngredientsList();
        ValidatedUserInput validatedUserInput;

        Console.Write(prompt);
        userInput = Console.ReadLine();
        validatedUserInput = UserInputValidator.ValidateIntegerInRange(1, _userIngredients.Count(), prompt, userInput);
        
        if(validatedUserInput.isEscapeString) {return;}
        
        //Display selected ingredient's statinro
        Console.Write("Name: " + _userIngredients[validatedUserInput.validatedUserInt - 1].getName() + "\n"); 
        Console.Write("Brand: " + _userIngredients[validatedUserInput.validatedUserInt - 1].getBrand() + "\n");
        Console.Write("Price: " + _userIngredients[validatedUserInput.validatedUserInt - 1].getPrice() + "\n");
        Console.Write("Notes: " + _userIngredients[validatedUserInput.validatedUserInt - 1].getNotes() + "\n");
        Console.WriteLine("Press Enter to return to the menu");
        Console.ReadLine();
    }

    private static string GetIngredientsList() {
        StringBuilder sb = new StringBuilder();
        int i = 1;

        foreach(Ingredient ing in _userIngredients) {
            sb.Append(i + ". " + ing.getName() + "\n");
        }

        return sb.ToString();
    }
    static public string GetUsername() {return _userName;}
}