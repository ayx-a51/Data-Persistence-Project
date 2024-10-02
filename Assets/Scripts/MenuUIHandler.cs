using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text highScoreText;
    public TMP_InputField nameInput;

    private void Start()
    {
        LoadData();
    }

    public void StartNew()
    {
        HighscoreManager.Instance.userName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        HighscoreManager.Instance.SaveDataFile();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
    public void LoadData()
    {
        HighscoreManager.Instance.LoadDataFile();

        if (HighscoreManager.Instance.highScore > 0)
        {
            highScoreText.text = "Best Score: " + HighscoreManager.Instance.highScore + " (" + HighscoreManager.Instance.highScoreUserName + ")";
        }
        else
        {
            highScoreText.text = "";
        }

        if (HighscoreManager.Instance.userName != "")
        {
            nameInput.text = HighscoreManager.Instance.userName;
        }
    }
}
