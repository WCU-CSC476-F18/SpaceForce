using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneModes : MonoBehaviour {

    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<ConnectObjects>().ResetGame();
    }

    public void GameOverScene()
    {
        StartCoroutine(DelayChangeNewScenes());
    }
    public void WinScene()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator DelayChangeNewScenes()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOverScreen");
    } 
}
