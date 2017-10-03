using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enemyクラス
/// 属性：名前、HP、スピード、スコアポイント
/// シューター：オブジェクト、どの向きに生成するか
/// シューター設定：発射間隔、シューターの個数、弾の角度
/// 			  シューターの切り替え間隔、同時に発射するかどうか、同時に使う門数
/// </summary>
public class Enemy : MonoBehaviour {

	public string enemyName = "unknown"; // 名前
	public int enemyHitPoint{get; set;} // HP
	public float enemySpeed{get; set;} // スピード
	public int enemyScorePoint{get; set;} // スコアポイント
	public GameObject scoreManager; // scorepointのtext

	public Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	/// <summary>
	/// 秒数、同時か、何個まで同時うつか1ならshooterは2つ
	/// </summary>
	[System.Serializable]
	public struct ShooterOptions{
		public GameObject shooter; // オブジェクト
		public float angle; // どの向きに生成するか

		// shooterの設定
		public float shotInterval; // 発射間隔
		public int shooterNumber; // シューターの個数
		public float bulletAngle; // 弾の角度

		public float switchInterval; // シューターの切り替え間隔
		public bool isSimultaneous; // 同時に発射するかどうか
		public int howMany; // 同時に使う門数
	}
	public ShooterOptions[] shooterOptions;

	private int currentShooters;
	private List<GameObject> usingShooter = new List<GameObject>();

	void Start () {
		currentShooters = 0;
		UpdateShooterTransform ();
		if (shooterOptions.Length > 0) { // シューターが一つでもアタッチされているなら
			StartCoroutine (SwitchShooter (currentShooters));
		}
		scoreManager = GameObject.Find ("Canvas");

		// 元の画像の赤色のデータのみで表示される。
		this.GetComponent<SpriteRenderer>().color = color;
	}

	void Update () {
		Move ();
		UpdateShooterTransform ();
		this.GetComponent<SpriteRenderer>().color = color;
	}

	protected void Move(){
		EnemyMove (transform.up); // 前に進む
	}

	protected void EnemyMove(Vector2 direction){
		GetComponent<Rigidbody2D> ().velocity = direction * enemySpeed;
	}

	// 自分の弾に敵が当たった時の処理
	protected void OnTriggerEnter2D(Collider2D c){
		if (c.tag == "PlayerBullet") {
			// scorepointの計算
			scoreManager.GetComponent<ScoreManager> ().SetText(enemyScorePoint);

			Destroy (c.gameObject); // 弾の削除
			Destroy (gameObject); // 自分自身の削除
		}
	}

	protected void CreateShooter(GameObject s, int current){
		GameObject _s = (GameObject)Instantiate (s, s.transform.position, s.transform.rotation, transform);
		_s.GetComponent<Shooter>().shooterAngle = shooterOptions[current].bulletAngle;
		_s.GetComponent<Shooter>().shooterNumber = shooterOptions[current].shooterNumber;
		usingShooter.Add (_s);
	}

	protected IEnumerator SwitchShooter(int current){
		while (true) {
			// シューターを削除
			foreach (var g in usingShooter) {
				Destroy (g);
			}
			usingShooter.RemoveAll (g => g != null || g == null);
			usingShooter.Clear();

			var s = shooterOptions [current]; // 毎回書くと長いからsと表す
			if (s.isSimultaneous) { // 今装備されているシューターが同時の場合
				for (int i = current; i < s.howMany + 1; i++) { // 同時に何個シューターを使いたいか
					current = AdjustmentCurrentShooters (i); // 配列の長さを超えていたら0に
					CreateShooter (shooterOptions [i].shooter, i);
				}
			} else {
				CreateShooter (s.shooter, current);
			}
			current = AdjustmentCurrentShooters (++current);
			yield return new WaitForSeconds (s.switchInterval);
		}
	}

	/// <summary>
	/// shooterOptions配列の長さをcurrentが超えたらcurrentを0にする
	/// </summary>
	/// <returns>The current shooters.</returns>
	/// <param name="current">Current.</param>
	protected int AdjustmentCurrentShooters(int current){
		if (current >= shooterOptions.Length) {
			return 0;
		} else {
			return current;
		}
	}

	protected void UpdateShooterTransform(){
		foreach (var s in shooterOptions) {
			s.shooter.transform.position = transform.position;
			if (s.angle >= 0) {
				s.shooter.transform.rotation = Quaternion.Euler (0, 0, s.angle);
			} else {
				s.shooter.transform.rotation = transform.rotation;
			}

		}
	}
}
