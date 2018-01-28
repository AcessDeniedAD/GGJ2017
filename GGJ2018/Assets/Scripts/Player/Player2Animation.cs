using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Animation : MonoBehaviour {


    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        GameManager.OnBegin += () => {
            animator.SetBool("IsWalking", true);
        };
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
