using System;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public Phone Phone { get; set; }
    public Email Email { get; set; }

    // Constructor for creating a contact with default values
    public Contact()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Address = new Address();
        Phone = new Phone();
        Email = new Email();
    }
    // Constructor for creating a contact with specific values
    public Contact(Contact other)
    {
        FirstName = other.FirstName;
        LastName = other.LastName;
        Address = new Address(other.Address);
        Phone = new Phone(other.Phone);
        Email = new Email(other.Email);
    }

    // Constructor for creating a contact with specific values
    public bool CheckData()
    {
        return !string.IsNullOrEmpty(FirstName) &&
               !string.IsNullOrEmpty(LastName) &&
               !string.IsNullOrEmpty(Address.City) &&
               Address.Country != default(Countries);
    }
    // Constructor for creating a contact with specific values
    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        // Section 1: Name and Address
        sb.AppendLine($"{FirstName} {LastName}");
        if (!string.IsNullOrEmpty(Address.Street))
            sb.AppendLine(Address.Street);
        if (!string.IsNullOrEmpty(Address.ZipCode) || !string.IsNullOrEmpty(Address.City))
            sb.AppendLine($"{Address.ZipCode} {Address.City}".Trim());
        sb.AppendLine(Address.Country.ToString());
        sb.AppendLine();

        // Section 2: Emails
        sb.AppendLine("Emails");
        sb.AppendLine($"PRIVATE  {Email.Personal}");
        sb.AppendLine($"OFFICE   {Email.Work}");
        sb.AppendLine();

        // Section 3: Phone Numbers
        sb.AppendLine("Phone numbers");
        sb.AppendLine($"PRIVATE  {Phone.PrivatePhone}");
        sb.AppendLine($"OFFICE   {Phone.WorkPhone}");

        return sb.ToString();
    }
}