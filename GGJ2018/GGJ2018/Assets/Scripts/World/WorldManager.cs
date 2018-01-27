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
	}

    private void Update()
    {
        if (GameManager.singleton.GameState == "run")
        {
            speed += 0.01f;
            for (int i = 0; i < floors.Count; i++)
            {
                floors[i].transform.position += -Vector3.forward * speed * Time.deltaTime;
                if (floors[i].transform.position.z < -400)
                {
                    
                    Transform actualFloor = floors[i];
                    Destroy(actualFloor.gameObject);
                    floors.Remove(actualFloor);
                    Debug.Log(floors.Count);
                    InitFloor();
                }
            }
        }

    }

    public void InitFloor() {
        int randomInt = Random.Range(1, TotalFLoors - 1);
        Transform lastFloor = floors[floors.Count - 1];
        Debug.Log(randomInt);
        Debug.Break();
        GameObject newFloor = Resources.Load("Floor" + randomInt) as GameObject;
        MeshRenderer lastFloorMesh = lastFloor.GetComponent<MeshRenderer>();
        Vector3 newPosition = lastFloor.transform.position + new Vector3(0, 0, lastFloorMesh.bounds.size.z);
        GameObject newFloorInstantiate = Instantiate(newFloor, newPosition, Quaternion.identity) as GameObject;
        newFloorInstantiate.transform.parent = gameObject.transform;
        floors.Add(newFloorInstantiate.transform);

    }

    public void InitFirstFloors() {
        for (int i = 0; i < 15; i++) {
            InitFloor();
            if (i != 0) {
                int rand = Random.Range(0, 3);
                if (rand == 1)
                {
                    rand = -1;
                }
                else { rand = 2; }
                floors[i].transform.position += new Vector3(rand * 100,0,0);
                StartCoroutine(PlaceFloor(floors[i].gameObject, i * 0.2f +1.5f));
            }
        }
    }

    IEnumerator PlaceFloor(GameObject floor, float s) {
        yield return new WaitForSeconds(s);
        while (floor.transform.position.x != firstFloor.transform.position.x)
        {
            floor.transform.position = new Vector3( Mathf.Lerp(floor.transform.position.x,firstFloor.transform.position.x, 3* Time.deltaTime),floor.transform.position.y, floor.transform.position.z);
            yield return 0;
        }

    }
}
