public class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, string phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}";
    }
}

public class ContactManager
{
    //make a list accessible only to this class.
    private List<Contact> contacts = new List<Contact>();

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void DeleteContact(string name)
    {
        var contact = contacts.Find(c => c.Name == name);
        if (name != null)
        {
            contacts.Remove(contact);
        }
    }

    public void UpdateContact(string newPhoneNumber, string newEmail, string name)
    {
        var contact = contacts.Find(c => c.Name == name);
        if (contact != null)
        {
            contact.PhoneNumber = newPhoneNumber;
            contact.Email = newEmail;
        }
    }

    public void SearchContact(string name)
    {
        var contact = contacts.Find(c => c.Name == name);
        if (contact != null)
        {
            Console.WriteLine(contact);
        }
        else
        {
            Console.WriteLine("Contact not found...");
        }
    }

    public void DisplayContacts()
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }
}

class Program
{
    static void Main()
    {
        ContactManager cm = new();
        Console.WriteLine("Welcome to your personal console based Contact Manager.");
        Console.WriteLine("It's not permanent. The contacts you add will be cleared off as soon as you exit the console.");
        Console.WriteLine("It's just for refreshing my OOP skills in C#. Sayonara~");
        string? command = "";

        while (command != "exit")
        {
            Console.WriteLine("Choose an option: add, update, delete, search, display, exit");
            command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    AddContact(cm);
                    break;

                case "update":
                    UpdateContact(cm);
                    break;

                case "delete":
                    DeleteContact(cm);
                    break;

                case "search":
                    SearchContact(cm);
                    break;

                case "display":
                    cm.DisplayContacts();
                    break;

                case "exit":
                    Console.WriteLine("Exiting the program....");
                    break;

                default:
                    Console.WriteLine("Invalid option..");
                    break;
            }
        }

    }
    static void AddContact(ContactManager contactManager)
    {
        Console.Write("Enter name: ");
        string? name = Console.ReadLine();
        Console.Write("Enter phone number: ");
        string? phoneNumber = Console.ReadLine();
        Console.Write("Enter email: ");
        string? email = Console.ReadLine();

        Contact contact = new Contact(name, phoneNumber, email);
        contactManager.AddContact(contact);
        Console.WriteLine("Contact added.");
    }

    static void UpdateContact(ContactManager contactManager)
    {
        Console.Write("Enter name of the contact to update: ");
        string? name = Console.ReadLine();
        Console.Write("Enter new phone number: ");
        string? newPhoneNumber = Console.ReadLine();
        Console.Write("Enter new email: ");
        string? newEmail = Console.ReadLine();

        contactManager.UpdateContact(name, newPhoneNumber, newEmail);
        Console.WriteLine("Contact updated.");
    }

    static void DeleteContact(ContactManager contactManager)
    {
        Console.Write("Enter name of the contact to delete: ");
        string? name = Console.ReadLine();
        contactManager.DeleteContact(name);
        Console.WriteLine("Contact deleted.");
    }

    static void SearchContact(ContactManager contactManager)
    {
        Console.Write("Enter name of the contact to search: ");
        string? name = Console.ReadLine();
        contactManager.SearchContact(name);
    }
}