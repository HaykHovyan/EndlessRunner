using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
[SerializeField]
GameObject UI_Panel;
[SerializeField]
Text OK_scoreText;
[SerializeField]
Text bestScoreText;
[SerializeField]
Text loseScoreText;

Text scoreText;


    void Awake()
    {
        if (Game_Info.panel == null)
        {
            Game_Info.panel = panel;
        }
    }
private void Start()
{
    scoreText = OK_scoreText.GetComponent<Text>();
    Game_Info.UI_Panel = UI_Panel;
    scoreText.fontSize = 14;
    scoreText.text = "Score:";
    scoreText.alignByGeometry = true;

    bestScoreText.fontSize = 14;
    bestScoreText.text = "Best Score:";
    bestScoreText.alignByGeometry = true;

    loseScoreText.fontSize = 20;
    loseScoreText.text = "Your Score:";
}

private void Update()
{
    scoreText.text = "Score: " + Game_Info.score;
    bestScoreText.text = "Best Score: " + Game_Info.best_Score;
    loseScoreText.text = "Your Score: " + Game_Info.score;


    if (Game_Info.score > PlayerPrefs.GetInt("best_Score", 0))
    {
        PlayerPrefs.SetInt("best_Score", Game_Info.score);
    }
}
}
