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
                Console.WriteLine("Invalid username. Please re-input.");
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
                Console.WriteLine("Incorrect password, password can't be empty, please re-input");
            }
            else
            {
                break;
            }
        }
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
                Console.WriteLine("Invalid username. Please re-input.");
            }
            else
            {
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
                Console.WriteLine("Invalid email. Please re-input.");
            }
            else
            {
                // TODO: Validate email
                break;
            }
        }

        Console.Write("Please enter a password: ");
        string password;
        while (true)
        {
            password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Invalid password. Please re-input.");
            }
            else
            {
                break;
            }
        }

        Console.Write("Please enter first name: ");
        string firstName;
        while (true)
        {
            firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("Invalid firstname. Please re-input.");
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
                Console.WriteLine("Invalid lastname. Please re-input.");
            }
            else
            {
                break;
            }
        }
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