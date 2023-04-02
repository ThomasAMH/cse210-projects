class Quantity {
    private double _quantity = 0;
    private string _unit = "";
    private bool isValid = true;
    public Quantity() {
        Console.Clear();
        setQuantity();
        Console.Clear();
        setUnit();
    }
        public void setQuantity() {
        //Set _quantity with validation
        string promptString = "";
        string userInput = "";
        ValidatedUserInput validatedUserInput;

        if(_quantity <= 0) {
            promptString = "(Required) Ingredient quantity (no units):" + "\n";
        }
        else {
            promptString = "Enter the new quantity (no units) for this ingredient:" + "\n" + "Current quantity: " 
            + _quantity.ToString() +" " +_unit +"\n";
        }

            Console.Write(promptString);
            userInput = Console.ReadLine();
            validatedUserInput = UserInputValidator.ValidateDouble(promptString, userInput);
            if(validatedUserInput.isEscapeString) {isValid = false; return;}
            _quantity = validatedUserInput.validatedUserDouble;
        }


     public double getQuantity() {
        return _quantity;
     }

    public void setUnit() {
        string promptString;

        //Modify interaction slightly if name is already set
        //newline characters are used to support multi or single line prompts with Console.Write
        if(_unit == "") {
            promptString = "(Required) unit name in singular (cup, not cups):" + "\n";
        }
        else {
            promptString = "Enter the new name for " + _unit + " in the singular (cup, not cups): \n";
        }

        //Set name with validation
        //newline characters are used to support multi or single line prompts with Console.Write
        Console.Write(promptString);
        string userInput;
        ValidatedUserInput validatedUserInput;
        userInput = Console.ReadLine();
        validatedUserInput = UserInputValidator.ValidateStringIsNotEmpty(promptString, userInput);
        if(validatedUserInput.isEscapeString) {isValid = false; return;}

        _unit = validatedUserInput.validatedNonEmptyString + "(s)";
    }

    public string getUnit(){
        return _unit;
    }
}