﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "EnemyBullet"){
			Destroy (col.gameObject);
		}
	}
}
