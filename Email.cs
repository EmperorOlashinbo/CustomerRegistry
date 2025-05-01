using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Email
{
    public string Work { get; set; }
    public string Personal { get; set; }

    // Constructor for creating an email with default values
    public Email()
    {
        Work = string.Empty;
        Personal = string.Empty;
    }
    // Constructor for creating an email with specific values
    public Email(string work, string personal)
    {
        Work = work;
        Personal = personal;
    }
    // Constructor for creating an email with specific values
    public Email(Email other)
    {
        Work = other.Work;
        Personal = other.Personal;
    }
}