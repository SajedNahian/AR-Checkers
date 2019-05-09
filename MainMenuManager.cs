using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public void StartButton ()
    {
        SceneManager.LoadScene("Game");
    }

    public void AboutButton ()
    {
        SceneManager.LoadScene("About");
    }

    public void BackButton ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
