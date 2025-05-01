using System;

public class Address
{
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public Countries Country { get; set; }

    public Address()
    {
        Street = string.Empty;
        ZipCode = string.Empty;
        City = string.Empty;
        Country = Countries.Sverige;
    }

    public Address(string street, string zipCode, string city, Countries country)
    {
        Street = street;
        ZipCode = zipCode;
        City = city;
        Country = country;
    }

    public Address(Address other)
    {
        Street = other.Street;
        ZipCode = other.ZipCode;
        City = other.City;
        Country = other.Country;
    }
}