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
		Clock clock = GameObject.Find("CLock").GetComponent<Clock> ();
		blackImage = clock.blackImage;
		string playerName = GameManager.singleton.playerWinner;
		Text text = GameObject.Find ("TextWinner").GetComponent<Text>();
		text.text = "The winner is "+playerName;
		Text buttonText = GameObject.Find ("Button").GetComponent<Text>();
		Image buttonImage = GameObject.Find ("ButtonImage").GetComponent<Image>();
		while (timer < 3 )
		{
			timer += Time.deltaTime;
			blackImage.color += new Color32(0, 0, 0, 7);
			text.color += new Color32(0, 0, 0, 2);
			buttonImage.color += new Color32(0, 0, 0, 2);
			buttonText.color += new Color32(0, 0, 0, 2);

			yield return 0; 
		}





		yield return 0;
    }
}
