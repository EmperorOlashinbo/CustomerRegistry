using System;

public class Phone
{
    private string privatePhone;
    private string officePhone;

    /// <summary>
    /// Default constructor - initializes empty phone numbers.
    /// </summary>
    public Phone()
    {
        privatePhone = string.Empty;
        officePhone = string.Empty;
    }

    /// <summary>
    /// Constructor with one parameter - chains to two-parameter constructor.
    /// </summary>
    /// <param name="officePhone">Office phone number</param>
    public Phone(string officePhone) : this(officePhone, string.Empty)
    {
    }

    /// <summary>
    /// Constructor with two parameters - initializes both phone numbers.
    /// </summary>
    /// <param name="officePhone">Office phone number</param>
    /// <param name="privatePhone">Private phone number</param>
    public Phone(string officePhone, string privatePhone)
    {
        this.officePhone = officePhone;
        this.privatePhone = privatePhone;
    }

    /// <summary>
    /// Copy constructor - creates a copy of another Phone object.
    /// </summary>
    /// <param name="other">Phone object to copy</param>
    public Phone(Phone other)
    {
        this.privatePhone = other.privatePhone;
        this.officePhone = other.officePhone;
    }

    /// <summary>
    /// Gets or sets the private phone number.
    /// </summary>
    public string PrivatePhone
    {
        get { return privatePhone; }
        set { privatePhone = value; }
    }

    /// <summary>
    /// Gets or sets the office phone number.
    /// </summary>
    public string WorkPhone
    {
        get { return officePhone; }
        set { officePhone = value; }
    }

    /// <summary>
    /// Returns a formatted string of phone data.
    /// </summary>
    /// <returns>Formatted phone string</returns>
    public override string ToString()
    {
        return $"\nPhones\n Private: {privatePhone}\n Office: {officePhone}\n";
    }

    /// <summary>
    /// Gets headings for phone data display.
    /// </summary>
    public string GetToStringItemsHeadings
    {
        get { return string.Format("{0,-20} {1,-20}", "Private Phone", "Office Phone"); }
    }
}