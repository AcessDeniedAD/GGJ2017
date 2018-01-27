using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    public int speed;
    public List<Transform> floors;


	// Use this for initialization
	void Start () {
        int childNumber = transform.childCount;
        for (int i = 0; i < childNumber; i++) {
            floors.Add(transform.GetChild(i));
        }
	}

    private void Update()
    {
        for (int i = 0; i < floors.Count; i++)
        {
            floors[i].transform.position += -Vector3.forward * speed * Time.deltaTime;

            if (floors[i].transform.position.z < -35 ){

                Destroy(floors[i].gameObject);
                floors.Remove(floors[i]);
            }
        }
    }
}
