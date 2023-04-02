using System.Text;
class Ingredient {
    private string _brand = "";
    private string _name = "";
    private double _price = -0.01;
    private List<int> _recipiesIncludedIn = new List<int>();
    private string _userNotes = "";
    private int _ingredientID;
    private bool _isValid = true;

    public Ingredient() {
        Console.Clear();
        setName();
        Console.Clear();
        setPrice();
        Console.Clear();
        setBrand();
        Console.Clear();
        setNotes();
        Console.Clear();
        setID();
    }

    public Ingredient(string name, string brand, double price, List<int> includedIn, string userNotes, int id, bool isValid) {
        _name = name;
        _brand = brand;
        _price = price;
        _recipiesIncludedIn = includedIn;
        _userNotes = userNotes;
        _ingredientID = id;
        _isValid = isValid;
    }

    public void UseInRecipe(int recipeToAddIndex) {
        _recipiesIncludedIn.Add(recipeToAddIndex);
    }

    public void RemoveFromRecipe(int recipeToRemoveFromIndex) {
        _recipiesIncludedIn.Remove(recipeToRemoveFromIndex);
    }

    //Setters and Getters. Setters handle the interface while getters only return the value of the property
    //Organized in the method they are called in constructor: name, price, brand, notes
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
        
        if(validatedUserInput.isEscapeString) {isValid = false; return;}
        _name = validatedUserInput.validatedNonEmptyString;
    }

     public string getName() {
        return _name;
     }

     public void setPrice() {
        //Set _price with validation
        string promptString = "";
        string userInput = "";
        ValidatedUserInput validatedUserInput;

        if(_price <= 0) {
            promptString = "(Required) Price of this ingredient (no units): \n";
        }
        else {
            promptString = "Enter the new number of servings for this dish: \n Current quantity: " 
            + _price.ToString() + "\n";
        }

        Console.Write(promptString);
        userInput = Console.ReadLine();
        
        //Validate user input, and set property if exit string is not provided.
        validatedUserInput = UserInputValidator.ValidateDouble(promptString, userInput);
        

        if(validatedUserInput.isEscapeString) {isValid = false; return;}
        _price = validatedUserInput.validatedUserDouble;
    }

    public double getPrice() {
        return _price;
    }

    public void setBrand() {
        string userInput;
        string promptString;
        if(_brand == "") {
            promptString = "(Optional) Brand name:" + "\n";
        }
        else {
            promptString = "Enter the new brand. Old value:" + _brand + "\n";
        }

        //Brand requires no validation.
        Console.Write(promptString);
        userInput = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(userInput)) {_brand = "None";} else {_brand = userInput;}
    }

    public string getBrand() {
        return _brand;
    }
    public void setNotes() {
        string promptString = "";
        StringBuilder sb = new StringBuilder();


        //For simplicity's sake, the user can only override the whole note when modified!
        if(_userNotes == "") {
            promptString = "(Optional) Enter any notes here (Press Enter when done!):" + "\n";
        }
        else {
            promptString = "Overriding old notes: Enter any new notes here (Press Enter when done!):" + "\n";
        }

        //No multi-line notes allowed.
        //No validation, only one liners
        Console.Write(promptString);
        _userNotes = Console.ReadLine();
    }

    public string getNotes() {
        return _userNotes;
    }

    //This looks at the user object and gets the next available ingredient ID.
    private void setID() {
        _ingredientID = User.GetNextIngredientID();
    }

    public int getID() {
        return _ingredientID;
    }

    public string StringifyObject() {
        //Due to not being able to get the JSON library working, I created this temporary solution of writing each property to a string

    // private string _brand = "";
    // private string _name = "";
    // private double _price = -0.01;
    // Length of _RecipiesIncludedIn
    // private List<int> _recipiesIncludedIn = new List<int>();
    // private string _userNotes = "";
    // private int _ingredientID;
    // private bool isValid = true;

    StringBuilder sb = new StringBuilder();

    sb.Append(_brand + "\n");
    sb.Append(_name + "\n");
    sb.Append(_price  + "\n");
    sb.Append(_recipiesIncludedIn.Count + "\n");
    
    foreach(int i in _recipiesIncludedIn) {
        sb.Append(i + "\n");
    }


    sb.Append(_userNotes + "\n");
    sb.Append(_ingredientID + "\n");
    sb.Append(true + "\n");

    return sb.ToString();
    }
}