namespace Phone.WFUI
{
    // create singleton class
    public sealed class FormControl
    {
        // create an instance of the class
        private static readonly FormControl instance = new FormControl();

        // properties for forms instances
        public Form1 form1 { get; private set; }
        public MainApp mainApp { get; private set; }
        public Form_SignUp formSignUp { get; private set; }

        private FormControl()
        {
            form1 = new Form1();
            mainApp = new MainApp();
            formSignUp = new Form_SignUp();
        }

        // you can access singleton instances/class with this part of the code
        public static FormControl Instance
        {
            get
            {
                return instance;
            }
        }
    }
}

