using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Blood"))
        {
            if (!collision.gameObject.GetComponent<Infection>())
            {
                collision.gameObject.AddComponent<Infection>();
                GameObject.Destroy(gameObject);
            }
        }
    }
}

