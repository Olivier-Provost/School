using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceZone : MonoBehaviour {

    public float hallwayForcePerSec = 1;
    List<Rigidbody> rbList = new List<Rigidbody>();

	private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (!rbList.Contains(rb))
            rbList.Add(rb);
    }

    private void OnTriggerExit(Collider other)
    {
        rbList.Remove(other.GetComponent<Rigidbody>());
    }

    private void FixedUpdate()
    {
        for (int i = rbList.Count - 1; i >=0; i--)
        {
            if (!rbList[i])
                rbList.RemoveAt(i);
            else
            {
                rbList[i].AddForce(rbList[i].transform.forward * hallwayForcePerSec);
                if (rbList[i].velocity.magnitude < GV.BLOOD_SPEED_MAX)
                    rbList[i].velocity = rbList[i].velocity.normalized * GV.BLOOD_SPEED_MAX;
            }
        }
    }
}
