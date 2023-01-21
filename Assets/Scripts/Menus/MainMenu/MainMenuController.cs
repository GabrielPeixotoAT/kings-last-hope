using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject SettingsMenuObject;
    public GameObject CreditsMenuObject;

    public void ContinueOption()
    {

    }

    public void NewGameOption()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsOption()
    {

    }

    public void CreditsOption()
    {

    }

    public void ExitOption()
    {
        Application.Quit();
    }
}
