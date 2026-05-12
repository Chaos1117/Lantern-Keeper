using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    //Retry button
    public void Retry()
    {
        SceneManager.LoadScene("Level 1");
    }

    //Quit button
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
