using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerInput : MonoBehaviour {

	public int playerId ;
	private GamePad.Index controllerIndex;

	// Use this for initialization
	void Start () {
		if (playerId == 1) {
			controllerIndex = GamePad.Index.One;
		} else {
			controllerIndex = GamePad.Index.Two;
		}

	}
	
	// Update is called once per frame
	void Update () {
		///////////////////////////////////////////////////////////
		// Controller One is the player one (runner with action) //
		///////////////////////////////////////////////////////////
		// Move Left action
		if (GamePad.GetButtonDown(GamePad.Button.X, controllerIndex) ||
			GamePad.GetButtonDown(GamePad.Button.LeftShoulder, controllerIndex) ||
			(Input.GetKeyDown(KeyCode.LeftArrow) && controllerIndex == GamePad.Index.One) ||
			(Input.GetKeyDown(KeyCode.D) && controllerIndex == GamePad.Index.Two)) 
		{
			MoveRight ();
		}

		// Move Right action
		if (GamePad.GetButtonDown(GamePad.Button.B, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.RightArrow) && controllerIndex == GamePad.Index.One) ||
			(Input.GetKeyDown(KeyCode.Q) && controllerIndex == GamePad.Index.Two)) 
		{
			MoveLeft();
		}

		// Action
		if (GamePad.GetButtonDown(GamePad.Button.A, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.Space) && controllerIndex == GamePad.Index.One)) {
			Action ();
		}
			
	}


	public void MoveRight(){
		Debug.Log("Player move right"+gameObject.name);
	}

	public void MoveLeft(){
		Debug.Log("Player move Left"+gameObject.name);
	}

	public void Action(){
		Debug.Log("Action"+gameObject.name);
	}
}
