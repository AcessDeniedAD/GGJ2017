using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager singleton;
    public string GameState = "begin";
    public string playerWinner;
    public delegate void EVENT_GAME_MANAGER();
    public static event EVENT_GAME_MANAGER OnLevelFail;
    public static event EVENT_GAME_MANAGER OnLevelWin;
    public static event EVENT_GAME_MANAGER OnPlayer1TakeDamage;
    public static event EVENT_GAME_MANAGER OnPlayer2TakeDamage;
	public static event EVENT_GAME_MANAGER OnPlayerInitObstacle;

    public static event EVENT_GAME_MANAGER OnBegin;
    public static event EVENT_GAME_MANAGER OnBeforeBegin;

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
        GameState = "beforeBegin";
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

    public void Begin()
    {
        OnBegin();
        GameState = "run";
    }
    public void BeforeBegin()
    {
        OnBeforeBegin();
        GameState = "begin";
    }


    public void TakeDamage(string playerName) {
        if (playerName == "Player1") {
            OnPlayer1TakeDamage();
        }
        if (playerName == "Player2")
        {
            OnPlayer2TakeDamage();
        }
    }

	public void PlayerInitObstacle() {
		OnPlayerInitObstacle ();
	}
}
