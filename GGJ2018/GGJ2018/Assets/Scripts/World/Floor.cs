using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {


	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Obstacle") {
            other.transform.parent = gameObject.transform;
		}
	}

}
