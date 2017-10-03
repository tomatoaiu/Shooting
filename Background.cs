using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float y;
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Translate (0, -speed, 0);
		if (transform.position.y < -y ) {
			transform.position = new Vector3 (0, y, 0);
		}
	}
}
