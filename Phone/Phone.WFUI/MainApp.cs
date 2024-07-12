using Phone.Entities;
using Phone.VL;

namespace Phone.WFUI
{
    public partial class MainApp : Form
    {
        ValidationLayerMainApp VL_mainApp;
        TabControl tabcontrol;
        UserData user;

        int index_tbPageNewContact;
        int index_tbPageImportExport;

        public MainApp()
        {
            InitializeComponent();
            VL_mainApp = new ValidationLayerMainApp();
            user = new UserData();
            tabcontrol = tbcontrol_contacts;
            tabcontrol.Visible = true;
            // add all form elements to the controls of tabPage
            tbPage_newContact.Controls.Add(txtbx_address);
            tbPage_newContact.Controls.Add(txtbx_anniversary);
            tbPage_newContact.Controls.Add(txtbx_birthday);
            tbPage_newContact.Controls.Add(txtbx_email);
            tbPage_newContact.Controls.Add(txtbx_home);
            tbPage_newContact.Controls.Add(txtbx_mobile1);
            tbPage_newContact.Controls.Add(txtbx_mobile2);
            tbPage_newContact.Controls.Add(txtbx_mobile3);
            tbPage_newContact.Controls.Add(txtbx_name);
            tbPage_newContact.Controls.Add(txtbx_surname);
            tbPage_newContact.Controls.Add(txtbx_work);
            tbPage_newContact.Controls.Add(bttn_addNewContact);
            tbPage_newContact.Controls.Add(bttn_deleteContact);
            tbPage_newContact.Controls.Add(bttn_editContact);

            // get the index of tabpages.
            index_tbPageNewContact = tabcontrol.TabPages.IndexOf(tbPage_newContact);
            index_tbPageImportExport = tabcontrol.TabPages.IndexOf(tbPage_importExport);



        }

        public UserData User { set { user = value; } }
        // fill the listbox at the beginning
        private void MainApp_Load(object sender, EventArgs e)
        {

            fillListBox();
            tbcontrol_contacts.SelectedIndex = index_tbPageNewContact;
            Text = user.userName;
            newContactEditContactSwapping(true);
            makeReadonlyTextboxes(true);
        }
        // get selected contact information
        private void lstbx_contacts_DoubleClick(object sender, EventArgs e)
        {

            tabcontrol.SelectedIndex = index_tbPageNewContact;
            ListBox listBox = (ListBox)sender;
            Contacts contact = (Contacts)listBox.SelectedItem;
            txtbx_name.Text = contact.contactName;
            txtbx_surname.Text = contact.contactSurname;
            txtbx_home.Text = contact.phoneHome;
            txtbx_mobile2.Text = contact.mobile2;
            txtbx_mobile3.Text = contact.mobile3;
            txtbx_mobile1.Text = contact.mobile;
            txtbx_work.Text = contact.phoneWork;
            txtbx_email.Text = contact.email;
            if (contact.birthday != null) // remove the clock information from datetime
            {
                int length = Convert.ToString(contact.birthday).Length - 9;
                txtbx_birthday.Text = Convert.ToString(contact.birthday).Substring(0, length);
            }
            else
            {
                txtbx_birthday.Text = Convert.ToString(contact.birthday);
            }
            if (contact.anniversary != null) // remove the clock information from datetime
            {
                int length = Convert.ToString(contact.anniversary).Length - 9;
                txtbx_anniversary.Text = Convert.ToString(contact.anniversary).Substring(0, length);
            }
            else
            {
                txtbx_anniversary.Text = Convert.ToString(contact.anniversary);
            }

            txtbx_address.Text = contact._address;
            makeReadonlyTextboxes(true);
        }
        // activate add new contact button, hide edit/update and delete buttons
        private void bttn_newContact_Click(object sender, EventArgs e)
        {

            clearTextboxes();
            makeReadonlyTextboxes(false);
            newContactEditContactSwapping(false);
            tbPage_newContact.Text = "New Contact";
            tbcontrol_contacts.SelectedIndex = index_tbPageNewContact;


        }
        // edit and update contact information
        private void bttn_editContact_Click_1(object sender, EventArgs e)
        {

            if (bttn_editContact.Text == "EDIT")
            {
                bttn_editContact.Text = "UPDATE";

                makeReadonlyTextboxes(false);
                Contacts selectedItem = (Contacts)lstbx_contacts.SelectedItem;
                tbPage_newContact.Text = selectedItem.contactName + " " + selectedItem.contactSurname;

            }
            else
            {
                bttn_editContact.Text = "EDIT";
                Contacts selectedItem = (Contacts)lstbx_contacts.SelectedItem;
                tbPage_newContact.Text = selectedItem.contactName + " " + selectedItem.contactSurname;


                Contacts updateContact = (Contacts)lstbx_contacts.SelectedItem;
                updateContact.contactId = updateContact.contactId;
                updateContact.contactName = txtbx_name.Text;
                updateContact.contactSurname = txtbx_surname.Text;
                updateContact.phoneHome = txtbx_home.Text;
                updateContact.mobile = txtbx_mobile1.Text;
                updateContact.mobile2 = txtbx_mobile2.Text;
                updateContact.mobile3 = txtbx_mobile3.Text;
                updateContact.phoneWork = txtbx_work.Text;
                updateContact.email = txtbx_email.Text;
                updateContact._address = txtbx_address.Text;
                try
                {
                    updateContact.birthday = DateTime.Parse(txtbx_birthday.Text);
                }
                catch
                {
                    updateContact.birthday = null;
                }
                try
                {
                    updateContact.anniversary = DateTime.Parse(txtbx_anniversary.Text);
                }
                catch
                {
                    updateContact.anniversary = null;
                }

                VL_mainApp.updateContact(updateContact);
                // clear the textboxes

                clearTextboxes();

                makeReadonlyTextboxes(true);
                tbPage_newContact.Text = "Contact";
                fillListBox();
            }
        }
        // add new contact
        private void bttn_addNewContact_Click(object sender, EventArgs e)
        {
            string name = txtbx_name.Text;
            string surname = txtbx_surname.Text;
            string homePhone = txtbx_home.Text;
            string mobile1 = txtbx_mobile1.Text;
            string mobile2 = txtbx_mobile2.Text;
            string mobile3 = txtbx_mobile3.Text;
            string workPhone = txtbx_work.Text;
            string email = txtbx_email.Text;
            string address = txtbx_address.Text;

            DateTime? birthday;
            DateTime? anniversary;

            // check whether the birthday is datetime or not
            try
            {
                birthday = DateTime.Parse(txtbx_birthday.Text);
            }

            catch
            {
                birthday = null;
            }
            // check whether the anniversary is datetime or not
            try
            {
                anniversary = DateTime.Parse(txtbx_anniversary.Text);
            }

            catch
            {
                anniversary = null;
            }


            int isCompleted = VL_mainApp.addContact(name, surname, homePhone, mobile1, mobile2, mobile3, workPhone, birthday, anniversary, email, address, user.userId);
            clearTextboxes();

            if (isCompleted == 1)
            {
                MessageBox.Show("New contact is added successfully. ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (isCompleted == -1)
            {
                MessageBox.Show("Fill the required spaces.",
                    "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }



            fillListBox();
            tbcontrol_contacts.SelectedIndex = index_tbPageNewContact;
            newContactEditContactSwapping(true);
            makeReadonlyTextboxes(true);


        }
        // delete contact permanently
        private void bttn_deleteContact_Click_1(object sender, EventArgs e)
        {
            Contacts deleteContact = (Contacts)lstbx_contacts.SelectedItem;
            VL_mainApp.deleteContact(deleteContact.contactId);
            clearTextboxes();
            fillListBox();
        }

        // import and export methods for contacts ----------------------------
        // import all contacts in csv
        private void bttn_importCSV_Click(object sender, EventArgs e)
        {
            string filePath = txtBx_addSource.Text;
            txtBx_addSource.Text = "";
            int isEmpty = VL_mainApp.fileSourceControl(filePath);
            importFilesResults(isEmpty, "csv", filePath);

        }
        // import all contacts in xml
        private void bttn_importXML_Click(object sender, EventArgs e)
        {
            string filePath = txtBx_addSource.Text;
            txtBx_addSource.Text = "";
            int isEmpty = VL_mainApp.fileSourceControl(filePath);
            importFilesResults(isEmpty, "xml", filePath);

        }
        // import all contacts in json.
        private void bttn_importJSON_Click(object sender, EventArgs e)
        {
            string filePath = txtBx_addSource.Text;
            txtBx_addSource.Text = "";
            int isEmpty = VL_mainApp.fileSourceControl(filePath);

            importFilesResults(isEmpty, "json", filePath);
        }
        // export contacts in csv file
        private void bttn_exportCSV_Click(object sender, EventArgs e)
        {
            string filePath = txtBx_addSource.Text;
            txtBx_addSource.Text = "";
            int isempty = VL_mainApp.fileSourceControl(filePath);
            if (isempty == 1)
            {
                int result = VL_mainApp.exportCSV(user, filePath);
                if (result == 1)
                {
                    MessageBox.Show("Please check the contacts csv file in the path.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter your file path in correct format and without file name. File name is given according to your gmail automatically.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter the file path.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // export contacts in xml file 
        private void bttn_exportXML_Click(object sender, EventArgs e)
        {
            string filePath = txtBx_addSource.Text;
            txtBx_addSource.Text = "";
            int isempty = VL_mainApp.fileSourceControl(filePath);
            if (isempty == 1)
            {
                int isOperationSuccessfull = VL_mainApp.exportXML(user, filePath);
                if (isOperationSuccessfull == 1)
                {
                    MessageBox.Show("Please check the contacts xml file in the path.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter your file path in correct format and without file name. File name is given according to your gmail automatically.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Please enter the file path.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        // export contacts in json file
        private void bttn_exportJSON_Click(object sender, EventArgs e)
        {
            string filePath = txtBx_addSource.Text;
            txtBx_addSource.Text = "";
            int isempty = VL_mainApp.fileSourceControl(filePath);
            if (isempty == 1)
            {
                int isOperationCompleted = VL_mainApp.exportJSON(user, filePath);
                if (isOperationCompleted == 1)
                {
                    MessageBox.Show("Please check the contacts json file in the path.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter your file path in correct format and without file name. File name is given according to your gmail automatically.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter the file path.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // helper methods------------------------------------------------------------
        // inform user about new contacts (added contacts, passed contacts, wrong filepath, etc.)
        public void importFilesResults(int isFilePathEmpty, string operation, string filePath)
        {
            if (isFilePathEmpty == 1)
            {
                var results = (0, "", 0, 0);
                if (operation == "json")
                {
                    results = VL_mainApp.importJSON(user.email, filePath);
                }
                else if (operation == "xml")
                {
                    results = VL_mainApp.importXML(user.email, filePath);
                }
                else
                {
                    results = VL_mainApp.importCSV(user.email, filePath);
                }
                if (results.Item1 == 1)
                {
                    MessageBox.Show($"Number of added contacts: {results.Item3},\nNumber of passed contacts: {results.Item4}.");
                    fillListBox();
                }

                else MessageBox.Show($"Required file is not found: {results.Item2}.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Please enter the file path.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void fillListBox() // fill the list box with ordered contacts
        {
            List<Contacts> contacts = VL_mainApp.getAllContactsToMainApp(user.userId);
            contacts = contacts.OrderBy(i => i.contactName.Substring(0, 1)).ToList();
            lstbx_contacts.DataSource = contacts;
        }
        // clearize all textboxes
        private void clearTextboxes()
        {
            txtbx_name.Text = "";
            txtbx_surname.Text = "";
            txtbx_home.Text = "";
            txtbx_mobile1.Text = "";
            txtbx_mobile2.Text = "";
            txtbx_mobile3.Text = "";
            txtbx_work.Text = "";
            txtbx_email.Text = "";
            txtbx_birthday.Text = "";
            txtbx_anniversary.Text = "";
            txtbx_address.Text = "";
        }
        // make readonly or not all textboxes
        private void makeReadonlyTextboxes(bool condition)
        {
            txtbx_name.ReadOnly = condition;
            txtbx_surname.ReadOnly = condition;
            txtbx_home.ReadOnly = condition;
            txtbx_mobile1.ReadOnly = condition;
            txtbx_mobile2.ReadOnly = condition;
            txtbx_mobile3.ReadOnly = condition;
            txtbx_work.ReadOnly = condition;
            txtbx_email.ReadOnly = condition;
            txtbx_birthday.ReadOnly = condition;
            txtbx_anniversary.ReadOnly = condition;
            txtbx_address.ReadOnly = condition;
        }
        // swap edit contact page to the new contact page and vice versa
        private void newContactEditContactSwapping(bool condition)
        {
            tbPage_newContact.Controls["bttn_editContact"].Visible = condition;
            tbPage_newContact.Controls["bttn_deleteContact"].Visible = condition;
            tbPage_newContact.Controls["bttn_addNewContact"].Visible = !condition;
        }


    }
}
