using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnCollisionEnter(Collision other)
	{
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Obstacle") {
			Debug.Log("Hello2");
			other.transform.parent = gameObject.transform;
		}

	}
}
