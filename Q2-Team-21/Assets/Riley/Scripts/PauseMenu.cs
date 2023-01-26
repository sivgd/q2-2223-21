using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;
    public int MainMenuNumber = 0;
    public bool DoesThisWork;
    public GameObject RestartAreYouSure;
    public GameObject MainMenuAreYouSure;
    public GameObject MainPauseMenu;
    [SerializeField] GameObject BoatCam;
    private GameObject player;
    //public GameObject Camera;
    //private Vector3 LockRotation = new Vector3(0,0,0);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DoesThisWork = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            RestartAreYouSure.SetActive(false);
            MainMenuAreYouSure.SetActive(false);
            //MainPauseMenu.SetActive(true);

            //switch (isGamePaused)
            //{
            //    case true:
            //        DoesThisWork = true;
            //        break;

            //    case false:
            //        DoesThisWork = false;
            //        break;
            //}

            switch (isGamePaused)
            {
                case true:
                    Resume();
                    break;

                case false:
                    Pause();
                    break;
            }
            //Pause();

            //Camera.transform.rotation = Quaternion.Euler(LockRotation);
        }
    }

    public void Resume()
    {
        //Debug.Log("RESUME");
        PauseMenuUI.SetActive(false);
        player.GetComponent<CharacterControllerScript>().enabled= true;
        BoatCam.GetComponent<RotateAroundCam>().enabled = true;
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void Pause()
    {
        //Debug.Log("PAUSE");
;        PauseMenuUI.SetActive(true);
        BoatCam.GetComponent<RotateAroundCam>().enabled = false;
        player.GetComponent<CharacterControllerScript>().enabled = false;
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
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
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(MainMenuNumber);
    }

}
