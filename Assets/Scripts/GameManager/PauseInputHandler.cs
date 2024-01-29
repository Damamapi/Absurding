using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInputHandler : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool isPaused = false;
    private Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();
   
        inputs.Gameplay.Pause.performed += _ => TogglePauseMenu();

    }

    private void OnEnable()
    {
        inputs.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputs.Gameplay.Disable();
    }


    public void TogglePauseMenu()
    {
        if (!isPaused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            isPaused = false;
        }
    }
}
