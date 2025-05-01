using System;

public class Customer
{
    private string id;
    private Contact contact;
    /// Constructor for creating a customer with default values
    public Customer(Contact contact)
    {
        this.id = Guid.NewGuid().ToString().Substring(0, 3);
        this.contact = new Contact(contact);
    }
    /// Copy constructor
    public Customer(Customer other)
    {
        this.id = other.id;
        this.contact = new Contact(other.contact);
    }
    /// Property to get the ID of the customer
    public string Id
    {
        get { return id; }
    }
    /// Property to get or set the contact information
    public Contact Contact
    {
        get { return contact; }
        set { contact = value; }
    }
    /// Method to check if the contact data is valid
    public override string ToString()
    {
        string officeEmail = string.IsNullOrEmpty(contact.Email.Work) ? "N/A" : contact.Email.Work;
        return string.Format("{0,-5} {1,-25} {2,-15} {3,-20}",
            id,
            $"{contact.LastName}, {contact.FirstName}",
            contact.Phone.WorkPhone,
            officeEmail);
    }
}