using System;

public class Contact
{
    private string firstName;
    private string lastName;
    private Address address;
    private Email email;
    private Phone phone;

    public Contact()
    {
        firstName = string.Empty;
        lastName = string.Empty;
        address = new Address();
        email = new Email();
        phone = new Phone();
    }

    public Contact(string firstName, string lastName, Address address, Phone phone, Email email)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = new Address(address);
        this.email = new Email(email);
        this.phone = new Phone(phone);
    }

    public Contact(Contact other)
    {
        this.firstName = other.firstName;
        this.lastName = other.lastName;
        this.address = new Address(other.address);
        this.email = new Email(other.email);
        this.phone = new Phone(other.phone); // Fixed typo: 'phone' -> 'other.phone'
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public Email Email
    {
        get { return email; }
        set { email = value; }
    }

    public Phone Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public bool CheckData()
    {
        return !string.IsNullOrWhiteSpace(firstName) &&
               !string.IsNullOrWhiteSpace(lastName) &&
               !string.IsNullOrWhiteSpace(address.City) &&
               address.Country != default(Countries);
    }

    public override string ToString()
    {
        string countryStr = address.Country.ToString().Replace("_", " ");
        return $"{firstName} {lastName}\n" +
               $"{address.Street}\n" +
               $"{address.ZipCode} {address.City}\n" +
               $"{countryStr}\n\n" +
               "Emails\n" +
               $" Private\t{email.Personal}\n" +
               $" Office\t{email.Work}\n\n" +
               "Phone numbers\n" +
               $" Private\t{phone.PrivatePhone}\n" +
               $" Office\t{phone.WorkPhone}";
    }
}