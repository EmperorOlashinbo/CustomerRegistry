using System;

public class Phone
{
    public string WorkPhone { get; set; }
    public string PrivatePhone { get; set; }

    public Phone()
    {
        WorkPhone = string.Empty;
        PrivatePhone = string.Empty;
    }

    public Phone(string workPhone, string privatePhone)
    {
        WorkPhone = workPhone;
        PrivatePhone = privatePhone;
    }

    public Phone(Phone other)
    {
        WorkPhone = other.WorkPhone;
        PrivatePhone = other.PrivatePhone;
    }
}