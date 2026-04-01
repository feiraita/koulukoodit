public class User {
    public int userId { get; set; }
    public string fName { get; set; }
    public string lName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User() { }

    public User(int userId, string fName, string lName, string email, string password) {
        this.userId = userId;
        this.fName = fName;
        this.lName = lName;
        this.Email = email;
        this.Password = password;
    }
}