using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour {

    float timeOfDeath;
    float infectionTime = 10;
    //Color infectedColor = Color.green;

	// Use this for initialization
	void Start () {
        timeOfDeath = Time.time + infectionTime;
        //GetComponent<Renderer>().material.color = infectedColor;
        GetComponent<Renderer>().material = Resources.Load<Material>("Material/Entities/Infected");
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= timeOfDeath)
            PreformInfection();
	}

    private void OnMouseDown()
    {
        //GameObject.Destroy(gameObject);
        GameObject.Destroy(this);
        GetComponent<Sang>().SetMaterial();
    }

    void PreformInfection()
    {
        int nbVirus = Random.Range(1, 4);
        GameObject go;
        for (int i = 0; i < nbVirus; i++)
        {
            go = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/Virus"));
            go.transform.position = gameObject.transform.position;
        }
        GameObject.Destroy(gameObject);
    }
}
