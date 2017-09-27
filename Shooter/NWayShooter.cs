using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// n wayシューター
/// </summary>
public class NWayShooter : Shooter {

	/// <summary>
	/// Dos the shooter.
	/// </summary>
	/// <returns>The shooter.</returns>
	protected  override IEnumerator DoShooter(){
		while (true) {
			AdjustmentCurrentBullets ();
			if (shooterNumber % 2 == 1) {
				// 奇数
				OddShooter();
			} else {
				// 偶数
				EvenShooter();
			}

			AdjustmentCurrentBullets ();
			yield return new WaitForSeconds (shotInterval);
		}
	}

	private void OddShooter(){
		// 真ん中
		CreateBullet (currentBullets++);
		AdjustmentCurrentBullets ();

		// 左右
		AdjustmentCurrentBullets ();
		ForLeftRightShooter(shooterAngle, shooterNumber - 1, 1);
	}

	private void EvenShooter(){
		// 左右
		ForLeftRightShooter (shooterAngle / 2f, shooterNumber, 0);
	}

	private void ForLeftRightShooter(float angle, int num, int isOdd){
		float _angleBetween = 0;
		float _angle = angle;

		for(int i = 1; i <= num / 2f; i++){
			if (i == 2 && num % 2 == 0 && isOdd == 0) {
				_angle += angle;
			}
			if (isOdd == 0) {
				_angleBetween += _angle;
//				Debug.Log ("angle 3 : " + _angleBetween);
				LeftRightShooter (_angleBetween);
				LeftRightShooter (-_angleBetween);
			} else {
//				Debug.Log ("angle 3 : " + _angle);
				LeftRightShooter (_angle);
				LeftRightShooter (-_angle);
				_angle += angle;
			}
		}

	}

	private void LeftRightShooter(float angle){
		AdjustmentCurrentBullets ();
		transform.rotation = Quaternion.Euler (0, 0,
			transform.rotation.eulerAngles.z + angle);
		
		CreateBullet (currentBullets++);

		// 生成したら元の角度に戻す
		transform.rotation = Quaternion.Euler (0, 0,
			transform.rotation.eulerAngles.z + -angle);
	}

	protected void Start(){
		base.Start ();
	}



}
