using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    //Retry button
    public void Retry()
    {
        SceneManager.LoadScene(GameManager.currentLevel); //loads level saved by player controller
    }

    //Quit button
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
