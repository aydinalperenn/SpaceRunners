using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutMe : MonoBehaviour
{
    public void OpenLinkedIn()
    {
        Application.OpenURL("http://linkedin.com/in/aydnalperenn/");
    }

    public void OpenGitHub()
    {
        Application.OpenURL("http://github.com/aydinalperenn");
    }

    public void OpenYouTube()
    {
        Application.OpenURL("http://youtube.com/@aydinalperenn");
    }

    public void OpenItchIo()
    {
        Application.OpenURL("https://aydinalperenn.itch.io/");
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("PublicArea");
    }

}
