using System.Dynamic;

Dictionary<string, ContatoList> contactList = new Dictionary<string, ContatoList>();

bool running = true;

while (running)
{
    Console.WriteLine("\n-- Contact Manager ---");
    Console.WriteLine("1, Add contact");
    Console.WriteLine("2, Remove from contact");
    Console.WriteLine("3, Search for contact");
    Console.WriteLine("4, List all contact");
    Console.WriteLine("5, Exist Application");
    Console.WriteLine("6, To Update Contact");

    System.Console.WriteLine("Choose an option: ");

    string optionToChoose = Console.ReadLine()!;

    switch (optionToChoose)
    {
        case "1":
            AddContact(contactList);
            break;

        case "2":
            RemoveContact(contactList);
            break;

        case "3":
            SearchContact(contactList);
            break;

        case "4":
            ListAllContacts(contactList);
            break;

        case "5":
            running = false;
            System.Console.WriteLine("Existing....");
            break;

             case "6":
            UpdateContacts(contactList);
            break;

        default:
            System.Console.WriteLine("You entered an invalid option! Please try again....");
            break;
    }
}

static void AddContact(Dictionary<string, ContatoList> contactList)
{

    Console.WriteLine("Enter your name: ");
    string name = Console.ReadLine()!;

    if (contactList.ContainsKey(name))
    {
        Console.WriteLine("Contact Already Exits");
        return;
    }

    Console.WriteLine("Enter your phoneNumber: ");
    string phoneNumber = Console.ReadLine()!;

    Console.WriteLine("Enter your email: ");
    string email = Console.ReadLine()!;

    contactList[name] = new ContatoList(name, phoneNumber, email);
    Console.WriteLine("Contact added successfully!");
}

static void RemoveContact(Dictionary<string, ContatoList> contactList)
{
    Console.WriteLine("Enter the name you want to remove: ");
    string name = Console.ReadLine()!;

    if (contactList.Remove(name))
    {
        Console.WriteLine("Contact remove successful");
    }

}

static void SearchContact(Dictionary<string, ContatoList> contactList)
{
    System.Console.WriteLine("Enter the name of the contact you want to search for: ");
    string name = Console.ReadLine()!;

    if (contactList.TryGetValue(name, out ContatoList? contact))
    {
        Console.WriteLine(contact);
    }
    else
    {
        Console.WriteLine("contact not found!");
    }
}

static void ListAllContacts(Dictionary<string, ContatoList> contactList)
{
    if (contactList.Count == 0)
    {
        Console.WriteLine("No Contacts found");
    }
    else
    {
        Console.WriteLine("\n--- Contact List ---");
        foreach (var contact in contactList)
        {
            Console.WriteLine(contact);
        }
    }
}

static void UpdateContacts(Dictionary<string, ContatoList> contactList)
{
    Console.WriteLine("Enter the name u want to update: ");
    string name = Console.ReadLine()!;
    if (contactList.TryGetValue(name, out ContatoList? contactExist))
    {

         Console.WriteLine("Enter your new Name: ");
        string newName = Console.ReadLine()!;

        if (string.IsNullOrEmpty(newName))
        {
            newName = contactExist.Name;
        }

        Console.WriteLine("Enter your new phonenumber: ");
        string newPhoneNumber = Console.ReadLine()!;

        if (string.IsNullOrEmpty(newPhoneNumber))
        {
            newPhoneNumber = contactExist.PhoneNumber;
        }

        Console.WriteLine("Enter your new email: ");
        string newEmail = Console.ReadLine()!;

        if (string.IsNullOrEmpty(newPhoneNumber))
        {
            newEmail = contactExist.Email;
        }

        contactList[name] = new ContatoList( newName, newPhoneNumber, newEmail);
        Console.WriteLine("Contact updated  successfully!");
    }


    else
    {
      Console.WriteLine("Cant update this contact! Because it does not exist");
      return;
    }


}



class ContatoList
{

    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;


    public ContatoList(string name, string phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Telephone: {PhoneNumber}, Email: {Email}";
    }
}

