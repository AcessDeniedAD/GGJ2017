using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LooseCoroots : MonoBehaviour {

	private Image blackImage;

    // Use this for initialization
    void Start () {
        GameManager.OnLevelFail += () => {
            LaunchLooseCoroots();
        };
		Clock clock = GameObject.Find("CLock").GetComponent<Clock> ();
		blackImage = clock.blackImage;
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
		float timer = 0;

		string playerName = GameManager.singleton.playerWinner;
		Text text = GameObject.Find ("TextWinner").GetComponent<Text>();
		text.text = "The winner is "+playerName;
		while (timer < 3 )
		{
			timer += Time.deltaTime;
			blackImage.color += new Color32(0, 0, 0, 7);
			text.color += new Color32(0, 0, 0, 2);

			yield return 0; 
		}





		yield return 0;

        //DontDestroyOnLoad(GameManager.singleton.gameObject);
        //SceneManager.LoadScene("Level");
        //StopAllCoroutines();
    }
}
