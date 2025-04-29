using System;
using System.Windows.Forms;

public class ContactForm : Form
{
    private TextBox? txtFirstName, txtLastName, txtStreet, txtZipCode, txtCity;
    private ComboBox? cmbCountry;
    private TextBox? txtPrivatePhone, txtOfficePhone, txtPrivateEmail, txtOfficeEmail;
    private Button? btnOK, btnCancel;
    private Contact contact;
    private GroupBox? grpName, grpEmailPhone, grpAddress;

    public ContactForm()
    {
        InitializeComponents();
        contact = new Contact();
    }

    public ContactForm(Contact contact)
    {
        InitializeComponents();
        this.contact = new Contact(contact);
        PopulateFields();
    }

    public Contact ContactData
    {
        get { return contact; }
    }

    private void InitializeComponents()
    {
        // GroupBox: Name
        grpName = new GroupBox
        {
            Text = "Name",
            Location = new System.Drawing.Point(10, 10),
            Size = new System.Drawing.Size(360, 80)
        };

        // Labels and TextBoxes for Name
        var lblFirstName = new Label { Text = "First name", Location = new System.Drawing.Point(10, 20), Width = 100 };
        var lblLastName = new Label { Text = "Last name", Location = new System.Drawing.Point(10, 50), Width = 100 };
        txtFirstName = new TextBox { Location = new System.Drawing.Point(110, 20), Width = 200 };
        txtLastName = new TextBox { Location = new System.Drawing.Point(110, 50), Width = 200 };

        grpName.Controls.AddRange(new Control[] { lblFirstName, lblLastName, txtFirstName, txtLastName });

        // GroupBox: Email and Phone
        grpEmailPhone = new GroupBox
        {
            Text = "Email and phone",
            Location = new System.Drawing.Point(10, 100),
            Size = new System.Drawing.Size(360, 130)
        };

        // Labels and TextBoxes for Email and Phone
        var lblPrivatePhone = new Label { Text = "Home phone", Location = new System.Drawing.Point(10, 20), Width = 100 };
        var lblOfficePhone = new Label { Text = "Cell phone", Location = new System.Drawing.Point(10, 50), Width = 100 };
        var lblPrivateEmail = new Label { Text = "E-mail, private", Location = new System.Drawing.Point(10, 80), Width = 100 };
        var lblOfficeEmail = new Label { Text = "E-mail, business", Location = new System.Drawing.Point(10, 110), Width = 100 };
        txtPrivatePhone = new TextBox { Location = new System.Drawing.Point(110, 20), Width = 200 };
        txtOfficePhone = new TextBox { Location = new System.Drawing.Point(110, 50), Width = 200 };
        txtPrivateEmail = new TextBox { Location = new System.Drawing.Point(110, 80), Width = 200 };
        txtOfficeEmail = new TextBox { Location = new System.Drawing.Point(110, 110), Width = 200 };

        grpEmailPhone.Controls.AddRange(new Control[] { lblPrivatePhone, lblOfficePhone, lblPrivateEmail, lblOfficeEmail, txtPrivatePhone, txtOfficePhone, txtPrivateEmail, txtOfficeEmail });

        // GroupBox: Address
        grpAddress = new GroupBox
        {
            Text = "Address",
            Location = new System.Drawing.Point(10, 240),
            Size = new System.Drawing.Size(360, 130)
        };

        // Labels and Controls for Address
        var lblStreet = new Label { Text = "Street", Location = new System.Drawing.Point(10, 20), Width = 100 };
        var lblZipCode = new Label { Text = "Zip code", Location = new System.Drawing.Point(10, 50), Width = 100 };
        var lblCity = new Label { Text = "City", Location = new System.Drawing.Point(10, 80), Width = 100 };
        var lblCountry = new Label { Text = "Country", Location = new System.Drawing.Point(10, 110), Width = 100 };
        txtStreet = new TextBox { Location = new System.Drawing.Point(110, 20), Width = 200 };
        txtZipCode = new TextBox { Location = new System.Drawing.Point(110, 50), Width = 100 };
        txtCity = new TextBox { Location = new System.Drawing.Point(110, 80), Width = 200 };
        cmbCountry = new ComboBox { Location = new System.Drawing.Point(110, 110), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

        grpAddress.Controls.AddRange(new Control[] { lblStreet, lblZipCode, lblCity, lblCountry, txtStreet, txtZipCode, txtCity, cmbCountry });

        // Populate country combo box and ensure a default selection
        cmbCountry.Items.AddRange(Enum.GetNames(typeof(Countries)));
        if (cmbCountry.Items.Count > 0)
        {
            cmbCountry.SelectedIndex = 0; // Default to the first country
        }

        // Buttons
        btnOK = new Button { Text = "OK", Location = new System.Drawing.Point(120, 380), DialogResult = DialogResult.OK };
        btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(200, 380), DialogResult = DialogResult.Cancel };

        // Add controls to form
        Controls.AddRange(new Control[] { grpName, grpEmailPhone, grpAddress, btnOK, btnCancel });

        // Form properties
        Text = "Contact Information";
        Size = new System.Drawing.Size(400, 450);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;

        // Event handlers
        btnOK.Click += BtnOK_Click;
        btnCancel.Click += BtnCancel_Click;
    }

    private void PopulateFields()
    {
        txtFirstName!.Text = contact.FirstName ?? string.Empty;
        txtLastName!.Text = contact.LastName ?? string.Empty;
        txtStreet!.Text = contact.Address.Street ?? string.Empty;
        txtZipCode!.Text = contact.Address.ZipCode ?? string.Empty;
        txtCity!.Text = contact.Address.City ?? string.Empty;
        cmbCountry!.SelectedItem = contact.Address.Country.ToString() ?? Enum.GetNames(typeof(Countries))[0]; // Fallback to first country
        txtPrivatePhone!.Text = contact.Phone.PrivatePhone ?? string.Empty;
        txtOfficePhone!.Text = contact.Phone.WorkPhone ?? string.Empty;
        txtPrivateEmail!.Text = contact.Email.Personal ?? string.Empty;
        txtOfficeEmail!.Text = contact.Email.Work ?? string.Empty;
    }

    private void BtnOK_Click(object? sender, EventArgs e)
    {
        // Validate country selection
        if (cmbCountry!.SelectedItem != null)
        {
            contact.FirstName = txtFirstName!.Text.Trim();
            contact.LastName = txtLastName!.Text.Trim();
            contact.Address = new Address(
                txtStreet!.Text.Trim(),
                txtZipCode!.Text.Trim(),
                txtCity!.Text.Trim(),
                (Countries)Enum.Parse(typeof(Countries), cmbCountry.SelectedItem.ToString()!)
            );
            contact.Phone = new Phone(txtOfficePhone!.Text.Trim(), txtPrivatePhone!.Text.Trim());
            contact.Email = new Email(txtOfficeEmail!.Text.Trim(), txtPrivateEmail!.Text.Trim());
        }
        else
        {
            MessageBox.Show("Please select a valid country.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.None; // Prevent form from closing
            return;
        }

        // Validate required fields
        if (!contact.CheckData())
        {
            MessageBox.Show("Please fill in all required fields: First Name, Last Name, City, and Country.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.None; // Prevent form from closing
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to cancel?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No)
        {
            DialogResult = DialogResult.None; // Keep form open
        }
    }
}