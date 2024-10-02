using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    public string userName = "";
    public string highScoreUserName = "";
    public int highScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadDataFile();
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public string highScoreUserName;
        public int highScore;
    }

    public void SaveDataFile()
    {
        SaveData data = new SaveData();
        data.userName = userName;
        data.highScoreUserName = highScoreUserName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
            highScoreUserName = data.highScoreUserName;
            highScore = data.highScore;
        }

    }
}
