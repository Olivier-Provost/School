using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float cameraSpeed;
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        Vector3 moveBy = new Vector3();

		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            moveBy += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            moveBy += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveBy += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveBy += new Vector3(1, 0, 0);
        if (Input.GetKey(KeyCode.Q))
            moveBy += new Vector3(0, 1, 0);
        if (Input.GetKey(KeyCode.E))
            moveBy += new Vector3(0, -1, 0);

        transform.position = transform.position + moveBy * dt * cameraSpeed;
    }
}
