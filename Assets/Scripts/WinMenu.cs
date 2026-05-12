using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    int currentSceneIndex;
    int nextSceneIndex;


    //Continue load next level
    public void Continue()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex >= SceneManager.sceneCountInBuildSettings) //restart to level 1 if player beats level 3
        {
            nextSceneIndex = 2;
        }
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
