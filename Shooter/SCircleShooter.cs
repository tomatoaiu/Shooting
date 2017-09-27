using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 360度同時に打つシューター
/// </summary>
public class SCircleShooter : Shooter {

	private int _shooterNumber;
	private int angle;

	/// <summary>
	/// Dos the shooter.
	/// </summary>
	/// <returns>The shooter.</returns>
	protected  override IEnumerator DoShooter(){
		while (true) {

			_shooterNumber = 360 / shooterNumber;
			angle = _shooterNumber;
			for (int i = 0; i < shooterNumber; i++) {
				AdjustmentCurrentBullets ();
				transform.rotation = Quaternion.Euler (0, 0, (float)_shooterNumber);
				CreateBullet (currentBullets++);
				_shooterNumber += angle;
			}

			AdjustmentCurrentBullets ();
			yield return new WaitForSeconds (shotInterval);
		}
	}

	protected void Start(){
		_shooterNumber = 0;
		base.Start ();
	}



}
