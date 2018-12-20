using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkProcessing : MonoBehaviour
{
    public bool isDownloaded;            

    public Dictionary<string, string> formData = new Dictionary<string, string>();

    public string StatusConnection { get; private set; }

    public void AddFormData(string key, string value)
    {
        formData.Add(key, value);
    }
    
    public object body { get; private set; }
    
    public void Post (string url, INetClient client)
    {
        StartCoroutine(AsyncPost(url, client));
    }
    
    public IEnumerator AsyncPost(string url, INetClient client)
    {
        UnityWebRequest www;
        
        WWWForm dataParameters = new WWWForm();

        foreach(KeyValuePair<string, string> keyValue in formData)
        {
            dataParameters.AddField(keyValue.Key, keyValue.Value);
        }        

        using (www = UnityWebRequest.Post(url, dataParameters))
        {
            
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                client.Break();
                Debug.Log(www.error);
                StatusConnection = "network connection: wait";
            }
            else
            {
                StatusConnection = "network connection: established";

                while (!www.isDone)
                {
                    isDownloaded = false;
                    yield return new WaitForSeconds(0.5f);
                }                

                body = www.downloadHandler.text;                

                client.GetResult(body);
            }
        }

    }

    public void Get(string url, INetClient client, TokenData token)
    {
        StartCoroutine(AsyncGet(url, client, token));
    }

    public IEnumerator AsyncGet(string url, INetClient client, TokenData token)
    {
        UnityWebRequest www;        

        using (www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("AUTHORIZATION", token.token_type + " " + token.access_token);

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                client.Break();
                Debug.Log(www.error);
                StatusConnection = "network connection: wait";

            }
            else
            {
                StatusConnection = "network connection: established";

                while (!www.isDone)
                {
                    isDownloaded = false;
                    yield return new WaitForSeconds(0.5f);
                }

                body = www.downloadHandler.text;

                client.GetResult(body);
            }
        }

    }
}
