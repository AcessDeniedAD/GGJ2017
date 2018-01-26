using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Input2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.One)) {
            Debug.Log("okokokokoko");
        }
	}
}
