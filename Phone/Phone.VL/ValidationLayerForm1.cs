using Phone.BLL;
using Phone.Entities;

namespace Phone.VL
{
    public class ValidationLayerForm1
    {
        BusinessLogicLayer BLL;
        public ValidationLayerForm1()
        {
            BLL = new BusinessLogicLayer();
        }
        // control form 1 textboxes are filled properly or not.
        public int userLogSignInControl(string email, string password)
        {
            if (String.IsNullOrEmpty(email) && String.IsNullOrEmpty(password))
            {
                return -1;
            }
            else return 1;
        }
        // send user email and password and log in. If the inputs are correct, get user data from bll and return it, otherwise, return null. 
        public UserData userSignIn(string email, string password)
        {
            UserData user = BLL.getUserToVL(email, password);
            return user;
        }
    }
}
