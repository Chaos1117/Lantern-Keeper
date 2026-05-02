using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    //score
    public GameObject scoreText;
    public static int theScore;

    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
    }

    void Awake()
    {
        if (!gm)
            gm = this;
        else
            Destroy(this);
    }

}
