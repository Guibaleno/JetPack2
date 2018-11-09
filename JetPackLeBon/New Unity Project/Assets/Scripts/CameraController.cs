using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // Update is called once per frame
    public Transform target;
	void Update () {
		transform.position = new Vector3(target.position.x, transform.position.y, -1);
	}
}
