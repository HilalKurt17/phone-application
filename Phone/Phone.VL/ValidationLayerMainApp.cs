using Phone.BLL;
using Phone.Entities;

namespace Phone.VL
{
    public class ValidationLayerMainApp
    {
        BusinessLogicLayer BLL;
        public ValidationLayerMainApp()
        {
            BLL = new BusinessLogicLayer();
        }
        // get all Contacts from BLL and send them to the Main App UI
        public List<Contacts> getAllContactsToMainApp(Guid userId)
        {
            return BLL.getAllContactsToVL(userId);
        }
        // send contact Id to BLL to delete.
        public void deleteContact(Guid contactId)
        {
            BLL.deleteContact(contactId);
        }
        // send new contact to the BLL
        public int addContact(string name, string surname, string homePhone, string mobile1, string mobile2, string mobile3, string workPhone, DateTime? birthday, DateTime? anniversary, string email, string address, Guid userId)
        {
            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(mobile1))
            {
                return -1;
            }
            else
            {
                Contacts newContact = new Contacts
                {
                    contactName = name,
                    contactSurname = surname,
                    mobile = mobile1,
                    mobile2 = mobile2,
                    mobile3 = mobile3,
                    phoneHome = homePhone,
                    phoneWork = workPhone,
                    birthday = birthday,
                    _address = address,
                    anniversary = anniversary,
                    email = email,
                    userId = userId
                };

                BLL.addContact(newContact);
                return 1;
            }

        }
        // send updated contact to the BLL
        public void updateContact(Contacts updatedContact) //update contact
        {
            BLL.updateContact(updatedContact);
        }
        // check file source is empty or not(txtBx_addSource.Text)
        public int fileSourceControl(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                return -1;
            }
            return 1;
        }
        // connect BLL and MainApp, send user and filePath for export json file operation
        public int exportJSON(UserData user, string FilePath)
        {
            return BLL.exportJSON(user, FilePath);
        }
        // connect BLL and MainApp, send user and filePath for export csv file operation
        public int exportCSV(UserData user, string FilePath)
        {
            return BLL.exportCSV(user, FilePath);
        }
        // connect BLL and MainApp, send user and filePath for export xml file operation
        public int exportXML(UserData user, string filePath)
        {
            return BLL.exportXML(user, filePath);
        }
        // connect BLL and MainApp, send user and filePath for import json file operation. return information about (1) is file path and file exist, (2)file path, (3) # of added contacts, (4) # of passed contacts
        public (int, string, int, int) importJSON(string userMail, string filePath)
        {
            var results = BLL.importJSON(userMail, filePath);
            return results;
        }

        // connect BLL and MainApp, send user and filePath for import xml file operation. return information about (1) is file path and file exist, (2)file path, (3) # of added contacts, (4) # of passed contacts
        public (int, string, int, int) importXML(string userMail, string filePath)
        {
            return BLL.importXML(userMail, filePath);
        }
        // connect BLL and MainApp, send user and filePath for import csv file operation. return information about (1) is file path and file exist, (2)file path, (3) # of added contacts, (4) # of passed contacts
        public (int, string, int, int) importCSV(string userMail, string filePath)
        {
            return BLL.importCSV(userMail, filePath);
        }


    }
}