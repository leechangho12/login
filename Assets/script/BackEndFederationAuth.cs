
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using System.Text;
public class BackEndFederationAuth : MonoBehaviour
{
    public Text LogText;
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration
            .Builder()
            .RequestServerAuthCode(false)
            .RequestEmail()                 // 이메일 요청
            .RequestIdToken()               // 토큰 요청
            .Build();

        //커스텀된 정보로 GPGS 초기화
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;

        //GPGS 시작.
        PlayGamesPlatform.Activate();
        //GoogleAuth();
    }

    // 구글에 로그인하기
    private void GoogleAuth()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(success =>
            {
                if (success == false)
                {
                    LogText.text = "구글 로그인 실패";
                    Debug.Log("구글 로그인 실패");
                    return;
                }

                //// 로그인이 성공되었습니다.
                //{

                //    string authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
                //    string clientid = "209464208604-3oo3d91mu1u6p8u6drjci36vg7jpmv5q.apps.googleusercontent.com";
                //    string secret = PlayGamesPlatform.Instance.GetServerAuthCode();
                //    string redirectURI = PlayGamesPlatform.Instance.GetServerAuthCode();

                //    var request = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");

                //    string postData = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code", authCode, clientid, secret, redirectURI);
                //    var data = Encoding.ASCII.GetBytes(postData);

                //    request.Method = "POST";
                //    request.ContentType = "application/x-www-form-urlencoded";
                //    request.ContentLength = data.Length;

                //    using (var stream = request.GetRequestStream())
                //    {
                //        stream.Write(data, 0, data.Length);
                //    }

                //    var response = (HttpWebResponse)request.GetResponse();

                //    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //    Debug.Log(responseString);

                //}

                WebPktSend.Send_WeReq_102_GooGleLogin(Social.localUser.id, PlayGamesPlatform.Instance.GetIdToken(), ((PlayGamesLocalUser)Social.localUser).Email);

                string info;
                info = "GetIdToken - " + PlayGamesPlatform.Instance.GetIdToken() + "\n" +
                "Email - " + ((PlayGamesLocalUser)Social.localUser).Email + "\n" +
                "GoogleId - " + Social.localUser.id + "\n" +
                "UserName - " + Social.localUser.userName + "\n" +
                "UserName - " + PlayGamesPlatform.Instance.GetUserDisplayName();

                LogText.text = info;
                Debug.Log("GetIdToken - " + PlayGamesPlatform.Instance.GetIdToken());
                Debug.Log("Email - " + ((PlayGamesLocalUser)Social.localUser).Email);
                Debug.Log("GoogleId - " + Social.localUser.id);
                Debug.Log("UserName - " + Social.localUser.userName);
                Debug.Log("UserName - " + PlayGamesPlatform.Instance.GetUserDisplayName());
                Debug.Log("test - " + PlayGamesPlatform.Instance.GetServerAuthCode());
            });
        }
    }
    

    // 구글 토큰 받아오기
    private string GetTokens()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // 유저 토큰 받기 첫번째 방법
            string _IDtoken = PlayGamesPlatform.Instance.GetIdToken();
            // 두번째 방법
            // string _IDtoken = ((PlayGamesLocalUser)Social.localUser).GetIdToken();
            return _IDtoken;
        }
        else
        {
            Debug.Log("접속되어있지 않습니다. 잠시 후 다시 시도하세요.");
            GoogleAuth();
            return null;
        }
    }
    public void LogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        LogText.text = "구글 로그아웃";
    }

}