using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Credit : MonoBehaviour {

	private GameObject gamay;
	private GameObject shinesaki;
	private GameObject toubalounga;
	private GameObject youak;
	private GameObject strik;

	private Vector3 gamayStartPosition;
	private Vector3 shinesakiStartPosition;
	private Vector3 toubaloungaStartPosition;
	private Vector3 youakStartPosition;
	private Vector3 strikStartPosition;

	private int elapsedFrames = 0;
	private int maxFrames = 200;

	// Use this for initialization
	void Start () {
		gamay = GameObject.Find("gamay");
		gamayStartPosition = gamay.GetComponent<RectTransform>().position;

		shinesaki = GameObject.Find("shinesaki");
		shinesakiStartPosition = shinesaki.GetComponent<RectTransform>().position;

		youak = GameObject.Find("youak");
		youakStartPosition = youak.GetComponent<RectTransform>().position;

		toubalounga = GameObject.Find("toubalounga");
		toubaloungaStartPosition = toubalounga.GetComponent<RectTransform>().position;

		strik = GameObject.Find("strik");
		strikStartPosition = strik.GetComponent<RectTransform>().position;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateObject(gamay, gamayStartPosition, new Vector3(-200, 0, 0));
		UpdateObject(strik, strikStartPosition, new Vector3(-100, 0, 0));
		// UpdateObject(shinesaki, shinesakiStartPosition, new Vector3(0, 0, 0));
		
		UpdateObject(toubalounga, toubaloungaStartPosition, new Vector3(100, 0, 0));
		UpdateObject(youak, youakStartPosition, new Vector3(200, 0, 0));
		

		elapsedFrames++;
	}

	private void UpdateObject(
		GameObject someObject, Vector3 startPosition, Vector3 deltaPosition
	) {
		if (elapsedFrames > maxFrames) {
			return;
		}

		float progress = elapsedFrames * 1.0f / maxFrames;
		RectTransform rectTransform = someObject.GetComponent<RectTransform>();
		Vector3 newPosition = Vector3.Lerp(startPosition, startPosition + deltaPosition, progress);
		rectTransform.position = newPosition;
	}
}
