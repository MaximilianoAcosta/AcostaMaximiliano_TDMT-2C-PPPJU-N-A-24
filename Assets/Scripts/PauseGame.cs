using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool paused = false;

    private void Start()
    {
        Time.timeScale = 1;
        if (paused)
        {
            Resume();
        }
    }
    public void OnPausePressed(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && !paused)
        {
            Pause();
        }
        else if (ctx.performed && paused)
        {
            Resume();
        }
    }



    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Cursor.lockState = CursorLockMode.None;
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        if(Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
