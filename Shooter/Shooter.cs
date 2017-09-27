using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	/// <summary>
	/// The bullets.
	/// </summary>
	public GameObject[] bullets;

	/// <summary>
	/// The shooter hitpoint.
	/// </summary>
	public int ShooterHitpoint = 1;

	/// <summary>
	/// 弾を打ち出す間隔
	/// </summary>
	public float shotInterval = 4f;

	/// <summary>
	/// The shooter score point.
	/// </summary>
	public int ShooterScorePoint = 1;

	/// <summary>
	/// The current bullets.
	/// </summary>
	protected int currentBullets;

	/// <summary>
	/// 弾を打ち出す角度
	/// </summary>
	public float shooterAngle;

	/// <summary>
	/// 弾の個数
	/// </summary>
	public int shooterNumber;

	/// <summary>
	/// curretn番目の弾を生成、shooterのtransportで
	/// </summary>
	/// <param name="current">bullets配列の番号</param>
	protected void CreateBullet(int current){
		Instantiate (bullets[current], transform.position, transform.rotation);
//		_b.transform.SetParent (transform);
	}

	/// <summary>
	/// Dos the shooter.
	/// </summary>
	/// <returns>The shooter.</returns>
	protected  virtual IEnumerator DoShooter(){
		while (true) {
			CreateBullet (currentBullets++);
			AdjustmentCurrentBullets ();
			yield return new WaitForSeconds (shotInterval);
		}
	}

	/// <summary>
	/// currentBulletsの調整、bulletLengthよりも大きくなったら０に
	/// </summary>
	protected void AdjustmentCurrentBullets(){
		if (currentBullets >= bullets.Length) {
			currentBullets = 0;
		}
	}

	protected void Start(){
		currentBullets = 0;
		StartCoroutine ("DoShooter");
	}
}
