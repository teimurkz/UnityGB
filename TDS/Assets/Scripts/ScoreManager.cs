﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    

    private void Update()
    {
        scoreDisplay.text = "Убито дурачков:" + score.ToString();
    }

    public void Kill()
    {
        score++;
    }

}
