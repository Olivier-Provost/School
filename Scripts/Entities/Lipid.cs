using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lipid : MonoBehaviour {

    public GameObject notCollide;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] cp = collision.contacts;
        Vector3 pointOfContact = cp[0].point;

        if (collision.gameObject != notCollide)
        {
            FixedJoint fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            fj.anchor = collision.transform.InverseTransformPoint(pointOfContact);
        }
    }
}
