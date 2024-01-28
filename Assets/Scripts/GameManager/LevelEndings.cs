using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndings : MonoBehaviour
{
    //LevelEndingObj should be set inactive, activate at end of level
    
    //variables for different endings
    private GameManager gm;

    //level index starts at 0, must match order of minigame level index in build settings
    public int levelIndex;
    [SerializeField] private int levelGrade;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failureSprite;
    [SerializeField] private Image displayImage;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();

        levelGrade = gm.ReturnGrade(levelIndex);
        SetEndingSprite();
        displayImage.gameObject.SetActive(true);
    }

    //Set sprite based on grade recieved
    private void SetEndingSprite()
    {
        if (levelGrade > 0)
        {
            displayImage.sprite = successSprite;
        }
        else
            displayImage.sprite = failureSprite;
    }
}
