using UnityEngine;
using System;
using System.Text;

public class Data
{
    string json;
    ActiveData data = new ActiveData();

    public void GetHash (string json)
    {
        Hash hash = new Hash();
        hash = Hash.GetFromJSON(json);
        byte[] decodedBytes = Convert.FromBase64String(hash.content);
        this.json = Encoding.UTF8.GetString(decodedBytes);
    }

    public void GetData ()
    {
        data = ActiveData.GetFromJSON(json);
        data.red = data.RGB[0];
        data.green = data.RGB[1];
        data.blue = data.RGB[2];
    }

    public void Print ()
    {
        Debug.Log("Восход: " + data.sunrise);
        Debug.Log("Закат: " + data.sunset);
        Debug.Log("Start: " + data.start);
        Debug.Log("Finish: " + data.finish);
        Debug.Log("Color: " + data.red.color);

        for (int i = 0; i < data.red.frequencies.Length; i++)
        {
            Debug.Log("delay: " + data.red.frequencies[i].delay);
            Debug.Log("frequency: " + data.red.frequencies[i].frequency);
        }

        Debug.Log("Color: " + data.green.color);
        for (int i = 0; i < data.green.frequencies.Length; i++)
        {
            Debug.Log("delay: " + data.green.frequencies[i].delay);
            Debug.Log("frequency: " + data.green.frequencies[i].frequency);
        }

        Debug.Log("Color: " + data.blue.color);
        for (int i = 0; i < data.blue.frequencies.Length; i++)
        {
            Debug.Log("delay: " + data.blue.frequencies[i].delay);
            Debug.Log("frequency: " + data.blue.frequencies[i].frequency);
        }
    }

    public void SaveData(IDataManager dataManager)
    {
        dataManager.Sunrise = data.sunrise;
        dataManager.Sunset = data.sunset;
        dataManager.Start = data.start;
        dataManager.Finish = data.finish;
        dataManager.Red = data.red;
        dataManager.Green = data.green;
        dataManager.Blue = data.blue;
    }
}

[System.Serializable]
public class Hash
{
    public string content;
    public string hash;

    public static Hash GetFromJSON(string json)
    {
        return JsonUtility.FromJson<Hash>(json);
    }
}

[System.Serializable]
public class ActiveData
{
    public int sunrise;
    public int sunset;
    public int start;
    public int finish;
    public RGB [] RGB;

    public static ActiveData GetFromJSON(string json)
    {
        return JsonUtility.FromJson<ActiveData>(json);
    }

    public RGB red = new RGB();
    public RGB green = new RGB();
    public RGB blue = new RGB();

}

[System.Serializable]
public class RGB
{
    public string color;
    public frequencies [] frequencies;
}

[System.Serializable]
public class frequencies
{
    public double delay;
    public double frequency;
}