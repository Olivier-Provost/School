using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour {

    public GameObject objectToFollow;
    NavMeshAgent nma;

	// Use this for initialization
	void Start () {
        nma = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        nma.SetDestination(objectToFollow.transform.position);
	}
}
