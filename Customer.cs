using System;

public class Customer
{
    private string id;
    private Contact contact;

    public Customer(Contact contact)
    {
        this.id = Guid.NewGuid().ToString().Substring(0, 3); // Shortened ID for display
        this.contact = new Contact(contact);
    }

    public Customer(Customer other)
    {
        this.id = other.id;
        this.contact = new Contact(other.contact);
    }

    public string Id
    {
        get { return id; }
    }

    public Contact Contact
    {
        get { return contact; }
        set { contact = value; }
    }

    public override string ToString()
    {
        // Format: ID  Name (Surname, first name)  Office phone  Office E-Mail
        string officeEmail = string.IsNullOrEmpty(contact.Email.Work) ? "N/A" : contact.Email.Work;
        return string.Format("{0,-5} {1,-25} {2,-15} {3,-20}",
            id,
            $"{contact.LastName}, {contact.FirstName}",
            contact.Phone.WorkPhone,
            officeEmail);
    }
}