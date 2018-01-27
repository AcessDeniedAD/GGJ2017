using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerOnFloor : MonoBehaviour {

    public string floor = "anyFloor";
    public static GetPlayerOnFloor singleton;
	// Use this for initialization
	void Start () {
        singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (String.Compare(collision.gameObject.name, "Floor" ) <= 1)
        {
            floor = collision.gameObject.name;
        
        }
    }
}
