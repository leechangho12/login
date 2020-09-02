using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnClickGuestLogin()
    {
        LocalDataMgr.myLoginData.loginType = LoginType.Guest;

        if (RegUtil.Read_String("user_id",ref LocalDataMgr.myLoginData.user_id))
        {
            RegUtil.Read_String("user_token", ref LocalDataMgr.myLoginData.user_token);
            RegUtil.Read_String("email", ref LocalDataMgr.myLoginData.email);
            int _loginType = 0;
            RegUtil.Read_Int("LoginType", ref _loginType);
            LocalDataMgr.myLoginData.loginType = (LoginType)_loginType;

        }
        else
        {
            WebPktSend.Send_WebReq_101_Guest();

            RegUtil.Write_String("user_id", LocalDataMgr.myLoginData.user_id);
            RegUtil.Write_String("user_token", LocalDataMgr.myLoginData.user_token);
            RegUtil.Write_String("email", LocalDataMgr.myLoginData.email);
            RegUtil.Write_Int("LoginType", (int)LocalDataMgr.myLoginData.loginType);
        }


    }
}
