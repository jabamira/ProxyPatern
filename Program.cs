using Proxy_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        ISubject ProxyAdmin = new Proxy("Admin");

        Console.WriteLine(ProxyAdmin.Request("Request1"));
        Console.WriteLine("/////////////////////////////");
        Console.WriteLine(ProxyAdmin.Request("Request1"));
        Console.WriteLine("/////////////////////////////");
        Console.WriteLine(ProxyAdmin.Request("Request2"));
        Console.WriteLine("/////////////////////////////");
       ISubject ProxyGuest = new Proxy("Guest");

        Console.WriteLine(ProxyGuest.Request("Request1"));
        Console.WriteLine(ProxyGuest.Request("Request2"));
        Console.WriteLine("/////////////////////////////");
        ISubject ProxyManager = new Proxy("Manager");

        Console.WriteLine(ProxyManager.Request("Request1"));
        Console.WriteLine(ProxyManager.Request("Request2"));
        Console.WriteLine(ProxyManager.Request("Request3"));
        
    }
}