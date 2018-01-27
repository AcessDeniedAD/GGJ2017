using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCoroots : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GameManager.OnLevelFail += () => {
            LaunchLooseCoroots();
        };

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void LaunchLooseCoroots() {
        StartCoroutine(LooseCoroutine());
    }

    IEnumerator LooseCoroutine() {
        WorldManager.speed = 5;
        GameManager.singleton.GameState = "beforeBegin";
        DontDestroyOnLoad(GameManager.singleton.gameObject);
        SceneManager.LoadScene("Level");
        yield return 0;
        StopAllCoroutines();
    }
}
