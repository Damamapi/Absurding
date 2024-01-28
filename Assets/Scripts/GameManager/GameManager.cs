using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPersistent<GameManager>
{
    //List used for loading scenes based on name. Name must be the same as scene name to load correctly. List order must be the same as scene order in build settings
    [SerializeField] private List<string> sceneNames = new List<string>();
    [SerializeField] private int sceneIndex = 0;

    //Lists to store all high scores + grades
    [SerializeField] private List<float> hiScores = new List<float>();
    [SerializeField] private List<int> gradedScores = new List<int>();

    //SceneManager methods
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

    //HiScore functionality methods, GradeScore runs after every minigame. Adds player's score and grades them based on it
    public void GradeScore (float score, float scoreRankC, float scoreRankB, float scoreRankA)
    {
        hiScores.Add(score);

        int grade;

        if (score < scoreRankC)
            grade = 0;
        else if (score >= scoreRankC && score < scoreRankB)
            grade = 1;
        else if (score >= scoreRankB && score < scoreRankA)
            grade = 2;
        else
            grade = 3;

        gradedScores.Add(grade);
    }

    //index corresponding to minigame order. Used to alter minigame ending based on score
    public int ReturnGrade(int index)
    {
        return gradedScores.ElementAt(index);
    }
}
