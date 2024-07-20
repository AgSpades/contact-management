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