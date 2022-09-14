using System.Security.Principal;

Console.WriteLine("Hello World ");
public class ExeProjectWindows
{
    public static string GetName()
    {
        
        return WindowsIdentity.GetCurrent().Name;
    }
}