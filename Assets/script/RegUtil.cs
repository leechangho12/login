using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegUtil 
{
    static void WriteText_native(string key,string text)
    {
        PlayerPrefs.SetString(key, text);
        Debug.Log("키생성");

    }
    static void WriteText_native(string key, int text)
    {
        PlayerPrefs.SetInt(key, text);
        Debug.Log("키생성");

    }

    public static void Write_String(string key, string text)
    {
        WriteText_native(key,text);
    }
    public static void Write_Int(string key, int text)
    {
        WriteText_native(key, text);
    }

    static bool ReadText_Native(string key,out string v)
    {
        v = string.Empty;
        if(string.IsNullOrEmpty(key))
        {
            Debug.Log("KeyNULL");
            return false;
        }

        if(!PlayerPrefs.HasKey(key))
        {
            Debug.Log("PlayerPrefsKeyNULL");
            return false;
        }

        v = PlayerPrefs.GetString(key);

        if(!string.IsNullOrEmpty(v))
        {
            Debug.Log("PlayerPrefsKeyExistence");

            return true;
        }

        return false;
    }
    
    public static bool Read_String(string key,ref string v)
    {
        string str = string.Empty;
        if(ReadText_Native(key,out str))
        {
            v = str;
            return true;
        }

        return false;
    }
    public static bool Read_Int(string key, ref int v)
    {
        string str = string.Empty;
        if (Read_String(key, ref str))
        {
            int n = 0;
            if (int.TryParse(str, out n))
            {
                v = n;
                return true;
            }
        }

        return false;
    }
}
