using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;
    public int MainMenuNumber = 0;

    public GameObject RestartAreYouSure;
    public GameObject MainMenuAreYouSure;
    public GameObject MainPauseMenu;
    //public GameObject Camera;
    //private Vector3 LockRotation = new Vector3(0,0,0);


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            RestartAreYouSure.SetActive(false);
            MainMenuAreYouSure.SetActive(false);
            MainPauseMenu.SetActive(true);


            if (isGamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            //Camera.transform.rotation = Quaternion.Euler(LockRotation);
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        //LockRotation = Camera.transform.eulerAngles;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        Resume();
        SceneManager.LoadScene(MainMenuNumber);
    }

}
