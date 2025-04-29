using System;
using System.Windows.Forms;

public class MainForm : Form
{
    private CustomerManager customerManager;
    private ListBox lstCustomers;
    private TextBox txtDetails;
    private Button btnAdd, btnEdit, btnDelete;
    private Label lblListHeader, lblDetailsHeader;

    public MainForm()
    {
        customerManager = new CustomerManager();
        lstCustomers = new ListBox(); // Initialize lstCustomers
        txtDetails = new TextBox();   // Initialize txtDetails
        btnAdd = new Button();        // Initialize btnAdd
        btnEdit = new Button();       // Initialize btnEdit
        btnDelete = new Button();     // Initialize btnDelete
        lblListHeader = new Label();  // Initialize lblListHeader
        lblDetailsHeader = new Label(); // Initialize lblDetailsHeader
        InitializeComponents();
    }


    private void InitializeComponents()
    {
        // Header for ListBox
        lblListHeader = new Label
        {
            Text = "ID   Name (Surname, first name)   Office phone   Office E-Mail",
            Location = new System.Drawing.Point(20, 5),
            Size = new System.Drawing.Size(500, 15), // Increased width to match ListBox
            Font = new System.Drawing.Font("Courier New", 8)
        };

        // ListBox
        lstCustomers = new ListBox
        {
            Location = new System.Drawing.Point(20, 20),
            Size = new System.Drawing.Size(500, 300),
            Font = new System.Drawing.Font("Courier New", 8)
        };

        // Header for TextBox
        lblDetailsHeader = new Label
        {
            Text = "Contact Details",
            Location = new System.Drawing.Point(530, 5),
            Size = new System.Drawing.Size(200, 15),
            Font = new System.Drawing.Font("Courier New", 10, System.Drawing.FontStyle.Bold)
        };

        // TextBox
        txtDetails = new TextBox
        {
            Location = new System.Drawing.Point(530, 20),
            Size = new System.Drawing.Size(400, 300),
            Multiline = true,
            ReadOnly = true,
            Font = new System.Drawing.Font("Courier New", 8)
        };

        // Buttons
        btnAdd = new Button { Text = "Add", Location = new System.Drawing.Point(20, 330), Size = new System.Drawing.Size(80, 30) };
        btnEdit = new Button { Text = "Edit", Location = new System.Drawing.Point(110, 330), Size = new System.Drawing.Size(80, 30) };
        btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(200, 330), Size = new System.Drawing.Size(80, 30) };

        // Add controls to the form
        Controls.AddRange(new Control[] { lblListHeader, lstCustomers, lblDetailsHeader, txtDetails, btnAdd, btnEdit, btnDelete });

        // Form properties
        Text = "Customer Registry";
        Size = new System.Drawing.Size(960, 400);
        StartPosition = FormStartPosition.CenterScreen;

        // Event handlers
        lstCustomers.SelectedIndexChanged += LstCustomers_SelectedIndexChanged;
        btnAdd.Click += BtnAdd_Click;
        btnEdit.Click += BtnEdit_Click;
        btnDelete.Click += BtnDelete_Click;
    }

    private void RefreshCustomerList()
    {
        lstCustomers.Items.Clear();
        lstCustomers.Items.AddRange(customerManager.GetCustomerInfoStrings());
    }

    private void LstCustomers_SelectedIndexChanged(object? sender, EventArgs e)
    {
        int index = lstCustomers.SelectedIndex;
        if (customerManager.CheckIndex(index))
        {
            Customer? customer = customerManager.GetCustomer(index);
            if (customer != null)
            {
                txtDetails.Text = customer.Contact.ToString();
            }
            else
            {
                txtDetails.Text = string.Empty;
            }
        }
        else
        {
            txtDetails.Text = string.Empty;
        }
    }


    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            using (ContactForm contactForm = new ContactForm())
            {
                if (contactForm.ShowDialog() == DialogResult.OK)
                {
                    customerManager.AddCustomer(contactForm.ContactData);
                    RefreshCustomerList();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while adding a customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        try
        {
            int index = lstCustomers.SelectedIndex;
            if (!customerManager.CheckIndex(index))
            {
                MessageBox.Show("Please select a customer to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer? customer = customerManager.GetCustomer(index);
            if (customer == null)
            {
                MessageBox.Show("The selected customer could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (ContactForm contactForm = new ContactForm(customer.Contact))
            {
                if (contactForm.ShowDialog() == DialogResult.OK)
                {
                    customerManager.ChangeCustomer(contactForm.ContactData, index);
                    RefreshCustomerList();
                    lstCustomers.SelectedIndex = index;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while editing a customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        try
        {
            int index = lstCustomers.SelectedIndex;
            if (!customerManager.CheckIndex(index))
            {
                MessageBox.Show("Please select a customer to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            customerManager.DeleteCustomer(index);
            RefreshCustomerList();
            txtDetails.Text = string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while deleting a customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}