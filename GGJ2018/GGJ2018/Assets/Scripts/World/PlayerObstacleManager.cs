using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleManager : MonoBehaviour {
	public List<Transform> obstacles;

	// Use this for initialization
	void Start () {
		GameManager.OnPlayerInitObstacle += () => {
			IsInit();
		};
	}
	
	// Update is called once per frame
	void Update () {
	}

	public GameObject InitObject(){
		
		int countObstacle = obstacles.Count;
		GameObject newObstacle = new GameObject();
		if (obstacles.Count > 0) {
			int transformRand = Random.Range(0, countObstacle);
			newObstacle = obstacles[transformRand].gameObject;
			newObstacle.tag = "Obstacle";
		} ;
		return newObstacle;
	}

	public void DropObject(GameObject obstacle, GameObject player){
		Vector3 newPosition = player.transform.position - new Vector3(0.0f, 0.0f, (player.transform.localScale.z*10f));
		GameObject newObstacleInstantiate = Instantiate(obstacle, newPosition,Quaternion.identity) as GameObject;

	}

	public void IsInit(){
	}
}
