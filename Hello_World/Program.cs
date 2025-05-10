using PasswordGenerator;
Console.WriteLine("Enter your name: ");
var name= Console.ReadLine();
var date= DateTime.Now;

var pwd= new Password();
var password=pwd.Next();

Console.WriteLine($"{Environment.NewLine}Hello ,{name} , today is ,{date}, password is {password}.");

Console.ReadKey(true);