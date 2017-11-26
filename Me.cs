using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me : Unit {

	protected bool hiding; // ユニットが画面外にいるか
	protected Vector3 mePostion; // 自分の初期位置

	public Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		
	// Use this for initialization
	protected void Start () {
		hiding = false;
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine ("PlayerAttack");
		mePostion = transform.position;
		// 元の画像の赤色のデータのみで表示される。
		this.GetComponent<SpriteRenderer>().color = color;
	}
	
	// Update is called once per frame
	protected void Update () {

		this.GetComponent<SpriteRenderer>().color = color;
		
		PlayerMove ();

		if (!gameObject.GetComponentInChildren<Renderer> ().isVisible) {
			hiding = true;
		} else {
			hiding = false;
		}
	}


	/**********************************************************
	 * 
	 * プレイヤーの攻撃
	 * 
	 * ********************************************************/


	IEnumerator PlayerAttack(){
		while (true) {
			if (Input.GetKey(KeyCode.K)) {
				Shot (transform);

				// sound
				AudioSource audioSource = gameObject.GetComponent<AudioSource>();
				audioSource.PlayOneShot(audioSource.clip);
			}
			yield return new WaitForSeconds (shotDelay);
		}
	}

	/**********************************************************
	 * 
	 * プレイヤーの移動
	 * 
	 * ********************************************************/

	/// <summary>
	/// キーを取得して、プレイヤーを動かす
	/// </summary>
	protected void PlayerMove(){

		if (Input.GetKey (KeyCode.Space)) {
			InitPosition ();
		}

		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		MeMove (x, y);
	}

	/// <summary>
	/// Mes the move.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	protected virtual void MeMove(float x, float y){
	}


	private void InitPosition (){
		transform.position = mePostion;
	}

}
