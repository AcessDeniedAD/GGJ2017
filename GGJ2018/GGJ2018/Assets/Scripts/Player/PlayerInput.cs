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
	private bool HasAnObstacle;


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
                LaunchCameraCoroutine(1, CameraWhoFollow);


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
                LaunchCameraCoroutine(-1,CameraWhoFollow);


            }
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
		
	public void Action(){
		if (HasAnObstacle) {
			playerObstacleManager.DropObject (currentObstacle, gameObject);
			HasAnObstacle = false;
		}

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
            camera.transform.RotateAround(Vector3.forward, axis * 2 * Time.deltaTime/5);
            timer += Time.deltaTime;
            yield return 0;
        }
        timer = 0;
        while (timer < 0.1f)
        {
            camera.transform.RotateAround(Vector3.forward, axis * -2 * Time.deltaTime/5);
            timer += Time.deltaTime;
            yield return 0;
        }
        while (transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            camera.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return 0;
        }

    }

}
