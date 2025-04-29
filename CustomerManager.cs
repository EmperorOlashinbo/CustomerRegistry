using System;
using System.Collections.Generic;

public class CustomerManager
{
    private List<Customer> customers;

    public CustomerManager()
    {
        customers = new List<Customer>();
    }

    public void AddCustomer(Contact contact)
    {
        customers.Add(new Customer(contact));
    }

    public void ChangeCustomer(Contact contact, int index)
    {
        if (CheckIndex(index))
        {
            customers[index].Contact = new Contact(contact);
        }
    }

    public void DeleteCustomer(int index)
    {
        if (CheckIndex(index))
        {
            customers.RemoveAt(index);
        }
    }

    public bool CheckIndex(int index)
    {
        return index >= 0 && index < customers.Count;
    }

    public Customer? GetCustomer(int index)
    {
        return CheckIndex(index) ? customers[index] : null;
    }

    public string[] GetCustomerInfoStrings()
    {
        string[] info = new string[customers.Count];
        for (int i = 0; i < customers.Count; i++)
        {
            info[i] = customers[i].ToString();
        }
        return info;
    }
}