using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public static UIScore instance;

    public Text levelText;
    public Text scoreText;
    public Text layersText;

    public GameObject GameOverScreen;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameOverScreen.SetActive(false);
    }

    public void UpdateUI(int level, int score, int layers)
    {
        levelText.text = "Level: "+ level.ToString("D2");
        scoreText.text = "Score: " + score.ToString("D9");
        layersText.text = "Layers: " + layers.ToString("D9");
    }

    public void ActiveGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }
}
