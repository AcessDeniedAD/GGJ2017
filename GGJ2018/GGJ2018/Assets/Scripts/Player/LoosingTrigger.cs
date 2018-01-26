using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosingTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player1") {
            Debug.Log("collision2. Pouet Pouet Pouet");
            GameManager.singleton.LevelFail();
        }
    }
}
