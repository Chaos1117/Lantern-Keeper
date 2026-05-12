using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    //Continue load another level?
    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }

    //main menu button
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //quit button
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
