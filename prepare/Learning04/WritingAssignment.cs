class WritingAssignment : Assignment {
    private string _title;

    public WritingAssignment(string userStudentName, string userSubject, string userTitle) : base(userStudentName, userSubject) {
        _title = userTitle;
    }

    public string GetWritingInformation() {return _title;}
}