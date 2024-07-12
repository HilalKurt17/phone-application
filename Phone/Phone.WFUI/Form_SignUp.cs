using Phone.VL;

namespace Phone.WFUI
{
    public partial class Form_SignUp : Form
    {
        ValidationLayerFormSignUp VL_formSignUp;

        public Form_SignUp()
        {

            InitializeComponent();
            VL_formSignUp = new ValidationLayerFormSignUp();
        }

        // if sign up operation successfull, open the form1, otherwise inform user about sign up problem.

        private void bttn_signUp_Click(object sender, EventArgs e)
        {
            string newUserName = txtBx_userName.Text;
            string newUserEmail = txtBx_email.Text;
            string newUserPassword = txtBx_password.Text;
            txtBx_userName.Text = "";
            txtBx_email.Text = "";
            txtBx_password.Text = "";
            int result = VL_formSignUp.controlTextBoxes(newUserName, newUserEmail, newUserPassword);
            if (result == 0)
            {
                MessageBox.Show("You already have an account! ", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FormControl.Instance.form1.Show();
                FormControl.Instance.formSignUp.Hide();
            }
            else if (result == 1)
            {
                MessageBox.Show("You enrolled successfully. ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormControl.Instance.form1.Show();
                FormControl.Instance.formSignUp.Hide();

            }
            else if (result == -1)
            {
                MessageBox.Show("Fill the blanks.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Email address is not valid.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
