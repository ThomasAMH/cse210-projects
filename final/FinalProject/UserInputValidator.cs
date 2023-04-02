static class UserInputValidator {
//Validator takes an input string from the user and will continually prompt the user until they enter the escape string

    //The returned user values, cleared when each validator is called

    private static ValidatedUserInput validatedInput;
    private static string escapeString = "Q!";
    
    //This is the string used in subsequent attmepts to get the correct user input
    private static string unvalidatedUserString = "";

//Public validator functions return the validatedInput object
    //The ClearValidatedInput and IsEscapeString functions are called at the beginning of every public method
    public static ValidatedUserInput ValidateIntegerInRange(int lowerBound, int upperBound, string promptString, string argUserString) {
        
        //Pre-validation steps
        unvalidatedUserString = argUserString;
        ClearValidatedInput();

        //Validation loop: will keep putting user input through all checks until they are all passed
        while(true)
        {
            //Check for escape string
            if(IsEscapeString(unvalidatedUserString)) {validatedInput.isEscapeString = true; return validatedInput;}
            
            //Validate
            if(!IsInteger(promptString, unvalidatedUserString)) {continue;}
            if(int.Parse(unvalidatedUserString) < lowerBound || int.Parse(unvalidatedUserString) > upperBound) {
                Console.WriteLine($"That's not a valid input! Your input must be between {lowerBound} and {upperBound}.");
                Console.WriteLine($"(Press Enter to continue, or type {escapeString} to quit)");
                Console.ReadLine();

                Console.Clear();
                Console.Write(promptString);
                unvalidatedUserString = Console.ReadLine();
                continue;
            } else {
                validatedInput.validatedUserInt = int.Parse(unvalidatedUserString);
                return validatedInput;
            }
        }
    }

    public static ValidatedUserInput ValidateDouble(string promptString, string argUserString) {
        //Pre-validation steps
        unvalidatedUserString = argUserString;
        ClearValidatedInput();

        //Validation loop: will keep putting user input through all checks until they are all passed
        while(true)
        {
            //Check for escape string
            if(IsEscapeString(unvalidatedUserString)) {validatedInput.isEscapeString = true; return validatedInput;}
            
            //Validate
            if(!IsDouble(promptString, unvalidatedUserString)) {continue;}
            if(double.Parse(unvalidatedUserString) <= 0) {
                Console.WriteLine($"That's not a valid input! Your input must be greater than 0.00. Do not include units!");
                Console.WriteLine($"(Press Enter to continue, or type {escapeString} to quit)");
                Console.ReadLine();

                Console.Clear();
                Console.Write(promptString);
                unvalidatedUserString = Console.ReadLine();
                continue;
            } else {
                validatedInput.validatedUserDouble = double.Parse(unvalidatedUserString);
                return validatedInput;
            }
        }
    }

    public static ValidatedUserInput ValidateStringIsNotEmpty(string promptString, string argUserString) {
    
        //Pre-validation steps
        unvalidatedUserString = argUserString;
        ClearValidatedInput();

        //Validation loop: will keep putting user input through all checks until they are all passed
        while(true)
        {
            //Check for escape string
            if(IsEscapeString(unvalidatedUserString)) {validatedInput.isEscapeString = true; return validatedInput;}
            
            //Validate
            if(String.IsNullOrWhiteSpace(unvalidatedUserString)) {
                Console.WriteLine($"That's not a valid input! This is a required field, so you need to enter something.");
                Console.WriteLine($"(Press Enter to continue, or type {escapeString} to quit)");
                Console.ReadLine();

                Console.Clear();
                Console.Write(promptString);
                unvalidatedUserString = Console.ReadLine();
                continue;
            } else {
                validatedInput.validatedNonEmptyString = unvalidatedUserString;
                return validatedInput;
            }
        }
    }


//Helper Functions
    private static bool IsInteger(string promptString, string argUserString) {
        //Continually prompts user for valid integer unless they enter the escape string.
        while(true) {
            try {
                validatedInput.validatedUserInt = int.Parse(argUserString);
                return true;
            } catch {
                Console.WriteLine($"That's not a valid input! Your input must be an integer.");
                Console.WriteLine($"(Press Enter to continue, or type {escapeString} to quit)");
                Console.ReadLine();

                Console.Clear();
                Console.Write(promptString);
                unvalidatedUserString = Console.ReadLine();
                return false;
            }
        }
    }

    private static bool IsDouble(string promptString, string argUserString) {
        //Continually prompts user for valid double unless they enter the escape string.
        while(true) {
            try {
                double.Parse(argUserString);
                return true;
            } catch {
                Console.WriteLine($"That's not a valid input! Your input must be an number.");
                Console.WriteLine($"(Press Enter to continue, or type {escapeString} to quit)");
                Console.ReadLine();

                Console.Clear();
                Console.Write(promptString);
                unvalidatedUserString = Console.ReadLine();
                return false;
            }
        }
    }
    public static bool IsEscapeString(string argUserString) {
        if(argUserString == escapeString) {return true;}
        else {return false;}
    }

    private static void ClearValidatedInput() {
        validatedInput.isEscapeString = false;
        validatedInput.validatedUserInt = 0;
        validatedInput.validatedNonEmptyString = "";
        validatedInput.validatedUserDouble = 0;
    }
}