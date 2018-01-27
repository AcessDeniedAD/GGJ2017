using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedByObstacle : MonoBehaviour {

    public float timeToGoBack = 0.5f;
	// Use this for initialization
	void Start () {
		if(gameObject.name == "Player1"){
        	GameManager.OnPlayer1TakeDamage += () => {
            	Damage();
        	};
		}else if(gameObject.name == "Player2"){
	        GameManager.OnPlayer2TakeDamage += () => {
	            Damage();
	        };
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Obstacle") {
			StartCoroutine (GoBack ());
		} else if (other.tag == "PlayerObstacle") {
			Destroy (other.gameObject);
			StartCoroutine (GoBack ());
		}
        
    }
    IEnumerator GoBack() {
        GameManager.singleton.TakeDamage(gameObject.name);
        float timer = 0;
        while (timer < timeToGoBack) {
            timer += Time.deltaTime;
            gameObject.transform.position += -Vector3.forward * (WorldManager.speed+1) * Time.deltaTime;
            yield return 0;
        }
		yield return 0;
    }

    public void Damage() {
		if (gameObject.name == "Player2") {
			PlayerStats player2 = gameObject.GetComponent<PlayerStats> ();
			player2.Life -= 1;
			if (player2.Life <= 0){
				GameManager.singleton.LevelFail();
			}
		}

    }
}
