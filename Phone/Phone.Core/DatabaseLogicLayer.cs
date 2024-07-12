using Phone.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Phone.Core
{

    public class DatabaseLogicLayer
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        // assign stored procedures to 
        string sp_contactAdd = "addNewContact";
        string sp_contactDelete = "deleteContact";
        string sp_contactUpdate = "updateContact";
        string sp_getContact = "getContact";
        string sp_getAllContact = "getAllContacts";
        string sp_getUser = "sp_getUser";
        string sp_addUser = "sp_addUserPhoneDB";
        string sp_userAccount = "userAccountControl";


        public DatabaseLogicLayer()
        {
            connection = new SqlConnection("data source=.; initial catalog= PhoneDB; user Id = sa; password=1;");
        }
        // if connection is closed, open and return 1; otherwise, close the connection and return -1
        public int connectionSettings(bool connect)
        {
            if (connect && connection.State == ConnectionState.Closed)
            {
                connection.Open();
                return 1;
            }
            else
            {
                connection.Close();
                return -1;
            }
        }
        // insert/update a contact in the database
        public void addUpdateContact(Contacts contact, string operation)
        {

            if (operation == "addContact")
            {
                command = new SqlCommand(sp_contactAdd, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = contact.userId;
            }
            else
            {
                command = new SqlCommand(sp_contactUpdate, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@contactId", SqlDbType.UniqueIdentifier).Value = contact.contactId;
            }



            command.Parameters.Add("@contactName", SqlDbType.NVarChar).Value = contact.contactName;

            command.Parameters.Add("@contactSurname", SqlDbType.NVarChar).Value = contact.contactSurname != null ? (string)contact.contactSurname : DBNull.Value;

            command.Parameters.Add("@phoneHome", SqlDbType.NVarChar).Value = contact.phoneHome != null ? (string)contact.phoneHome : DBNull.Value;

            command.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = contact.mobile;

            command.Parameters.Add("@mobile2", SqlDbType.NVarChar).Value = contact.mobile2 != null ? (string)contact.mobile2 : DBNull.Value;

            command.Parameters.Add("@mobile3", SqlDbType.NVarChar).Value = contact.mobile3 != null ? (string)contact.mobile3 : DBNull.Value;

            command.Parameters.Add("@phoneWork", SqlDbType.NVarChar).Value = contact.phoneWork != null ? (string)contact.phoneWork : DBNull.Value;

            command.Parameters.Add("@birthday", SqlDbType.DateTime).Value = contact.birthday != null ? (DateTime)contact.birthday : DBNull.Value;

            command.Parameters.Add("@anniversary", SqlDbType.DateTime).Value = contact.anniversary != null ? (DateTime)contact.anniversary : DBNull.Value;

            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = contact.email != null ? (string)contact.email : DBNull.Value;

            command.Parameters.Add("@_address", SqlDbType.NVarChar).Value = contact._address != null ? (string)contact._address : DBNull.Value;

            connectionSettings(true);
            command.ExecuteNonQuery();
            connectionSettings(false);
        }

        public void deleteContact(Guid contactId) // delete the contact
        {
            command = new SqlCommand(sp_contactDelete, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@contactId", SqlDbType.UniqueIdentifier).Value = contactId;
            connectionSettings(true);
            command.ExecuteNonQuery();
            connectionSettings(false);
        }
        public SqlDataReader getAllContacts(Guid userId) // get all contacts for the user with user Id
        {
            command = new SqlCommand(sp_getAllContact, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;
            connectionSettings(true);
            reader = command.ExecuteReader();
            return reader;
        }
        public SqlDataReader getContact(Guid contactId)  // get contact which is Contact Id is given
        {
            command = new SqlCommand(sp_getContact, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@contactId", SqlDbType.UniqueIdentifier).Value = contactId;
            connectionSettings(true);
            reader = command.ExecuteReader();
            return reader;
        }
        public void addUser(UserData newUserData)
        {
            command = new SqlCommand(sp_addUser, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@userName", SqlDbType.NVarChar).Value = newUserData.userName;
            command.Parameters.Add("@_password", SqlDbType.NVarChar).Value = newUserData._password;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = newUserData.email;
            connectionSettings(true);
            command.ExecuteNonQuery();
            connectionSettings(false);
        }// add new user to Sql

        public SqlDataReader getUser(string userEmail, string userPassword)
        {
            command = new SqlCommand(sp_getUser, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = userEmail;
            command.Parameters.Add("@_password", SqlDbType.NVarChar).Value = userPassword;
            connectionSettings(true);
            reader = command.ExecuteReader();

            return reader;
        } // get user from sql which userEmail and userPasswords are given

        public SqlDataReader userAccountControl(string userEmail) // users can have just one account with same email address
        {
            command = new SqlCommand(sp_userAccount, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = userEmail;
            connectionSettings(true);
            reader = command.ExecuteReader();

            return reader;
        }
    }
}