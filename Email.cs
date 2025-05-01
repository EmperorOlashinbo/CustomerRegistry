using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Email
{
    public string Work { get; set; }
    public string Personal { get; set; }

    public Email()
    {
        Work = string.Empty;
        Personal = string.Empty;
    }

    public Email(string work, string personal)
    {
        Work = work;
        Personal = personal;
    }

    public Email(Email other)
    {
        Work = other.Work;
        Personal = other.Personal;
    }
}