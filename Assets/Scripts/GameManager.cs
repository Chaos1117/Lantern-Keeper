using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    //lamps
    public int totalLamps = 5;
    private int activatedLamps = 0;

    //retry level player died on
    public static string currentLevel;

    void Awake()
    {
        if (!gm)
            gm = this;
        else
            Destroy(this);
    }

    public static void SetCurrentLevel(string sceneName)
    {
        currentLevel = sceneName;
    }
    public void ActivateLamp()
    {
        activatedLamps++;
        Debug.Log("Lamps Lit: " + activatedLamps);

        if(activatedLamps >= totalLamps)
        {
            WinGame();
        }
    }

   public void WinGame()
    {
        Debug.Log("you win");
        SceneManager.LoadScene("Win");

    }
}
