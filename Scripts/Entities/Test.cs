using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Test : MonoBehaviour
{

    [Header("Movement")]
    [Range(0, 10)]
    public float speed;
    public float acceleration;
    public float turnStrength;

    [Space(10)]
    [Header("Base details")]
    public string objName;
    public Color objColor;

    [Tooltip("Max time to reach full value")]
    [Range(1,10)]
    public float maxTime;

    float timePassed = 0;
    public AnimationCurve animCurve;

    public void Update()
    {
        timePassed += Time.deltaTime;
        float myVar = animCurve.Evaluate(timePassed / maxTime);
        Debug.Log("Ver : " + myVar);
    }
}
