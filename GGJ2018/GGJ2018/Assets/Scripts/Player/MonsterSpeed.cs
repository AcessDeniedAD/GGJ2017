using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpeed : MonoBehaviour {

    public float speed = 0.0f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.singleton.GameState == "run") {
            gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
	}
}
