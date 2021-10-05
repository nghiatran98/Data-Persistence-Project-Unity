using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;
    public string playerName;

    public string displayTopPlayer;
    public int displayBestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StoreName(string name)
    {
        playerName = name;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveBestScore(string playerName, int bestScore)
    {
        SaveData data = new SaveData();
        data.bestPlayer = playerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            displayTopPlayer = data.bestPlayer;
            displayBestScore = data.bestScore;

        }
    }
}
