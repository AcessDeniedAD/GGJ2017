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
        InitFirstFloors();
        GameManager.OnLevelFail += () => {
            OnLoose();
        };
    }

    private void Update()
    {
        if (GameManager.singleton.GameState == "run")
        {
            speed += 0.001f;
            for (int i = 0; i < floors.Count; i++)
            {
                floors[i].transform.position += -Vector3.forward * speed * Time.deltaTime;
                if (floors[i].transform.position.z < -50)
                {
                    Transform actualFloor = floors[i];
                    Destroy(actualFloor.gameObject);
                    floors.Remove(actualFloor);
                    InitFloor();

                }
            }
        }

    }

    public void InitFloor() {
        if (firstFloor == null)
        {
            firstFloor = floors[0];
        }
        int randomInt = Random.Range(1, TotalFLoors - 1);
        Transform lastFloor = floors[floors.Count - 1];
        GameObject newFloor = Resources.Load("Floor" + randomInt) as GameObject;
        GameObject lastFloorTarget = lastFloor.Find("Target").gameObject;
        MeshRenderer lastFloorTargetMesh = lastFloorTarget.GetComponent<MeshRenderer>();
        Vector3 newPosition = new Vector3(firstFloor.transform.position.x,firstFloor.transform.position.y, lastFloor.transform.position.z) + new Vector3(0, 0, lastFloorTargetMesh.bounds.size.z);
        GameObject newFloorInstantiate = Instantiate(newFloor, newPosition, Quaternion.identity) as GameObject;
        newFloorInstantiate.transform.parent = gameObject.transform;
        floors.Add(newFloorInstantiate.transform);

    }

    public void InitFirstFloors() {
        for (int i = 0; i < 10; i++) {
            InitFloor();
            if (i != 0) {                
                if (floors[i] != null) {
                    //StartCoroutine(PlaceFloor(floors[i].gameObject));
                }
                
            }
        }
    }

        
    

    public void OnLoose()
    {
        floors.Clear();
    }
}
