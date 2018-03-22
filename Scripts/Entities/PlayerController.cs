using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    Vector3 forceToAdd;

    public float speed = 1;

    public Text myUI;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceToAdd = new Vector3();
    }

    public void FixedUpdate()
    {
        rb.AddForce(forceToAdd);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, GV.PLAYER_SPEED_MAX);
        forceToAdd = new Vector3();
    }

	public void VerticalPressed(float verticalDirection)
    {
        forceToAdd += transform.up * GV.PLAYER_THRUSTER_ACCEL * verticalDirection * speed;
        myUI.text = "Player's speed : " + forceToAdd;
        Debug.Log("Vertical Pressed : " + verticalDirection);
    }

    public void HorizontalPressed(float horizontalDirection)
    {
        forceToAdd += transform.right * GV.PLAYER_THRUSTER_ACCEL * horizontalDirection * speed;
        myUI.text = "Player's speed : " + forceToAdd;
        Debug.Log("Horizontal Pressed : " + horizontalDirection);
    }

    public void RotationPressed(float rotationPressed)
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotationPressed * GV.PLAYER_THRUSTER_ACCEL);

        Debug.Log("Weapon Pressed : " + rotationPressed);
    }

    public void Thrusters(float thrustAmt)
    {
        forceToAdd += transform.forward * GV.PLAYER_THRUSTER_ACCEL * thrustAmt * speed;
        myUI.text = "Player's speed : " + forceToAdd;
        Debug.Log("Thrusters Pressed : " + thrustAmt);
    }

}
