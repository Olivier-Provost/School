using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sang : MonoBehaviour {

    static Transform bloodParent;

    public Vector2 timeToSplitRange;
    float currentTimePassed = 0;
    float timeToSplit;

	// Use this for initialization
	void Start () {
        if (!bloodParent)
        {
            GameObject newObj = new GameObject();
            newObj.name = "BloodParent";
            bloodParent = newObj.transform;
            transform.SetParent(bloodParent);
        }
        timeToSplit = GetTimeToSplit();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(1, 1, 1), ForceMode.Impulse);
        transform.SetParent(bloodParent);
	}
	
	// Update is called once per frame
	void Update () {
        currentTimePassed += Time.deltaTime;
        if (currentTimePassed >= timeToSplit)
        {
            Split();
            timeToSplit = GetTimeToSplit();
            currentTimePassed = 0;
        }
	}

    float GetTimeToSplit()
    {
        return Random.Range(timeToSplitRange.x, timeToSplitRange.y);
    }

    void Split()
    {
        GameObject go = GameObject.Instantiate(gameObject);
        transform.position = new Vector3(0.5f, 0, 0) + transform.position;
        go.transform.position = go.transform.position - new Vector3(0.5f, 0, 0);
        go.name = "Sang";

        //Vector3 dirMag = (transform.position - go.transform.position).normalized;
    }

    public void SetMaterial()
    {
        GetComponent<Renderer>().material = Resources.Load<Material>("Material/Entities/Blood");
    }
}
