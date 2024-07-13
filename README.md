# PHONE APPLICATION 
  &nbsp;&nbsp;&nbsp;&nbsp;Aim of this project is to create a phone application. MSSQL is used to store data of users and contacts. Additionally, stored procedures are used for update, delete and insert operations. Users can add new contacts while importing files in xml, csv or json formats. Users can also export their contacts in csv, json or xml file formats according to the necessities. 
  
  &nbsp;&nbsp;&nbsp;&nbsp;The project is created with .Net 6 Framwork. N-layer architecture principles are utilized in this project. Six layers are created to build the project.These are Windows Form Layer, Validation Layer, Business Logic Layer, Transformation Layer, Database Logic Layer and Entity Layer. Windows Form Layer is designed
to interact with users. Sign In, Sign Up and Main App forms are created in the layer. The Validation Layer is created to control user inputs; based on the controls(results), users are informed. The Validation 
layer also provides connection between the Windows Form Layer and the Business Logic Layer. It controls user inputs and sends them to BLL according to the operation. Then, returns required data 
to the Windows Form Layer. The Business Logic Layer is created to perform operations like importing/exporting json, xml and csv files and related methods. The Transformation layer is created to convert row data,
which is retrieved from database, to required entity type. Then, the Transformation Layer sends the data to the Business Logic Layer. The Transformation Layer also provides connection between the Business Logic Layer and the Database Logic Layer. Database Logic Layer provides a connection between the 
application and the MSSQL database. The Database Logic Layer retrieves row data from MSSQL database and inserts/sends row data to the MSSQL. The Entity Layer is created to define contacts(Contacts) and user(UserData) types. 

## DEMO VERSION OF PHONE APPLICATION
### Sign In/Sign Up and Add Contact Operations
<img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExbjhoaWlsYWkyZnRhdDVieDNob210Z2dvZ2o4czZpb25uaHhoejFkaiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/LgBQTAcc1eEQ0PygvC/giphy.gif" height="300" width="500">

### Edit/Update-Delete and Import/Export Operations
<img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExbTVsdWE1b25zOXNtem84emt3cnh1MW9rOWo0bTY3NW45bHg4eXZ4eSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/sI10DwMs1YiKo12WeK/giphy.gif" height="300" width="500">

<img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExMTF5N2R4NTFrdTNuczM4czYxaWR1cTQ2YXE1dnhkMmVzemxzaGoybiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/iAww1zYVvHOGSodmaO/giphy.gif" height="300" width="500">
