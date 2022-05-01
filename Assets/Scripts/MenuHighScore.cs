using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GeneralManager.Instance.highScoreText = gameObject.GetComponent<TMP_Text>();
        GeneralManager.Instance.MainMenuScore();
    }
}
