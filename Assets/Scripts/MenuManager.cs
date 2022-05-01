using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;

    private void Start()
    {
        if (GeneralManager.Instance.sessionName != "Lazy")
        {
            nameField.text = GeneralManager.Instance.sessionName;
        }
    }
    public void ChangeSessionName()
    {
        GeneralManager.Instance.sessionName = nameField.text;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit;
#endif
    }
}
