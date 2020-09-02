using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebPktSend : MonoBehaviour
{
    
    public static void Send_WebReq_101_Guest()
    {
        string strUrl = string.Format("{0}/USER/udata.aspx?u1=101",WebPktBase.key_Addr);
        WebPktBase.instance.SendWebRequest(strUrl);
    }

    public static void Send_WeReq_102_GooGleLogin(string id,string token,string email)
    {
        string strUrl = string.Format("{0}/USER/udata.aspx?u1=102&u2={1}&u3={2}&u4={3}&u5=1", WebPktBase.key_Addr,id,token,email);
        Debug.Log(strUrl);
        WebPktBase.instance.SendWebRequestGoogle(strUrl);

    }
}
