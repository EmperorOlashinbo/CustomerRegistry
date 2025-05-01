using System;

public class Phone
{
    public string WorkPhone { get; set; }
    public string PrivatePhone { get; set; }
    // Constructor for creating a phone with default values
    public Phone()
    {
        WorkPhone = string.Empty;
        PrivatePhone = string.Empty;
    }
    // Constructor for creating a phone with specific values
    public Phone(string workPhone, string privatePhone)
    {
        WorkPhone = workPhone;
        PrivatePhone = privatePhone;
    }
    // Constructor for creating a phone with specific values
    public Phone(Phone other)
    {
        WorkPhone = other.WorkPhone;
        PrivatePhone = other.PrivatePhone;
    }
}