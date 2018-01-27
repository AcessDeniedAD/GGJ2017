using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerInput : MonoBehaviour {

	public int playerId ;
	public float Move;
	public float speed;

	private GamePad.Index controllerIndex;
	private int position = 1;
	private float step;
	private bool coroutineStarted;
	private float[] listPosition = new float[3];
	private Coroutine currentCoroutine;

	// Use this for initialization
	void Start () {
		float _position = 0f;
		if (playerId == 1) {
			controllerIndex = GamePad.Index.One;
		} else {
			controllerIndex = GamePad.Index.Two;
		}

		_position =  gameObject.transform.position.x -  Move;
		for (int i = 0; i <= 2; i++)
		{
			listPosition[i] = _position; 
			_position += Move;
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
			if (position > 0) {
				if (coroutineStarted) {
					StopCoroutine (currentCoroutine);
					coroutineStarted = false;
				}
				position -= 1;
				float step = speed * Time.deltaTime;
				float newX = gameObject.transform.position.x - Move;
				currentCoroutine = StartCoroutine (MoveCoroutine (step));
				//StartCoroutine (MoveCoroutine (NewPosition, step));


			}
		}

		// Move Right action
		else if (GamePad.GetButtonDown(GamePad.Button.B, controllerIndex) ||
            GamePad.GetButtonDown(GamePad.Button.RightShoulder, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.RightArrow) && controllerIndex == GamePad.Index.One) ||
			(Input.GetKeyDown(KeyCode.Q) && controllerIndex == GamePad.Index.Two)) 
		{
			StopCoroutine ("MoveCoroutine");
			if (position < 2) {
				if (coroutineStarted) {;
					StopCoroutine (currentCoroutine);
					coroutineStarted = false;
				}
				position += 1;
				float step = speed * Time.deltaTime;
				float newX = gameObject.transform.position.x + Move;
				currentCoroutine = StartCoroutine (MoveCoroutine (step));

			}
		}

		// Action
		if (GamePad.GetButtonDown(GamePad.Button.A, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.Space) && controllerIndex == GamePad.Index.One)) {
			Action ();
		}
			
	}

	IEnumerator MoveCoroutine(float step){
		//Debug.Log("Before While");
		coroutineStarted = true;
        Vector3 NewPosition = new Vector3(listPosition[position], gameObject.transform.position.y, gameObject.transform.position.z);
        while (gameObject.transform.position.x != NewPosition.x || !coroutineStarted){
            NewPosition = new Vector3(listPosition[position], gameObject.transform.position.y, gameObject.transform.position.z);
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
