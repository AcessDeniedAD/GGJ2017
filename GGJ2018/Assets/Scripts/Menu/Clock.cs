using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
	private float timeToStart;
	private float timer;
	private float initialWorldSpeed;
    private Quaternion initialRotation;
    public Image blackImage;
    public Image blackImage2;
    public Image clock;

    // Use this for initialization
    void Start () {
        initialRotation = transform.rotation;
		TimerBegin timerBegin = GameObject.Find("GameManager").GetComponent<TimerBegin> ();
		timeToStart = timerBegin.timeToStart;
		initialWorldSpeed = WorldManager.speed;
        StartCoroutine(ClockAppear());
        GameManager.OnBeforeBegin += () => {
            lol();
        };
    }
	public void lol()
    {
        Debug.Log("sdfdsf");
    }
	// Update is called once per frame
	void Update () {
		
		if (GameManager.singleton.GameState == "begin")
		{
			timer += Time.deltaTime;
            if (timer <= timeToStart)
            {
                Debug.Log("While");
                gameObject.transform.Rotate(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -(timeToStart * Time.deltaTime * 40)));
                WorldManager.speed = initialWorldSpeed;
                timer = 0;
            }
            
		}
        else
        {
            transform.rotation = initialRotation;
        }
    }

    IEnumerator ClockDisapear() {
        yield return 0;
        float timer = 0;
        while (timer < 0.4f)
        {
            timer += Time.deltaTime;
            gameObject.transform.localScale -= new Vector3(Time.deltaTime*5, Time.deltaTime*5, Time.deltaTime*5);
            clock.transform.localScale -= new Vector3(Time.deltaTime*5, Time.deltaTime*5, Time.deltaTime*5);
            yield return 0;
        }
        gameObject.transform.localScale = new Vector3(0,0,0);
        clock.transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator ClockAppear() {
        yield return new WaitForSeconds(0.2f);

        //Disparition alpha du noir
        float timer = 0;
        while (timer < 3 )
        {
            timer += Time.deltaTime;
            blackImage.color -= new Color32(0, 0, 0, 5);
            yield return 0; 
        }
        
        yield return new WaitForSeconds(0.2f);
        GameManager.singleton.BeforeBegin();
        //apparation de la montre
        timer = 0;
        
        while (timer < 3)
        {
            timer += Time.deltaTime;
            blackImage2.color -= new Color32(0, 0, 0, 2);

            yield return 0;
        }
        StartCoroutine(ClockDisapear());
    }
}
