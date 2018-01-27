using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    public static float speed = 5;
    public List<Transform> floors;
    public int TotalFLoors;
    public Transform firstFloor;


	// Use this for initialization
	void Start () {
        int childNumber = transform.childCount;
        for (int i = 0; i < childNumber; i++) {
            floors.Add(transform.GetChild(i));
        }
        firstFloor = floors[0];
	}

    private void Update()
    {
        if (GameManager.singleton.GameState == "run")
        {
            speed += 0.01f;
            for (int i = 0; i < floors.Count; i++)
            {
                floors[i].transform.position += -Vector3.forward * speed * Time.deltaTime;
                if (floors[i].transform.position.z < -500)
                {
                    int randomInt = Random.Range(0, TotalFLoors);
                    Transform actualFloor = floors[i];
                    Transform lastFloor = floors[floors.Count - 1];
                    Destroy(actualFloor.gameObject);
                    floors.Remove(actualFloor);
                    Debug.Log(floors.Count);
                    GameObject newFloor = Resources.Load("Floor") as GameObject;
                    MeshRenderer lastFloorMesh = lastFloor.GetComponent<MeshRenderer>();
                    Vector3 newPosition = lastFloor.transform.position + new Vector3(0, 0, lastFloorMesh.bounds.size.z);
                    GameObject newFloorInstantiate = Instantiate(newFloor, newPosition, Quaternion.identity) as GameObject;
                    newFloorInstantiate.transform.parent = gameObject.transform;
                    floors.Add(newFloorInstantiate.transform);
                }
            }
        }

    }
}
