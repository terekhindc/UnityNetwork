using UnityEngine;

public class Token : INetClient
{    

    public override void SetConnection()
    {
        connect = gameObject.AddComponent<NetworkProcessing>();

        connect.AddFormData("grant_type", "password");
        connect.AddFormData("username", "SvetTrain");
        connect.AddFormData("password", "Train!12");

        connect.Post(url, this);
    }

    public override void GetResult (object data)
    {             
        DataProcessing(data as string);
    }

    public void DataProcessing (string json)
    {
        TokenData tokenData = TokenData.GetFromJSON(json);
        print("Token type: " + tokenData.token_type);
        print("Access token: " + tokenData.access_token);
        NetworkManager.Instance.tokenData = tokenData;
        Destroy(connect);

        if (AppModeController.mode == AppModeController.Mode.Active) 
        NetworkManager.Instance.GetActiveData();
        else
        {
            NetworkManager.Instance.GetRelaxData();
        }

        Destroy(connect);
    }
}

[System.Serializable]
public class TokenData
{
    [HideInInspector] public string token_type;
    [HideInInspector] public string access_token;
    [HideInInspector] public int expires_in;

    public static TokenData GetFromJSON(string json)
    {
        return JsonUtility.FromJson<TokenData>(json);
    }
}
