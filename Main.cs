namespace AppConsole
{
    class App
    {
        static void Main(string[] args)
        {

            User user = new User();

            user.Name = "Artur";
            user.Age = "20";
            user.Email = "arturvargas@gmail.com";

            JsonSerializator<User> userJsonSerializator = new JsonSerializator<User>();
            string userJson = userJsonSerializator.Serialize(user);

            User userDes = userJsonSerializator.Deserialize(userJson);
           
            Console.WriteLine(userJson);
            userDes.ExibeInfo();
        }
    }
}