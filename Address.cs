using System;

public class Address
{
    private string street;
    private string zipCode;
    private string city;
    private Countries country;

    /// <summary>
    /// Default constructor - chains to the two-parameter constructor with default values.
    /// </summary>
    public Address() : this("Unknown", "Unknown")
    {
    }

    /// <summary>
    /// Constructor with two parameters - chains to the three-parameter constructor with default country.
    /// </summary>
    /// <param name="street">Street address</param>
    /// <param name="city">City name</param>
    public Address(string street, string city) : this(street, "00000", city, Countries.Sverige)
    {
    }

    /// <summary>
    /// Constructor with all parameters - initializes all fields.
    /// </summary>
    /// <param name="street">Street address</param>
    /// <param name="zipCode">Zip code</param>
    /// <param name="city">City name</param>
    /// <param name="country">Country from Countries enum</param>
    public Address(string street, string zipCode, string city, Countries country)
    {
        this.street = street;
        this.zipCode = zipCode;
        this.city = city;
        this.country = country;
    }

    /// <summary>
    /// Copy constructor - creates a copy of another Address object.
    /// </summary>
    /// <param name="other">Address object to copy</param>
    public Address(Address other)
    {
        this.street = other.street;
        this.zipCode = other.zipCode;
        this.city = other.city;
        this.country = other.country;
    }

    /// <summary>
    /// Gets or sets the street address.
    /// </summary>
    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    /// <summary>
    /// Gets or sets the zip code.
    /// </summary>
    public string ZipCode
    {
        get { return zipCode; }
        set { zipCode = value; }
    }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City
    {
        get { return city; }
        set { city = value; }
    }

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public Countries Country
    {
        get { return country; }
        set { country = value; }
    }

    /// <summary>
    /// Returns a formatted string of address data.
    /// </summary>
    /// <returns>Formatted address string</returns>
    public override string ToString()
    {
        string countryStr = country.ToString().Replace("_", " ");
        return $"\nAddress\n Street: {street}\n Zip: {zipCode}\n City: {city}\n Country: {countryStr}\n";
    }

    /// <summary>
    /// Gets headings for address data display.
    /// </summary>
    public string GetToStringItemsHeadings
    {
        get { return string.Format("{0,-20} {1,-10} {2,-15} {3,-20}", "Street", "Zip", "City", "Country"); }
    }
}