using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject CanvasPanel;
    public Canvas MyCanvas;
    public InputField PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //print("Player name is:" + PlayerName.text);
    }


    public void StartButtonHandler() {
        CanvasPanel.SetActive(false);
        MyCanvas.gameObject.SetActive(false);
        //string playerName = PlayerName.text;
        PlayerPrefs.SetString("PlayerName", PlayerName.text);
        print("Store value is: " + PlayerPrefs.GetString("PlayerName"));
    }

    public void QuitButtonHandler() {
        Application.Quit();
        print("Game would quit here");
    }
    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        Debug.Log("Game Ends");
        Time.timeScale = 0;
    }
}
