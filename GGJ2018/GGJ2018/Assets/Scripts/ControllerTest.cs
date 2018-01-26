using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ControllerTest : MonoBehaviour {

	public GamepadState state;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		state = GamePad.GetState (GamePad.Index.One, false);
		Debug.Log("efe");
		if(state.A){
			Debug.Break();
		}
	}
}
