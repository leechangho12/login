using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using LitJson;
public class WebPktBase : MonoBehaviour
{

    private static WebPktBase slnstance;
    public static WebPktBase instance
    {
        get
        {
            if (slnstance == null)
            {
                GameObject newGameObject = new GameObject("_WebPktBase");
                slnstance = newGameObject.AddComponent<WebPktBase>();
            }
            return slnstance;

        }
    }
    private void Awake()
    {
        if (slnstance == null)
            slnstance = this;

        DontDestroyOnLoad(this.gameObject);

    }

    const string KEY_ADDR = "http://192.168.0.8:8077";

    public static string key_Addr { get { return KEY_ADDR; } }
    void Start()
    {
    }

    public void SendWebRequest(string url)
    {
        //StartCoroutine(GetRequest(url));      

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        Debug.Log("Received: " + json);

        JsonData jsonData = JsonMapper.ToObject(json);

        JsonData jsonDataArrey = jsonData["rows"];

        LocalDataMgr.myLoginData.user_id = (string)jsonDataArrey[0]["user_id"];
        Debug.Log("user_id: " + jsonDataArrey[0]["user_id"]);
        LocalDataMgr.myLoginData.user_token = (string)jsonDataArrey[0]["user_token"];
        Debug.Log("user_token: " + jsonDataArrey[0]["user_token"]);
        LocalDataMgr.myLoginData.email = (string)jsonDataArrey[0]["email"];
        Debug.Log("email: " + jsonDataArrey[0]["email"]);
      
    }
    public void SendWebRequestGoogle(string url)
    {
        //StartCoroutine(GetRequest(url));      

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        Debug.Log("Received: " + json);

        //JsonData jsonData = JsonMapper.ToObject(json);

        //JsonData jsonDataArrey = jsonData["rows"];

        //LocalDataMgr.myLoginData.user_id = (string)jsonDataArrey[0]["user_id"];
        //Debug.Log("user_id: " + jsonDataArrey[0]["user_id"]);
        //LocalDataMgr.myLoginData.user_token = (string)jsonDataArrey[0]["user_token"];
        //Debug.Log("user_token: " + jsonDataArrey[0]["user_token"]);
        //LocalDataMgr.myLoginData.email = (string)jsonDataArrey[0]["email"];
        //Debug.Log("email: " + jsonDataArrey[0]["email"]);

    }

    IEnumerator GetRequest(string url)
    {

        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();

        Debug.Log("url: " + url);


        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            string json = uwr.downloadHandler.text;


            //LocalDataMgr.myLoginData = JsonHelper.FromJson<MyLoginData>(json);
            
            MyLoginData _myLoginData = JsonHelper.FromJson<MyLoginData>(json);
            Debug.Log("GuestID: " + _myLoginData.user_id);
            Debug.Log("GuestToken: " + _myLoginData.user_token);
            Debug.Log("email: " + _myLoginData.email);

        }

    }
    //IEnumerator GetRequest(string uri)
    //{
    //    UnityWebRequest uwr = UnityWebRequest.Get(uri);
    //    yield return uwr.SendWebRequest();

    //    if (uwr.isNetworkError)
    //    {
    //        Debug.Log("Error While Sending: " + uwr.error);
    //    }
    //    else
    //    {
    //        Debug.Log("Received: " + uwr.downloadHandler.text);
    //    }
    //}
    
}
