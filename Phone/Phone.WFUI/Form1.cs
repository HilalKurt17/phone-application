using Phone.Entities;
using Phone.VL;

namespace Phone.WFUI
{
    public partial class Form1 : Form
    {


        ValidationLayerForm1 VL_form1;
        UserData user;
        public Form1()
        {
            InitializeComponent();

            VL_form1 = new ValidationLayerForm1();
            user = new UserData();
        }


        // open sign up form and hide this form
        private void lbl_signUp_Click(object sender, EventArgs e)
        {
            txtBx_email.Text = "";
            txtBx_password.Text = "";
            FormControl.Instance.formSignUp.Show();
            FormControl.Instance.form1.Hide();
        }
        // sign in, open main app form and hide this form(after required sign in controls)
        private void bttn_signIn_Click_1(object sender, EventArgs e)
        {
            string email = txtBx_email.Text;
            string password = txtBx_password.Text;
            txtBx_email.Text = "";
            txtBx_password.Text = "";

            int result = VL_form1.userLogSignInControl(email, password);

            if (result == -1)
            {
                MessageBox.Show("Fill the blanks.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {
                user = VL_form1.userSignIn(email, password);
                if (user.userName == null)
                {
                    MessageBox.Show("Invalid user or password.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Log in successfull.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormControl.Instance.mainApp.User = user;
                    FormControl.Instance.mainApp.Show();
                    FormControl.Instance.form1.Close();
                }
            }

        }
    }
}