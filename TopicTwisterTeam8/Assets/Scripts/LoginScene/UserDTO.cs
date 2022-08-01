using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlasticGui;


public class UserDTO
{
    public int id { get; set; }
    public string name { get; set; }
    
}

public class LoggedUserDTO
{
    public int id { get; set; }
    public string name { get; set; }
    public static string PlayerName { get; set; }
    
    public string email { get; set; }
    
    public int coin { get; set; }
}

