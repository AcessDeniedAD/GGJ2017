using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UnityEngine.SceneManagement;

public class WinnerScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameManager.singleton.GameState == "beforeBegin") {
			
			if (GamePad.GetButton(GamePad.Button.A, GamePad.Index.One) || 
				Input.GetKey(KeyCode.A)
			){
				DontDestroyOnLoad(GameManager.singleton.gameObject);
				SceneManager.LoadScene("Level");
				StopAllCoroutines();
			}
		}
		
	}
}
