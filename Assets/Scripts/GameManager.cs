using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    void Awake()
    {
        if (!gm)
            gm = this;
        else
            Destroy(this);
    }

}
