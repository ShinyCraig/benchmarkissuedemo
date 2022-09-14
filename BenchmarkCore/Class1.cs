using System.Security.Principal;

namespace BenchmarkCore;

public class Class1
{
    public static string GetName()
    {
        
        return WindowsIdentity.GetCurrent().Name;
    }
}