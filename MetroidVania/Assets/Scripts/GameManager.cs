﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        Debug.Log("Game Ends");
        Time.timeScale = 0;
    }
}