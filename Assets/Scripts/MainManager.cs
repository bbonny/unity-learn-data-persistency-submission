using System.IO;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;

    public string PlayerPseudo;
    public string BestScorePseudo;
    public int BestScorePoints;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
        PlayerPseudo = "AAA";
    }
    [System.Serializable]
    class SaveData
    {
        public int BestScorePoints;
        public string BestScorePseudo;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestScorePoints = BestScorePoints;
        data.BestScorePseudo = BestScorePseudo;

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

            BestScorePoints = data.BestScorePoints;
            BestScorePseudo = data.BestScorePseudo;
        }
    }
}
