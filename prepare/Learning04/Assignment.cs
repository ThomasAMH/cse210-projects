class Assignment {
    protected string _studentName;
    protected string _topic;

    public Assignment(string userName, string userTopic) {
        _studentName = userName;
        _topic = userTopic;
    }

    public string GetSummary() {return (_studentName + " - " + _topic);}
}