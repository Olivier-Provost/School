using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionManager : MonoBehaviour {

    public float percentToInfect;
    public int maxNumberOfBlood;
    int InfectStart;
    Sang[] allBlood;

    // Use this for initialization
    void Start () {
        InfectStart = 0;
        allBlood = GameObject.FindObjectsOfType<Sang>();

        foreach (Sang s in allBlood)
            if (Random.value <= percentToInfect)
            {
                s.gameObject.AddComponent<Infection>();
                InfectStart++;
            }

        if (InfectStart == 0)
        {
            allBlood[0].gameObject.AddComponent<Infection>();
        }
	}
	
    void FixedUpdate()
    {
        allBlood = FindObjectsOfType<Sang>();
        if (allBlood.Length >= maxNumberOfBlood)
        {
            foreach (Sang s in allBlood)
            {
                s.timeToSplitRange.x = Mathf.Infinity;
            }
        }
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(allBlood.Length);
	}
}
