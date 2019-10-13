using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //print("startint gameover script");
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }

            if (Input.GetKeyDown("q"))
            {
                Application.Quit();
            }

            if (Input.GetKeyDown("b"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        //print("WE at game over");
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
