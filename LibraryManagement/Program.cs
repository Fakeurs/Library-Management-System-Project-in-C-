using System.Text;
using System.Text.RegularExpressions;
// user choice to login as admin or simple member
Console.WriteLine("Choose how do you want to log in (admin or member)");
string role;
while (true)
{
    role = Console.ReadLine().ToLower();
    if (role == "member")
    {
        Console.WriteLine("Please log in as a member.");
        break;
    }
    if (role == "admin")
    {
        Console.WriteLine("Please log in as an admin.");
        break;
    }
    Console.WriteLine("Invalid role, please re-input.");
}

// user login based on role. If role = member, user can create an account.
if (role == "admin")
{
    // Log in as admin
    
}
else
{
    // Log in as simple member
    MemberLogin();
}

void MemberLogin()
{
    Console.WriteLine("Do you already have an account? (yes/no)");
    bool isMember;
    while (true)
    {
        var response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            // Log in
            Console.WriteLine("Alright, then let's login :)");
            isMember = true;
            break;
        }
    
        if (response == "no")
        {
            // Register
            Console.WriteLine("Alright, let's create an account then :)");
            isMember = false;
            break;
        }
    
        Console.WriteLine("Incorrect response, please enter yes or no.");
    }
    
    if (isMember)
    {
        // Log in
        Console.Write("Please enter your username: ");
        string username;
        while (true)
        {
            username = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
            {
                Console.Write("Invalid username. Please re-input: ");
            }
            else
            {
                break;
            }
        }
    
        Console.Write("Please enter your password: ");
        string password;
        while (true)
        {
            password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.Write("Incorrect password, password can't be empty, please re-input: ");
            }
            else
            {
                break;
            }
        }
        //TODO: Validate if username and password matches specific user in database.
        LogIn(username, password);
    }
    else
    {
        // Register giving details for: username, email, firstname, lastname, password
        Console.Write("Please enter a username: ");
        string username;
        while (true)
        {
            username = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
            {
                Console.Write("Invalid username. Please re-input: ");
            }
            else
            {
                //TODO: Check username in database; username should be unique
                break;
            }
        }

        Console.Write("Please enter an email: ");
        string email;
        while (true)
        {
            email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.Write("Invalid email. Please re-input: ");
            }
            else
            {
                var success = ValidateEmail(email);
                if (success)
                {
                    //TODO: Validate if email doesn't exist yet in database.
                    break;
                }
                Console.Write("Invalid email, please re-input: ");
            }
        }

        Console.Write("Please enter a password: ");
        string password;
        while (true)
        {
            password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.Write("Invalid password. Please re-input: ");
            }
            else
            {
                var success = ValidatePassword(password);
                if (success)
                {
                    break;
                }
                Console.Write("Invalid password, please re-input: ");
            }
        }

        Console.Write("Please enter first name: ");
        string firstName;
        while (true)
        {
            firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                Console.Write("Invalid firstname. Please re-input: ");
            }
            else
            {
                break;
            }
        }
        //TODO: Validate password (double check)
        Console.Write("Please enter last name: ");
        string lastName;
        while (true)
        {
            lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.Write("Invalid lastname. Please re-input: ");
            }
            else
            {
                break;
            }
        }
        //TODO: Insert into database.
        Register(username, password, email, firstName, lastName);
    }
}

void LogIn(string username, string password)
{
    // Check credentials.
    Console.WriteLine("Credentials check, user logged in successfully !");
}

void Register(string username, string password, string email, string firstName, string lastName)
{
    Console.WriteLine($"User {username} registered successfully !");
}

bool ValidateEmail(string email)
{
    Regex emailRegex = new Regex(@"\w+@[a-zA-Z\.]+\.\w+");
    Match m = emailRegex.Match(email);
    return m.Success;
}

bool ValidatePassword(string password)
{
    // Password should be at least 12 letters long, consists of at least one lower case, consists of at least one upper case,
    // consists of at least one special symbol and consists of at least one digit
    var passwordRegex = new Regex(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&*\(\)\-\!+\?])[A-Za-z\d@#$%^&*\(\)\-\!+\?]{12,}");
    const string uppercasePattern = "(.*[A-Z])";
    const string lowercasePattern = "(.*[a-z])";
    const string digitPattern = @"(.*\d)";
    const string symbolPattern = @"(.*[@#$%^&*\(\)\-\!+\?])";
    const string lengthPattern = @"([A-Za-z\d@#$%^&*\(\)\-\!+\?]{12,})";
    Match m = passwordRegex.Match(password);
    var containUpperCase = Regex.IsMatch(password, uppercasePattern);
    var containLowerCase = Regex.IsMatch(password, lowercasePattern);
    var containDigit = Regex.IsMatch(password, digitPattern);
    var containSymbol = Regex.IsMatch(password, symbolPattern);
    var validLength = Regex.IsMatch(password, lengthPattern);
    if (!containUpperCase)
    {
        Console.WriteLine("Password should contain at least one uppercase letter.");
    }

    if (!containLowerCase)
    {
        Console.WriteLine("Password should contain at least one lowercase letter.");
    }

    if (!containDigit)
    {
        Console.WriteLine("Password should contain at least one digit.");
    }

    if (!containSymbol)
    {
        Console.WriteLine("Password should contain at least one special character.");
    }

    if (!validLength)
    {
        Console.WriteLine("Password is too short, it should be at least 12 characters long.");
    }
    return m.Success;
}