using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerInput : MonoBehaviour {

	public int playerId ;
	public float Move;
	private GamePad.Index controllerIndex;
	private int position = 0;

	public float speed;
	private float step;
	private bool coroutineStarted;

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
			if (position > -1 && coroutineStarted == false) {
				float step = speed * Time.deltaTime;
				float newX = gameObject.transform.position.x - Move;
				Vector3 NewPosition = new Vector3 (newX, gameObject.transform.position.y, gameObject.transform.position.z);
				StartCoroutine (MoveCoroutine (NewPosition, step));
				position -= 1;
			}
		}

		// Move Right action
		else if (GamePad.GetButtonDown(GamePad.Button.B, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.RightArrow) && controllerIndex == GamePad.Index.One) ||
			(Input.GetKeyDown(KeyCode.Q) && controllerIndex == GamePad.Index.Two)) 
		{
			if (position < 1 && coroutineStarted == false) {
				float step = speed * Time.deltaTime;
				float newX = gameObject.transform.position.x + Move;
				Vector3 NewPosition = new Vector3 (newX, gameObject.transform.position.y, gameObject.transform.position.z);
				StartCoroutine (MoveCoroutine (NewPosition, step));
				position += 1;
			}
		}

		// Action
		if (GamePad.GetButtonDown(GamePad.Button.A, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.Space) && controllerIndex == GamePad.Index.One)) {
			Action ();
		}
			
	}

	IEnumerator MoveCoroutine(Vector3 NewPosition, float step){
		//Debug.Log("Before While");
		coroutineStarted = true;
		while (gameObject.transform.position != NewPosition){
			//Debug.Log("In While " +NewPosition + " "+ step+ " " + gameObject.transform.position );
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NewPosition, step);
			yield return 0;
		}
		coroutineStarted = false;
		yield return 0;

	}
		
	public void Action(){
		Debug.Log("Action"+gameObject.name);
	}
}
