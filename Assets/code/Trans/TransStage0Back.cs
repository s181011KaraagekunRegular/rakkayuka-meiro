﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransStage0Back : MonoBehaviour
{

    // Use this for initialization
    public void OnClick()
    {
        // メインシーンへ移動
        SceneManager.LoadScene("StageSelect");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}