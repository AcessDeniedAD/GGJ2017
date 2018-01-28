using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Audio : MonoBehaviour {

	AudioSource audioSource;
	public  List<AudioClip>  listAudios;

	void Start()
	{
		StartCoroutine (musiiiiiiic ());
	}

	void Update()
	{

		
	}
	IEnumerator musiiiiiiic(){
		while (true) {
			audioSource = GetComponent<AudioSource> ();
			int audioRand = Random.Range (0, listAudios.Count);
			Debug.Log ("RAND");
			Debug.Log (listAudios.Count);
			Debug.Log (audioRand);
			AudioClip audio = listAudios [audioRand];
			int time = Random.Range (4, 40);
			//Play the audio you attach to the AudioSource component
			audioSource.PlayOneShot (audio);

			yield return new WaitForSeconds ((float)time);
		}
		}
}
