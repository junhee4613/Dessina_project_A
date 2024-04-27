﻿using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController2 PlayerController2;
    private TextMeshProUGUI  textScore;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Text UI에 현재 점수 정보를 업데이트
        textScore.text = "Score "+PlayerController2.Score;

    }
}


/*
 * File : PlayerScoreView.cs
 * Desc
 *	: 플레이어의 점수 정보를 Text UI에 업데이트
 *	
 */