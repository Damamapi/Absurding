using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPersistent<GameManager>
{
    //List used for loading scenes based on name. Name must be the same as scene name to load correctly. List order must be the same as scene order in build settings
    [SerializeField] private List<string> sceneNames = new List<string>();
    [SerializeField] private int sceneIndex = 0;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        sceneIndex = sceneNames.IndexOf(sceneName);
    }

    public void LoadNextScene()
    {
        sceneIndex++;
        SceneManager.LoadScene(sceneNames[sceneIndex], LoadSceneMode.Single);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(sceneNames[sceneIndex], LoadSceneMode.Single);
    }

}
