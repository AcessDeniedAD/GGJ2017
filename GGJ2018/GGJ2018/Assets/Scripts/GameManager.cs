using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager singleton;

    public delegate void EVENT_GAME_MANAGER();
    public static event EVENT_GAME_MANAGER OnLevelFail;
    public static event EVENT_GAME_MANAGER OnLevelWin;

    void Start () {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            DestroyManager();
            return;
        }
    }

    public void DestroyManager()
    {
        Destroy(gameObject);
        StopAllCoroutines();
        return;
    }

    public void LevelFail()
    {
        OnLevelFail();
    }
}
