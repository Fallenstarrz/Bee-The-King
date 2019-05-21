using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.instance.sceneSwitcher == null)
        {
            GameManager.instance.sceneSwitcher = this;
        }
    }
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void loadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
