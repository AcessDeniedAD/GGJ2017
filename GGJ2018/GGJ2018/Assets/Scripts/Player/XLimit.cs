using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XLimit : MonoBehaviour {

    public int playerId;
    public GameObject player;
	// Use this for initialization
	void Start () {
        if (playerId == 1)
        {
            player = GameObject.Find("Player1");
        }
        else
        {
            player = GameObject.Find("Player2");
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
	}
}
