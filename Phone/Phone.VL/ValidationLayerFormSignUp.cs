using Phone.BLL;

namespace Phone.VL
{
    public class ValidationLayerFormSignUp
    {
        BusinessLogicLayer BLL;
        public ValidationLayerFormSignUp()
        {
            BLL = new BusinessLogicLayer();
        }
        // control sign up form textboxes if they are filled properly or not.
        public int controlTextBoxes(string userName, string email, string password)
        {
            if (String.IsNullOrEmpty(userName) && String.IsNullOrEmpty(email) && String.IsNullOrEmpty(password))
            {
                return -1; // if  there is an empty textbox, warn the user
            }
            else
            {
                if (!email.Contains("@"))
                {
                    return -2; // email address is not valid
                }
                int result = BLL.userMailControl(email);
                if (result == 1) // if email address is already exist in the database
                {
                    return 0;
                }

            }
            return addNewUser(userName, email, password);
        }
        // send new user data to bll
        public int addNewUser(string userName, string email, string password)
        {
            return BLL.addNewUser(userName, email, password);
        }
    }
}
