using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager Instance;
    public string playerName;
    public string sessionName = "Lazy";
    public int highScore;
    public TMP_Text highScoreText;

    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            highScore = 0;
            playerName = "NA";
            Save();
            SceneManager.LoadScene(0);
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        Load();
    }

    public void MainMenuScore()
    {
        highScoreText.text = $"High Score| {playerName} : {highScore}";
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
        else
        {
            playerName = "NA";
        }
    }
}
