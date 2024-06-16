using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Info : MonoBehaviour
{
    public static GameObject panel;
    public static GameObject UI_Panel;
    public static int score;
    public static int best_Score;
    public static float termination_Point;
    public static float coin_termination_Point;
    public static double gameSpeed;
    public static bool isAlive;
    [SerializeField]
    int spawn_distance;
    [SerializeField]
    public static int spawn_Distance;
     private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        score = 0;
        termination_Point = -25;
        coin_termination_Point = -12;
        gameSpeed = 1;
        Time.timeScale = 1;
        best_Score = PlayerPrefs.GetInt("best_Score",0);
        isAlive = true;
        spawn_Distance = spawn_distance;
    }

    private void Update()
    {
        if (score == 150)
        {
            gameSpeed = gameSpeed*1.01;
            Time.timeScale = 1.01f;
        }
    }

}
