using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScoreTracker : MonoBehaviour
{

    public static HighScoreTracker Instance;
    public int highScore;
    public string highScoreplayerName;
    public string playerName;


    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScoreData;
        public string highScoreName;
    }

    public void SaveHighScore(int newScore, string newHighScoreName)
    {
        highScore = newScore;
        highScoreplayerName = newHighScoreName;
        SaveData data = new SaveData();
        data.highScoreData = highScore;
        data.highScoreName = highScoreplayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScoreData;
            highScoreplayerName = data.highScoreName;
        }
    }

  


}
