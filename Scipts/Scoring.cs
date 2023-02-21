using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static int gamescore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.skin.box.fontSize = 30;
        GUI.Box(new Rect(20, 20, 200, 50), "Score: " + gamescore);
        GUI.Box(new Rect(Screen.width - 220, 20, 200, 50), "Level " + GameState.level);
        if (GameState.state == GameState.gameOver)
        {
            GUI.skin.box.fontSize = 60;
            GUI.Box(new Rect(
            Screen.width / 2 - 200,
            Screen.height / 2 - 50,
            400,
            100),
            "Game Over");
        }
        if (GameState.state == GameState.levelComplete)
        {
            GUI.skin.box.fontSize = 60;
            GUI.Box(new Rect(
            Screen.width / 2 - 250,
            Screen.height / 2 - 50, 500, 100), "Level Complete");
        }
    }
}
