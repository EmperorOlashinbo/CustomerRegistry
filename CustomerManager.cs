using System;
using System.Collections.Generic;

public class CustomerManager
{
    private List<Customer> customers;
    /// Constructor to initialize the customer list
    public CustomerManager()
    {
        customers = new List<Customer>();
    }
    /// Method to add a new customer
    public void AddCustomer(Contact contact)
    {
        customers.Add(new Customer(contact));
    }
    /// Method to change an existing customer
    public void ChangeCustomer(Contact contact, int index)
    {
        if (CheckIndex(index)) // Check if the index is valid
        {
            customers[index].Contact = new Contact(contact);
        }
    }

    public void DeleteCustomer(int index) // Method to delete a customer
    {
        if (CheckIndex(index)) // Check if the index is valid
        {
            customers.RemoveAt(index);
        }
    }
    /// Method to check if the index is valid
    public bool CheckIndex(int index)
    {
        return index >= 0 && index < customers.Count;
    }
    /// Method to get the number of customers
    public Customer? GetCustomer(int index)
    {
        return CheckIndex(index) ? customers[index] : null;
    }
    /// Method to get the number of customers
    public string[] GetCustomerInfoStrings()
    {
        string[] info = new string[customers.Count]; // Create an array to hold customer information
        for (int i = 0; i < customers.Count; i++)
        {
            info[i] = customers[i].ToString();
        }
        return info;
    }
}