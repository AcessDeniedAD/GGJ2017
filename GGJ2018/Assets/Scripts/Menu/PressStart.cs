using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;
using UnityEngine.SceneManagement;
public class PressStart : MonoBehaviour {

    private Image black;
    public Image Title;
    public GameObject text;
	// Use this for initialization
	void Start () {
        black = GameObject.Find("Black").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any)){
            StartCoroutine(GoGame());
        }
	}
    IEnumerator GoGame()
    {
        float timer = 0;
        Title.CrossFadeColor(new Color(0, 0, 0, 0), 1,false,true);
        while (timer < 3) {
            Debug.Log("okokokokok");
            black.color += new Color32(0,0,0,10);
            
            timer += Time.deltaTime;
            Destroy(text);
            yield return 0;
        }
        SceneManager.LoadScene("Level");
        yield return 0;
    }
}
