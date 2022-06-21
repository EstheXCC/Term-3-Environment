using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startBtn;
    void Start()
    {
        startBtn = GameObject.Find("StartButton").GetComponent<Button>();
        startBtn.onClick.AddListener(StartB);
    }

    private void StartB()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        
    }
}
