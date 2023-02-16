class MathAssignment : Assignment {
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string userStudentName, string userSubject, string userTextbookSection, string userProblems) : base(userStudentName, userSubject) {
        _textbookSection = userTextbookSection;
        _problems = userProblems;
    }
    public string GetHomeworkList() {
        return (_textbookSection + " " + _problems);
        }
}