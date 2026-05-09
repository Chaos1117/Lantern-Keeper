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
    public string WinScene;

    void Awake()
    {
        if (!gm)
            gm = this;
        else
            Destroy(this);
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
        SceneManager.LoadScene(WinScene);

    }
}
