using System.Collections;
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

	// Use this for initialization
	void Start () {
		float _position = 0f;
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
		playerObstacleManager = GameObject.Find ("PlayerObstacleManager").GetComponent<PlayerObstacleManager> ();
		currentObstacle = playerObstacleManager.InitObject ();
		GameManager.singleton.PlayerInitObstacle ();
	}
	
    
	// Update is called once per frame
	void FixedUpdate () {
		///////////////////////////////////////////////////////////
		// Controller One is the player one (runner with action) //
		///////////////////////////////////////////////////////////
		// Move Left action
		if (GamePad.GetButton(GamePad.Button.X, controllerIndex) ||
			GamePad.GetButton(GamePad.Button.LeftShoulder, controllerIndex) ||
			(Input.GetKey(KeyCode.LeftArrow) && controllerIndex == GamePad.Index.One) ||
			(Input.GetKey(KeyCode.D) && controllerIndex == GamePad.Index.Two)) 
		{

                position -= 1;
				float step = speed * Time.deltaTime;
				float newX = gameObject.transform.position.x - Move;
				//currentCoroutine = StartCoroutine (MoveCoroutine (step));
                LaunchCameraCoroutine(1, CameraWhoFollow);
                MoveLeft();


            
		}

		// Move Right action
		else if (GamePad.GetButton(GamePad.Button.B, controllerIndex) ||
            GamePad.GetButton(GamePad.Button.RightShoulder, controllerIndex) || 
			(Input.GetKey(KeyCode.RightArrow) && controllerIndex == GamePad.Index.One) ||
			(Input.GetKey(KeyCode.Q) && controllerIndex == GamePad.Index.Two)) 
		{
                //currentCoroutine = StartCoroutine (MoveCoroutine (step));
                MoveRight();
                LaunchCameraCoroutine(-1,CameraWhoFollow);
       
		}

		// Action
		if (GamePad.GetButtonDown(GamePad.Button.A, controllerIndex) || 
			(Input.GetKeyDown(KeyCode.Space) && controllerIndex == GamePad.Index.One)) {
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
		
	public void Action()
    {
		playerObstacleManager.DropObject (currentObstacle, gameObject);
	}

    public void LaunchCameraCoroutine(float axis, GameObject camera)
    {
        StartCoroutine(MoveCamera(axis, camera));
    }

    IEnumerator MoveCamera(float axis, GameObject camera)
    {
        float timer = 0;

        while (timer < 0.1f)
        {
            camera.transform.RotateAround(Vector3.forward, axis * 0.5f * Time.deltaTime/5);
            timer += Time.deltaTime;
            yield return 0;
        }

        timer = 0;
        while (timer < 0.1f)
        {
            camera.transform.RotateAround(Vector3.forward, axis * -0.5f * Time.deltaTime/5);
            timer += Time.deltaTime;
            yield return 0;
        }

        while (transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            camera.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f * Time.deltaTime);
            timer += Time.deltaTime;
            yield return 0;
        }

    }

    public void MoveRight() {
        gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void MoveLeft()
    {
        gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
