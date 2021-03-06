﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerInput : MonoBehaviour {

	public int playerId ;
	public float Move;
	public float speed;

    public GameObject CameraWhoFollow;
	private GamePad.Index controllerIndex;
	private int position = 1;
	private float step;
	private bool coroutineStarted;
	private float[] listPosition = new float[3];
	private Coroutine currentCoroutine;
	private PlayerObstacleManager playerObstacleManager;
	private GameObject currentObstacle;
	private bool HasAnObstacle;
    private Quaternion cameraInitialRotation;
    public bool CanMove;
    
	// Use this for initialization
	void Start () {
		float _position = 0f;
        GameManager.OnBegin += () => {
            CanMove = true;
        };

        if (playerId == 1) {
            CameraWhoFollow = GameObject.Find("Main Camera");
			controllerIndex = GamePad.Index.One;
		} else {
            CameraWhoFollow = GameObject.Find("Main Camera2");
            controllerIndex = GamePad.Index.Two;
		}

		_position =  gameObject.transform.position.x -  Move;
		for (int i = 0; i <= 2; i++)
		{
			listPosition[i] = _position; 
			_position += Move;
		}
        cameraInitialRotation = CameraWhoFollow.transform.rotation;
        CanMove = false;

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "LootBox" && !HasAnObstacle) {
			playerObstacleManager = GameObject.Find ("PlayerObstacleManager").GetComponent<PlayerObstacleManager> ();
			currentObstacle = playerObstacleManager.InitObject ();
			GameManager.singleton.PlayerInitObstacle ();
			HasAnObstacle = true;
		}
	}
		
	// Update is called once per frame
	void FixedUpdate () {

        if ((GamePad.GetButton(GamePad.Button.X, controllerIndex) ||
            GamePad.GetButton(GamePad.Button.LeftShoulder, controllerIndex) ||
            (Input.GetKey(KeyCode.LeftArrow) && controllerIndex == GamePad.Index.One) ||
            (Input.GetKey(KeyCode.Q) && controllerIndex == GamePad.Index.Two) || Input.GetAxis("Horizontal"+controllerIndex) < 0) && CanMove)
        {
            position -= 1;
            float step = speed * Time.deltaTime;
            float newX = gameObject.transform.position.x - Move;
            if (Input.GetAxis("Horizontal" + controllerIndex) == 0)
            {
                MoveLeft(speed);
            }
            else
            {
                MoveLeft(-Input.GetAxis("Horizontal" + controllerIndex) * speed);
            }
            
        }

        // Move Right action
        else if ((GamePad.GetButton(GamePad.Button.B, controllerIndex) ||
            GamePad.GetButton(GamePad.Button.RightShoulder, controllerIndex) ||
            (Input.GetKey(KeyCode.RightArrow) && controllerIndex == GamePad.Index.One) ||
            (Input.GetKey(KeyCode.D) && controllerIndex == GamePad.Index.Two) || Input.GetAxis("Horizontal"+controllerIndex) > 0) && CanMove)
        {
            if (Input.GetAxis("Horizontal" + controllerIndex) == 0)
            {
                MoveRight(speed);
            }
            else
            {
                MoveRight(Input.GetAxis("Horizontal" + controllerIndex) *speed);
            }
        }

		// Action
		if (GamePad.GetButtonDown(GamePad.Button.A, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.Space) && controllerIndex == GamePad.Index.One))
        {
			Action ();
		}
			
	}

	IEnumerator MoveCoroutine(float step){
		coroutineStarted = true;
        Vector3 NewPosition = new Vector3(listPosition[position], gameObject.transform.position.y, gameObject.transform.position.z);
        while (gameObject.transform.position.x != NewPosition.x || !coroutineStarted){
            NewPosition = new Vector3(listPosition[position], gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NewPosition, step);
			yield return 0;
		}
		coroutineStarted = false;
		yield return 0;
	}
		
	public void Action(){
		if (HasAnObstacle) {
			playerObstacleManager.DropObject (currentObstacle, gameObject);
			HasAnObstacle = false;
		}
	}

    public void MoveRight(float _speed) {
        gameObject.transform.position += Vector3.right * _speed * Time.deltaTime;
    }

    public void MoveLeft(float _speed)
    {
        gameObject.transform.position += Vector3.left * _speed * Time.deltaTime;
    }

}
