using System;
using UnityEngine;

public abstract class INetClient : MonoBehaviour {
    
    public string url;
    [HideInInspector]public NetworkProcessing connect;

    public abstract void GetResult(object data);
    public abstract void SetConnection();

    public virtual void Break()
    {
        print("Break connect");
        NetworkManager.Instance.isFinished = true;
        Destroy(connect);
    }
}
