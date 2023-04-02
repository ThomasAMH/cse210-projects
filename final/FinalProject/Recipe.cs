using System.Text;
using System.Text.Json;
class Recipe {
    private string _name = "";
    //Index of ingredient and quantity
    private IDictionary<int, Quantity> _ingredientIndexAndQuantity = new Dictionary<int, Quantity>();
    private double _servings = 0.0;
    private string _userNotes = "";
    private List<string> _labels = new List<string>();
    private int _recipeID;

    ValidatedUserInput validatedUserInput;

    public Recipe() {
        Console.Clear();
        setName();
        Console.Clear();
        setLabels();
        Console.Clear();
        setNotes();
        Console.Clear();
        setID();
    }

    //Setters and Getters. Setters handle the interface while getters only return the value of the property
    //Organized in the method they are called in constructor: name, servings, labels, notes, ingredients
    public void setName() {
        string promptString;

        //Modify interaction slightly if name is already set
        //newline characters are used to support multi or single line prompts with Console.Write
        if(_name == "") {
            promptString = "(Required) Ingredient name:" + "\n";
        }
        else {
            promptString = "Enter the new name for " + _name + ":\n";
        }

        //Set name with validation
        //newline characters are used to support multi or single line prompts with Console.Write
        Console.Write(promptString);
        string userInput;
        userInput = Console.ReadLine();

        //Validate user input, and set property if exit string is not provided.
        ValidatedUserInput validatedUserInput;

        validatedUserInput = UserInputValidator.ValidateStringIsNotEmpty(promptString, userInput);
        
        if(validatedUserInput.isEscapeString) {return;}
        _name = validatedUserInput.validatedNonEmptyString;
    }

     public string getName() {
        return _name;
     }
     
    public void setServings() {
        //Set _servings with validation
        string promptString = "";
        ValidatedUserInput validatedUserInput;

        if(_servings <= 0) {
            promptString = "(Required) Number of servings/helpings (no units):" + "\n";
        }
        else {
            promptString = "Enter the new number of servings for this dish:" + "\n" + "Current quantity: " 
            + _servings.ToString() + "\n";
        }

        //Validate user input, and set property if exit string is not provided.

        validatedUserInput = UserInputValidator.ValidateDouble(promptString, Console.ReadLine());
        
        if(validatedUserInput.isEscapeString) {return;}
        _servings = validatedUserInput.validatedUserDouble;
    }

    public double getServings() {
        return _servings;
    }
    
    public void setLabels() {
        string userInput;
        string promptString = "";
        ValidatedUserInput validatedUserInput;
        
        //Function changes drastically if the function with existing labels/at instantiation and when modifying exisitng labels
        
        if(_labels.Count == 0) {
            promptString = "(Optional) Enter labels for this dish (enter Q! when done):" + "\n";
            Console.WriteLine(promptString);

            //Allow for multiple labels in console application.
            userInput = Console.ReadLine();
            validatedUserInput = UserInputValidator.ValidateStringIsNotEmpty(promptString, userInput);

            while(!validatedUserInput.isEscapeString) {
                validatedUserInput = UserInputValidator.ValidateStringIsNotEmpty(promptString, userInput);
                _labels.Add(validatedUserInput.validatedNonEmptyString);
                userInput = Console.ReadLine();
            }
        }
        else {
            promptString = "You can add, or remove labels here" + "\n" +
            "1. Add a label" + "\n" +
            "2. Remove a label" + "\n" +
            "Enter your selection:";

            Console.WriteLine(promptString);
            userInput = Console.ReadLine();
            validatedUserInput = UserInputValidator.ValidateIntegerInRange(1, 2, promptString, userInput);

            switch(validatedUserInput.validatedUserInt) {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter your new label:");
                    _labels.Add(Console.ReadLine());
                break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Your labels:");
                    for(int i = 0; i <=_labels.Count; i++) {
                        Console.WriteLine($"{i++}. {_labels[i]}");
                    }
                    Console.WriteLine("Enter which label you would like to remove:");
                    userInput = Console.ReadLine();

                    try {
                        _labels.RemoveAt(int.Parse(userInput) + 1);
                    }
                    catch {
                        Console.WriteLine("Invalid option!");
                        Console.ReadLine();
                    }
                break;

                default:
                    Console.WriteLine("Not a valid input!");
                break;
            }
        }
        //***Original Validation***
        // if(_labels.Count == 0) {
        //     promptString = "(Optional) Enter labels for this dish (enter Q! when done):" + "\n";
        //     Console.WriteLine(promptString);

        //     //Allow for multiple labels in console application. If no labels are entered, do not loop.
        //     _userNotes = "";
        //     userInput = Console.ReadLine();
        //     if(!String.IsNullOrWhiteSpace(userInput)) {
        //         while(true) {
        //             if(userInput == "Q!") {break;}
        //             _labels.Add(userInput);
        //             userInput = Console.ReadLine();
        //         }
        //     }
        // }
        // else {
        //     promptString = "You can add, or remove labels here" + "\n" +
        //     "1. Add a label" + "\n" +
        //     "2. Remove a label" + "\n" +
        //     "Enter your selection:";

        //     Console.WriteLine(promptString);
        //     userInput = Console.ReadLine();
        //     bool isInputValid = false;
        //     while(isInputValid)
        //     {
        //         Console.Write(promptString);
        //         userInput = Console.ReadLine();
        //         try {
        //             userInt = int.Parse(userInput);
        //         }
        //         catch {
        //             Console.WriteLine("That's not an option!");
        //             Console.ReadLine();
        //             Console.WriteLine("");
        //             continue;
        //         }            
        //     }

        //     userInt = int.Parse(userInput);
        //     switch(userInt) {
        //         case 1:
        //             Console.Clear();
        //             Console.WriteLine("Enter your new label:");
        //             _labels.Add(Console.ReadLine());
        //         break;

        //         case 2:
        //             Console.Clear();
        //             Console.WriteLine("Your labels:");
        //             for(int i = 0; i <=_labels.Count; i++) {
        //                 Console.WriteLine($"{i++}. {_labels[i]}");
        //             }
        //             Console.WriteLine("Enter which label you would like to remove:");
        //             userInput = Console.ReadLine();

        //             try {
        //                 _labels.RemoveAt(int.Parse(userInput) + 1);
        //             }
        //             catch {
        //                 Console.WriteLine("Invalid option!");
        //                 Console.ReadLine();
        //             }
        //         break;

        //         default:
        //             Console.WriteLine("Not a valid input!");
        //         break;
        //     }
        // }
    }

    public List<string> getLabels() {
        return _labels;
    }
    public void setNotes() {
        string promptString = "";
        StringBuilder sb = new StringBuilder();


        //For simplicity's sake, the user can only override the whole note when modified!
        if(_userNotes == "") {
            promptString = "(Optional) Enter any notes here (enter Q! when done):" + "\n";
        }
        else {
            promptString = "Overriding old notes: Enter any new notes here (enter Q! when done):" + "\n";
        }

        //No multi-line notes allowed.
        //No validation, only one liners
        Console.Write(promptString);
        _userNotes = Console.ReadLine();
    }

    public string getNotes() {
        return _userNotes;
    }
    
    public void setIngredients() {
        //This acts differently based on if it is being called by the constructor, or not.
        string userInput = "";
        string promptString = "";
        ValidatedUserInput validatedUserInput;

        //Constructor
        if(_ingredientIndexAndQuantity.Count() == 0) {
            Console.WriteLine("Now, let's add some ingredients!");
            promptString = "1. Add new ingredient \n 2. add existing ingredient";
            Console.WriteLine(promptString);
            userInput = Console.ReadLine();
            validatedUserInput = UserInputValidator.ValidateIntegerInRange(1, 2, promptString, userInput);
            
            if(validatedUserInput.isEscapeString) {return;}
            
            switch(validatedUserInput.validatedUserInt) {
                case 1:
                    Ingredient newIngredient = new Ingredient();
                    if(validatedUserInput.isEscapeString) {return;}
                    Quantity newQuantity = new Quantity();
                    if(validatedUserInput.isEscapeString) {return;}
                break;

                case 2:
                    Console.WriteLine("FIXME! :)");
                    Console.ReadLine();
                break;

                default:
                    Console.WriteLine("That's not an option!");
                    Console.ReadLine();
                break;
            }
        }        
    }
    public double getPrice() {
        return 0.0;
    }

    private void setID() {
        _recipeID = User.GetNextIngredientID();
    }

    public int getID() {
        return _recipeID;
    }

    public string ConvertToJSON() {
        return JsonSerializer.Serialize<Recipe>(this);
    }
}