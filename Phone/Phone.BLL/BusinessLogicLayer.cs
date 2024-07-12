using Phone.Entities;
using Phone.TL;
using System.Xml.Serialization;

namespace Phone.BLL
{
    public class BusinessLogicLayer
    {

        TransformationLayer TL;

        public BusinessLogicLayer()
        {
            TL = new TransformationLayer();
        }

        public int userMailControl(string email) // control that do userMail exist in the database
        {
            int result = TL.userAccountControl(email); // if the email exists in the sql database returns 1, otherwise returns -1.
            if (result == 1)
            {
                return 1; // if email exists return 1
            }
            else
            {
                return 0; // if email does not exists return 0
            }

        }

        public int addNewUser(string userName, string email, string password)
        {
            UserData userData = new UserData
            {
                userName = userName,
                email = email,
                _password = password
            };
            TL.sendNewUserToDLL(userData);
            return 1;
        } // add new user, send it to transformation layer

        // get user for login operation (control the email and password from database via TL and DLL layers)
        public UserData getUserToVL(string email, string password)
        {
            return TL.getUserToBLL(email, password);
        }

        public List<Contacts> getAllContactsToVL(Guid UserId) // send all contact to validation layer of main app
        {
            return TL.getAllContactsToBLL(UserId);
        }

        // delete contacts from database (via TL and DLL layers)
        public void deleteContact(Guid ContactId)
        {
            TL.deleteContact(ContactId);
        }
        // add contacts to the mssql server database (via TL and DLL layers)
        public void addContact(Contacts contact)
        {
            TL.addContact(contact);
        }
        // update contact information (via TL and DLL layers)
        public void updateContact(Contacts contact)
        {
            TL.updateContact(contact);
        }
        // export contacts in json file for a user (via TL and DLL layers)
        public int exportJSON(UserData user, string filePath)
        {
            List<Contacts> contacts = getAllContactsToVL(user.userId);

            string JsonText = Newtonsoft.Json.JsonConvert.SerializeObject(contacts);
            var results = createFileForExport(filePath, user.email, ".json");

            if (results.Item1 == 1)
            {
                File.WriteAllText(results.Item2, JsonText);
                return 1;
            }
            else
                return -1;
        }
        //export contacts in xml file for a user (via TL and DLL layers)
        public int exportXML(UserData user, string filePath)
        {
            var results = createFileForExport(filePath, user.email, ".xml");
            List<Contacts> contactsList = getAllContactsToVL(user.userId);
            if (results.Item1 == 1)
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Contacts>));
                string xmlString;
                using (var stringWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(stringWriter, contactsList);
                    xmlString = stringWriter.ToString();
                };
                File.WriteAllText(results.Item2, xmlString);
                return 1;
            }
            else
            {
                return -1;
            }


        }
        // export contacts in csv file for a user (via TL and DLL layers)
        public int exportCSV(UserData user, string filePath)
        {
            List<Contacts> contactsList = getAllContactsToVL(user.userId);
            var results = createFileForExport(filePath, user.email, ".csv");
            if (results.Item1 == 1)
            {
                using (StreamWriter writer = new StreamWriter(results.Item2))
                {
                    writer.WriteLine("contactId,userId,contactName, contactSurname, phoneHome, mobile, mobile2, mobile3, phoneWork, birthday, anniversary, email, _address");
                    foreach (Contacts contact in contactsList)
                    {
                        writer.WriteLine($"{contact.contactId},{contact.userId},{contact.contactName},{contact.contactSurname},{contact.phoneHome},{contact.mobile},{contact.mobile2},{contact.mobile3},{contact.phoneWork},{contact.birthday},{contact.anniversary},{contact.email},{contact._address}");
                    }
                }
                return 1;
            }
            else return -2;
        }
        // add new contacts from a json file (via TL and DLL layers)
        public (int, string, int, int) importJSON(string userMail, string _filePath)
        {
            var addedPassedContacts = (0, 0);
            int result = 1;
            string filePath = @$"{_filePath}\{userMail}.json";
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                List<Contacts> contactsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contacts>>(jsonString);
                addedPassedContacts = addContactsList(contactsList);
            }
            else result = -2;
            return (result, filePath, addedPassedContacts.Item1, addedPassedContacts.Item2);

        }
        // add new contacts from an xml file (via TL and DLL layers)
        public (int, string, int, int) importXML(string userMail, string _filePath)
        {
            var addedPassedContacts = (0, 0);
            string filePath = @$"{_filePath}\{userMail}.xml";
            try
            {
                List<Contacts> contactsList;
                var serializer = new XmlSerializer(typeof(List<Contacts>));
                using (var reader = new StreamReader(filePath))
                {
                    contactsList = (List<Contacts>)serializer.Deserialize(reader);
                }
                addedPassedContacts = addContactsList(contactsList);

                return (1, filePath, addedPassedContacts.Item1, addedPassedContacts.Item2);
            }
            catch
            {
                return (-1, filePath, addedPassedContacts.Item1, addedPassedContacts.Item2);
            }
        }
        // add new contacts from a csv file (via TL and DLL layers)
        public (int, string, int, int) importCSV(string userMail, string _filePath)
        {
            var addedPassedContacts = (0, 0);
            string filePath = @$"{_filePath}\{userMail}.csv";
            List<Contacts> newContactsList = new List<Contacts>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        var separatedLine = line.Split(',');
                        Contacts contact = new Contacts
                        {
                            contactId = Guid.Parse(separatedLine[0]),
                            userId = Guid.Parse(separatedLine[1]),
                            contactName = separatedLine[2].ToString(),
                            contactSurname = separatedLine[3].ToString(),
                            phoneHome = separatedLine[4].ToString(),
                            mobile = separatedLine[5].ToString(),
                            mobile2 = separatedLine[6].ToString(),
                            mobile3 = separatedLine[7].ToString(),
                            phoneWork = separatedLine[8].ToString(),

                            birthday = !string.IsNullOrWhiteSpace(separatedLine[9]) ? DateTime.Parse(separatedLine[9]) : (DateTime?)null,
                            anniversary = !string.IsNullOrWhiteSpace(separatedLine[10]) ? DateTime.Parse(separatedLine[10]) : (DateTime?)null,
                            email = separatedLine[11].ToString(),
                            _address = separatedLine[12].ToString()

                        };
                        newContactsList.Add(contact);

                    }
                    addedPassedContacts = addContactsList(newContactsList);
                }
                return (1, filePath, addedPassedContacts.Item1, addedPassedContacts.Item2);
            }
            catch
            {
                return (-1, filePath, addedPassedContacts.Item1, addedPassedContacts.Item2);
            }
        }

        // helper methods ----------------------------------------
        // create file for export operation
        public (int, string) createFileForExport(string filePath, string userMail, string fileFormat)
        {
            if (fileFormat == ".json")
            {
                filePath = filePath + "\\" + userMail + ".json";
            }
            else if (fileFormat == ".xml")
            {
                filePath = filePath + "\\" + userMail + ".xml";
            }
            else
            {
                filePath = filePath + "\\" + userMail + ".csv";
            }
            try
            {
                if (!File.Exists(@filePath))
                {
                    using (var createdFile = File.Create(@filePath)) { };
                }
                return (1, filePath);
            }
            catch
            {
                return (-1, filePath);
            }
        }

        // add all contacts from imported files
        public (int, int) addContactsList(List<Contacts> contactsList)
        {
            int addedContacts = 0;
            int passedContacts = 0;
            foreach (Contacts contact in contactsList)
            {
                try
                {
                    addContact(contact);
                    addedContacts += 1;
                }
                catch
                {
                    passedContacts += 1;
                }
            }
            return (addedContacts, passedContacts);
        }
    }
}