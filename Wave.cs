using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	[System.Serializable]
	public struct Enemeys{
		public GameObject enemy; // 敵オブジェクト
		public int hp; // 敵HP
		public int sp; // 敵スコアポイント
		public float speed; // 敵スピード
		public Vector3 position; // 敵の生成位置
		public Vector3 rotation; // 敵の生成角度
	}
	public List<Enemeys> enemys = new List<Enemeys> ();

	private bool finishedCloned; // 

	/// <summary>
	/// 初期化が完了しており、子供のenemyが全部いなくなったら自分を消す
	/// </summary>
	private void killWave(){
		// 初期化が完了しており、子供のenemyが全部いなくなったら
		if (finishedCloned && transform.childCount <= 0) {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// Enemeysからnullを除外
	/// </summary>
	private void OmitNullFromEnemys(){
		enemys.RemoveAll (n => n.enemy == null);
	}

	/// <summary>
	/// アタッチされているenemy達をクローン
	/// </summary>
	/// <returns><c>true</c>, if enemies was created, <c>false</c> otherwise.</returns>
	private bool CreateEnemies(){
		foreach (var e in enemys) {
			Vector3 enemyRotaion = e.enemy.transform.rotation.eulerAngles;
			GameObject _e = Instantiate (e.enemy,e.position + transform.position,
				Quaternion.Euler(enemyRotaion + e.rotation),transform) as GameObject;

			Enemy enemyClass = _e.GetComponent<Enemy> (); // アタッチしているエネミーの情報を取得
			enemyClass.enemyHitPoint = e.hp; // ヒットポイント設定
			enemyClass.enemyScorePoint = e.sp; // スコアポイント設定
			enemyClass.enemySpeed = e.speed; // スピード設定
		}
		return true;
	}

	// Use this for initialization
	void Start () {
		OmitNullFromEnemys ();
		finishedCloned = false;
		finishedCloned = CreateEnemies (); // 生成終了後trueが格納
	}
	
	// Update is called once per frame
	void Update () {
		killWave ();
	}
}