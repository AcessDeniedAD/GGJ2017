using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {


    public int cameraId;
	public static MoveCamera singleton;

	// Update is called once per frame
	void Start () {
        singleton = this;
    }

    public void LaunchCameraCoroutine(float axis)
    {
        StartCoroutine(LeftMove(axis));
    }

    IEnumerator LeftMove(float axis) {
        float timer = 0;

        while (timer < 0.1f) {
            gameObject.transform.RotateAround(Vector3.forward, axis* 2 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return 0;
        }
        timer = 0;
        while (timer < 0.1f)
        {
            gameObject.transform.RotateAround(Vector3.forward,axis * -2 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return 0;
        }
        while (transform.rotation != Quaternion.Euler(0,0,0))
        {
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return 0;
        }

    }


}
