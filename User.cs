namespace AppConsole
{
    class User
    {
        public string Name { get;  set; }
        public string Age { get;  set; }
        public string Email { get; set; }
        
        public void ExibeInfo()
        {
            System.Console.WriteLine($"Name: {Name}\nAge: {Age}\nEmail: {Email}");
        }
    }
}