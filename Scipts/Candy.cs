using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Candy : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float levelCompleteTimer;
    float gameOverTimer;

    AudioSource boingA;
    AudioSource Crunch;
    AudioSource boingC;

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteTimer = 5.0f;
        gameOverTimer = 5.0f;
        rigidBody = GetComponent<Rigidbody2D>();

        AudioSource[] audios = GetComponents<AudioSource>();
        boingA = audios[0];
        Crunch = audios[1];
        boingC = audios[2];
    }
    // Update is called once per frame
    void Update()
    {
        if (GameState.state == GameState.gamePlay)
        {
            if (transform.position.y < -10.0f)
            {
                GameState.state = GameState.gameOver;
            }
        }
        if (GameState.state == GameState.levelComplete)
        {
            // gameObject.SetActive(false);
            rigidBody.velocity = Vector2.zero;
            levelCompleteTimer -= Time.deltaTime;
            if (levelCompleteTimer < 0.0f)
            {
                if (GameState.level == 1)
                {
                    GameState.level = 2;
                    SceneManager.LoadScene("Scenes/Level2");
                }
                else if (GameState.level == 2)
                {
                    GameState.level = 3;
                    SceneManager.LoadScene("Scenes/Level3");
                }
                else if (GameState.level == 3)
                {
                    GameState.level = 4;
                    SceneManager.LoadScene("Scenes/Level4");
                }
                else if (GameState.level == 4)
                {
                    GameState.level = 5;
                    SceneManager.LoadScene("Scenes/Level5");
                }
                else if (GameState.level == 5)
                {
                    GameState.level = 6;
                    SceneManager.LoadScene("Scenes/Level6");
                }
                else
                {
                    GameState.state = GameState.gameOver;
                }
            }
        }
        if (GameState.state == GameState.gameOver)
        {
            gameOverTimer -= Time.deltaTime;
            if (gameOverTimer < 0.0f)
            {
                GameState.state = GameState.gamePlay;
                SceneManager.LoadScene("Scenes/Title");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MovingCandyLolipop"|| collision.gameObject.name == "CandyLolipop")
        {
            Scoring.gamescore += 10;
            boingA.Play();
        }
        if (collision.gameObject.name == "Sphere")
        {
            Scoring.gamescore += 50;
            boingC.Play();
        }
        if (collision.gameObject.name == "Ending")
        {
            Scoring.gamescore += 100;
            Crunch.Play();
            GameState.state = GameState.levelComplete;
        }
    }
}