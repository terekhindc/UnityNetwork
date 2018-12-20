using System.Text;
using System;
using UnityEngine;
using System.Collections.Generic;

public class Connect : INetClient, IDataManager {

    public int Sunrise { get; set; }
    public int Sunset { get; set; }
    public int Start { get; set; }
    public int Finish { get; set; }
    public RGB Red { get; set; }
    public RGB Green { get; set; }
    public RGB Blue { get; set; }

    Data json = new Data();

    public override void SetConnection()
    {
        connect = gameObject.AddComponent<NetworkProcessing>();

        print("Start connect");

        connect.Get(url, this, NetworkManager.Instance.tokenData);
    }

    public override void GetResult(object data)
    {
        json.GetHash(data as string);
        json.GetData();
        json.Print();
        json.SaveData(this);

        NetworkManager.Instance.isFinished = true;

        Destroy(connect);
    }

}