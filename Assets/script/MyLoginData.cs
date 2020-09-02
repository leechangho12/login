using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LoginType
{ 
    None,
    Guest,
    Google
}

[System.Serializable]
public class MyLoginData
{
    //public LoginType loginType = LoginType.Guest;
    public LoginType loginType = LoginType.None;
    public string user_id = string.Empty;
    public string user_token = string.Empty;
    public string email = string.Empty;

}
