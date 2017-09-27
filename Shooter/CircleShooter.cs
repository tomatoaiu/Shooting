using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 360度一回転させながら打つシューター
/// </summary>
public class CircleShooter : Shooter {

	private float _shooterAngle;

	/// <summary>
	/// Dos the shooter.
	/// </summary>
	/// <returns>The shooter.</returns>
	protected  override IEnumerator DoShooter(){
		while (true) {
			CreateBullet (currentBullets++);
			transform.rotation = Quaternion.Euler (0, 0, _shooterAngle);
			_shooterAngle += shooterAngle;
			AdjustmentCurrentBullets ();
			yield return new WaitForSeconds (shotInterval);
		}
	}

	protected void Start(){
		_shooterAngle = 0;
		base.Start ();
	}



}
