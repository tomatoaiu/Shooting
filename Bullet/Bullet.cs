using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bulletクラス
/// shooterによって生成される弾
/// </summary>
public class Bullet : MonoBehaviour {

	/// <summary>
	/// The buleet speed.
	/// </summary>
	public float buleetSpeed = 1f;

	/// <summary>
	/// The bulett power.
	/// </summary>
	public int bulettPower = 1;

	/// <summary>
	/// The bullet life time.
	/// </summary>
	public float bulletLifeTime = 5f;

	/// <summary>
	/// 時間によって弾をtrueなら消す
	/// </summary>
	public bool isKillBulletByTime = false;

	/// <summary>
	/// 画面外にいった弾をtrueなら消す
	/// </summary>
	public bool isKillOutsideBullet = true;

	/// <summary>
	/// isKillBulletByTimeがtrue時、弾をbulletLifeTime秒後削除
	/// </summary>
	protected void killBullet(){
		if (!isKillBulletByTime) return;
		Destroy (gameObject, bulletLifeTime);
	}

	/// <summary>
	/// isKillOutsideBulletがtrue時、画面外いった弾を削除、
	/// </summary>
	protected void killOutSideBullet(){
		if (!isKillOutsideBullet) return;
		if (!gameObject.GetComponentInChildren<Renderer> ().isVisible) {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// bulletが進む
	/// </summary>
	protected void MoveBullet(){
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * buleetSpeed;
	}

	protected void Strat(){
		killBullet ();
	}

	protected void Update(){
		killOutSideBullet ();
		MoveBullet ();
	}
}
