using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    string gameScene_Name;
    [SerializeField]
    string homeScene_Name;
    [SerializeField]
    GameObject pausePanel;


    public void Retry()
    {
        SceneManager.LoadScene(gameScene_Name);
        Game_Info.gameSpeed = 1;
        Time.timeScale = 1;
    }

    public void Home_Scene()
    {
        SceneManager.LoadScene(homeScene_Name);
    }

    public void Pause_Game()
    {
        Game_Info.gameSpeed = 0;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Return()
    {
        Game_Info.gameSpeed = 1;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
