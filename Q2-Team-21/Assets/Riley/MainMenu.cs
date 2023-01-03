using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int SceneNumber;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneNumber);
    }

    public void QuitGame()
    {
        Debug.Log("You quit the game");
        Application.Quit();
    }



}
