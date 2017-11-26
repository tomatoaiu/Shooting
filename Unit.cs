using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unitクラス自身のスーパークラス
/// </summary>
// RigidBody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour {

	public float speed; // プレイヤーの移動スピード
	public int health; // プレイヤーの体力
	public float shotDelay;
	protected Rigidbody2D rb;
	public GameObject bullet; // プレイヤーの弾プレファブ

	/// <summary>
	/// 弾の生成
	/// </summary>
	/// <param name="origin">Origin.</param>
	protected void Shot(Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);
//		g.transform.SetParent (transform);
	}

	/// <summary>
	/// 弾の生成、オーバーロード
	/// </summary>
	/// <param name="origin">生成する場所、角度、大きさ</param>
	/// <param name="angle">角度</param>
	protected void Shot(Transform origin, float angle){
		origin.rotation = Quaternion.Euler (0, 0, angle);
		Instantiate (bullet, origin.position, origin.rotation);
//		b.transform.SetParent (transform);
	}


	/// <summary>
	/// Move the specified direction.
	/// </summary>
	/// <param name="direction">Direction.</param>
	protected void Move(Vector2 direction){
		// 移動する向きとスピードを代入する
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}
}
