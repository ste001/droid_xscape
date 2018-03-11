﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    [SerializeField] int pointsPerHit = 50;
    int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}

    public void ScoreHit()
    {
        score += pointsPerHit;
        scoreText.text = score.ToString();
    }
}
