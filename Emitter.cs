using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Emitter.
/// waveを排出するクラス
/// n個のwaveを持つ
/// </summary>
public class Emitter : MonoBehaviour {

	public int waveLoopCount = 1;

	/// <summary>
	/// Waves.
	/// </summary>
	[System.Serializable]
	public struct Waves{
		public GameObject wave;
		public Vector3 position;
		public float switchInterval;
		public bool isSimultaneous; // 同時に
		public int howMany;
	}
	public List<Waves> waves = new List<Waves> ();

	// 現在のウェーブ
	private int currentWave;

	private void CreateWave(int c){
		// Waveを作成する
		GameObject wave = (GameObject)Instantiate(waves[c].wave, 
			waves[c].position, 
			transform.rotation);

		// WaveをEmitterの子要素にする
		wave.transform.SetParent(transform);
	}

	protected IEnumerator SwitchWaves(int current){
		while (true) {

			float duration = 0; // 時間を計測

			var w = waves[current]; // 毎回書くと長いからsと表す

			if (w.isSimultaneous) { // 今装備されているwaveが同時の場合
				for (int i = current; i < w.howMany + 1; i++) { // 同時に何個waveを使いたいか
					current = AdjustmentCurrentShooters (i); // 配列の長さを超えていたら0に
					CreateWave (i);
				}
			} else {
				CreateWave (current);
			}
			while(transform.childCount != 0 && duration <= w.switchInterval){ // 子要素のwaveがなくなるまで待つ か　時間がくるまで待つ
				duration += Time.deltaTime;
				yield return new WaitForEndOfFrame ();
			}
			current = AdjustmentCurrentShooters (++current);

		}
	}

	/// <summary>
	/// Waves配列の長さをcurrentが超えたらcurrentを0にする
	/// </summary>
	/// <returns>The current shooters.</returns>
	/// <param name="current">Current.</param>
	protected int AdjustmentCurrentShooters(int current){
		if (current >= waves.Count) {
			return 0;
		} else {
			return current;
		}
	}

	private void OmitNullFromWaves(){
		waves.RemoveAll (w => w.wave == null);
	}

	void Start(){
		waveLoopCount = 1;
		currentWave = 0;
		OmitNullFromWaves ();
		StartCoroutine (SwitchWaves (currentWave));
	}

	void Update(){
		OmitNullFromWaves (); // nullを除外
	}
}
