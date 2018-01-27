using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
	private float timeToStart;
	private float timer;
	private float initialWorldSpeed;

	// Use this for initialization
	void Start () {
		TimerBegin timerBegin = GameObject.Find("GameManager").GetComponent<TimerBegin> ();
		timeToStart = timerBegin.timeToStart;
		initialWorldSpeed = WorldManager.speed;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameManager.singleton.GameState == "begin")
		{
			timer += Time.deltaTime;
			if (timer <= timeToStart)
			{	
				Debug.Log ("While");
				gameObject.transform.Rotate(new Vector3 (gameObject.transform.rotation.x, gameObject.transform.rotation.y, -(timeToStart*Time.deltaTime*40)));	
				WorldManager.speed = initialWorldSpeed;
				timer = 0;
			}
		}

	}
}
