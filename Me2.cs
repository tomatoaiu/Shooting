using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me2 : Me {

	// Use this for initialization
	protected void Start () {
		base.Start ();
	}

	protected void Update()
	{
		base.Update ();
	}

	protected override void MeMove(float x, float y){
		// 移動する向きを変える
		Vector2 direction = new Vector2 (x, y).normalized;
		// 移動する向きとスピードを代入する
		Move (direction);
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "EnemyBullet" && !hiding){
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
	}

}
