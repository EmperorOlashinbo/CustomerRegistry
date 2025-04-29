namespace CustomerRegistry
{
    partial class ContactForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container(); // Ensure components are initialized
            SuspendLayout();
            // 
            // ContactForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "ContactForm";
            Text = "ContactForm";
            Load += ContactForm_Load;
            ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Event handler for the Load event of the ContactForm.
        /// </summary>
        private void ContactForm_Load(object sender, EventArgs e)
        {
            // Add initialization logic here if needed
        }
    }
}
