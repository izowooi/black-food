using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    public Button testButton;

    private void Start()
    {
        Debug.Log("Start");
        //MoveToIngameScene();
    }

    public void MoveToIngameScene()
    {
        Debug.Log("Move to Ingame Scene");
        CitizenManager.Instance.AssignCitizens();
        CitizenManager.Instance.StartNewDay();
        SceneManager.LoadScene("IngameScene");
        testButton.onClick.AddListener(LogHello);

    }
    
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    
    public void LogHello()
    {
        Debug.Log("Hello");
    }
}
