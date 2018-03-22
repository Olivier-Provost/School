using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimObject : MonoBehaviour {

    Animator animator;
    float timePassed = 0;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed >= 3)
        {
            animator.SetTrigger("AnyTrigger");
            timePassed = 0;
        }
	}
}
