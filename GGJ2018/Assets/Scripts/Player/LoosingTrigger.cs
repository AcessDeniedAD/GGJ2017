using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosingTrigger : MonoBehaviour {
	GameObject playerOne;
	// Use this for initialization
	void Start () {
		playerOne = GameObject.Find("Player1");
	}
	
	// Update is called once per frame
	void Update () {
		if(playerOne.transform.position.z <= gameObject.transform.position.z){
			GameManager.singleton.LevelFail();
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player1") {
            GameManager.singleton.LevelFail();
        }
    }
}
