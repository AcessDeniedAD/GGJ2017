using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedByObstacle : MonoBehaviour {

    public float timeToGoBack = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") {
            StartCoroutine(GoBack());
        }
        
    }
    IEnumerator GoBack() {
        yield return 0;
        float timer = 0;
        while (timer < timeToGoBack) {
            timer += Time.deltaTime;
            gameObject.transform.position += -Vector3.forward * (WorldManager.speed/1.9f) * Time.deltaTime;
            yield return 0;
        }
    }
}
