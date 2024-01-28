using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndings : MonoBehaviour
{
    //variables for different endings
    private GameManager gm;

    public int levelIndex;
    [SerializeField] private int levelGrade;
    [SerializeField] private Image successImage;
    [SerializeField] private Image failureImage;
    private Image displayImage;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();

        levelGrade = gm.ReturnGrade(levelIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetEnding();
    }

    private void SetEnding()
    {
        if (levelGrade > 1)
        {
            displayImage = successImage;
        }
        else
            displayImage = failureImage;
    }
}
