public abstract class Goal {
    public string goalText;
    protected string description;
    public bool isCompleted;
    protected int pointValue;

    public virtual void RecordEvent(User associatedUser) {
        isCompleted = true;
        Console.WriteLine("Action recorded!");
        associatedUser.pointsTotal += pointValue;
    }

    public virtual void PrintIsCompleteString() {
        if(isCompleted) {
            Console.Write("[X]");
        } else {
            Console.Write("[ ]");
        }
    }

    public virtual string StringifyObject() {
        //Store data in accordinace with the object structure found in objectStructure.txt
        string stringifiedObject = "";
        stringifiedObject += goalText + "\n";
        stringifiedObject += isCompleted.ToString() + "\n";
        stringifiedObject += pointValue.ToString();

        return stringifiedObject;
    }
}