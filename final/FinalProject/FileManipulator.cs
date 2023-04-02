using System.Text;
class FileManipulator {
    //The purpose of this class is to let the program interact with the files saved in relation to the user.
    //It should only be called in initially loading the program, as well as when performing CRUD operations on files
    //In which case, for simplicity's sake, the whole file is rewritten from the data in the User class


    //Searches for folder in parent directory (fix that later) that matches the user's name
    //Then, in that folder, read the ingredients, quantities, etc. from files matching the file names here:

    private const string INGREDIENT_FILE_NAME = "Ingredients.kkit";
    private const string RECIPIE_FILE_NAME = "Recipies.kkit";
    private const string USER_DATA = "UserData.kkit";
    private const string USER_FOLDER_APPEN = "-data";

    public List<Ingredient> ReadIngredientsFromFile(string userName) {
        List<Ingredient> list = new List<Ingredient>();
        string[] fileData = File.ReadAllLines("./UserData/" + userName + USER_FOLDER_APPEN + "/" + INGREDIENT_FILE_NAME)

        foreach(string s in fileData) {
            
        }
    }

    public bool DoesUserFolderExist(string userName) {
        //The following is used when reading the user files
        const string FILE_PREFIX = "-./UserData\\";
        string[] filesInDir = Directory.GetDirectories("./UserData");

        //Data returns in form: ./UserData\\name-data
        foreach (string s in filesInDir) {
            if(s.Substring(FILE_PREFIX.Length - 1) == userName + USER_FOLDER_APPEN) {return true;}
        }
            return false;
    }

    public void CreateUserFolder(string userName) {
        Directory.CreateDirectory("./UserData/" + userName + USER_FOLDER_APPEN);
    }

    public void UpdateIngredientFile(List<Ingredient> currentUserList) {        
        StringBuilder sb = new StringBuilder();
        
        foreach(Ingredient ing in currentUserList) {
            sb.Append(ing.StringifyObject());
        }
        File.WriteAllText("./UserData/" + User.GetUsername() + USER_FOLDER_APPEN + "/" + INGREDIENT_FILE_NAME, sb.ToString());
    }
    public void UpdateReceipeFile() {
        
    }
}