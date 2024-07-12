using Phone.Core;
using Phone.Entities;
using System.Data.SqlClient;

namespace Phone.TL
{
    public class TransformationLayer
    {
        DatabaseLogicLayer DLL;
        SqlDataReader reader;

        public TransformationLayer()
        {
            DLL = new DatabaseLogicLayer();

        }
        // get all contacts with SqlDataReader and send them to BLL as List<Contacts>
        public List<Contacts> getAllContactsToBLL(Guid userId)
        {
            reader = DLL.getAllContacts(userId);
            List<Contacts> contacts = new List<Contacts>();

            while (reader.Read())
            {

                Contacts contact = new Contacts();

                contact.contactId = reader.GetGuid(reader.GetOrdinal("contactId"));
                contact.contactName = reader.GetString(reader.GetOrdinal("contactName"));
                contact.contactSurname = reader.GetString(reader.GetOrdinal("contactSurname"));
                contact.phoneHome = reader.GetString(reader.GetOrdinal("phoneHome"));
                contact.mobile = reader.GetString(reader.GetOrdinal("mobile"));
                contact.mobile2 = reader.GetString(reader.GetOrdinal("mobile2"));
                contact.mobile3 = reader.GetString(reader.GetOrdinal("mobile3"));
                contact.phoneWork = reader.GetString(reader.GetOrdinal("phoneWork"));
                contact.email = reader.GetString(reader.GetOrdinal("email"));
                contact.anniversary = reader.IsDBNull(reader.GetOrdinal("anniversary")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("anniversary"));

                contact.birthday = reader.IsDBNull(reader.GetOrdinal("birthday")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("birthday"));
                contact.userId = reader.GetGuid(reader.GetOrdinal("userId"));

                contacts.Add(contact);
            }
            DLL.connectionSettings(false);
            return contacts;

        }
        // get data of a contact with SqlDataReader send it to BLL as Contacts type
        public Contacts getContactToBLL(Guid contactId)
        {
            Contacts contact = new Contacts();
            reader = DLL.getContact(contactId);
            while (reader.Read())
            {
                contact.contactId = reader.GetGuid(reader.GetOrdinal("contactId"));
                contact.contactName = reader.GetString(reader.GetOrdinal("contactName"));
                contact.phoneHome = reader.GetString(reader.GetOrdinal("phoneHome"));
                contact.mobile = reader.GetString(reader.GetOrdinal("mobile"));
                contact.mobile2 = reader.GetString(reader.GetOrdinal("mobile2"));
                contact.mobile3 = reader.GetString(reader.GetOrdinal("mobile3"));
                contact.contactSurname = reader.GetString(reader.GetOrdinal("contactSurname"));
                contact.phoneWork = reader.GetString(reader.GetOrdinal("phoneWork"));
                contact.email = reader.GetString(reader.GetOrdinal("email"));
                contact.anniversary = reader.GetDateTime(reader.GetOrdinal("anniversary"));
                contact.birthday = reader.GetDateTime(reader.GetOrdinal("birthday"));
                contact.userId = reader.GetGuid(reader.GetOrdinal("userId"));
                contact._address = reader.GetString(reader.GetOrdinal("address"));
            }
            reader.Close();
            DLL.connectionSettings(false);
            return contact;
        }
        // send new user to DLL 
        public void sendNewUserToDLL(UserData newUser)
        {
            DLL.addUser(newUser);
        }
        // get user from dll and send it to bll 
        public UserData getUserToBLL(string userEmail, string userPassword)
        {
            UserData userData = new UserData();
            reader = DLL.getUser(userEmail, userPassword);
            while (reader.Read())
            {
                userData.email = reader.GetString(reader.GetOrdinal("email"));
                userData._password = reader.GetString(reader.GetOrdinal("_password"));
                userData.userName = reader.GetString(reader.GetOrdinal("userName"));
                userData.userId = reader.GetGuid(reader.GetOrdinal("userId"));
            }
            reader.Close();
            DLL.connectionSettings(false);
            return userData;
        }

        public int userAccountControl(string userEmail) // check whether the userEmail is registered or not in the sql database. If there is a record in database about the userEmail return 1
        {
            reader = DLL.userAccountControl(userEmail);
            bool result = reader.Read();
            reader.Close();
            DLL.connectionSettings(false);
            if (result)
                return 1;
            else
                return -1;
        }

        public void deleteContact(Guid contactId) // delete contact
        {
            DLL.deleteContact(contactId);
        }

        public void addContact(Contacts newContact) // add new contact
        {
            DLL.addUpdateContact(newContact, "addContact");
        }

        public void updateContact(Contacts updateContact) // update contact
        {
            DLL.addUpdateContact(updateContact, "updateContact");
        }
    }
}