using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Scoring.gamescore = 0;
        GameState.level = 1;
        SceneManager.LoadScene("Scenes/Level1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}