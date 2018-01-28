using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBegin : MonoBehaviour {

    public float timer;
    public float timeToStart;
    private float initialWorldSpeed;
    // Use this for initialization
	void Start () {
        initialWorldSpeed = WorldManager.speed;
        WorldManager.speed = 0;
        GameManager.OnBegin += () => {
            IsStart();
        };


    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.singleton.GameState == "begin")
        {
            timer += Time.deltaTime;
            if (timer >= timeToStart)
            {
                WorldManager.speed = initialWorldSpeed;
                GameManager.singleton.Begin();
                timer = 0;
            }
        }

	}

    public void IsStart() {
        timer = 0;
        GameManager.singleton.GameState = "run";
    }
}
