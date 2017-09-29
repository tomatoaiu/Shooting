using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

//	public GameObject scoreText;
	public int sumScorePoint{get; set;}
	private Text _text;

	// Use this for initialization
	void Start () {
		sumScorePoint = 0;
		_text = GetComponentInChildren<Text> ();
		Debug.Log ("Startが呼ばれました" + _text);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetText(int scorePoint){
		sumScorePoint += scorePoint;
		_text.text = "<color=white>Score : " + sumScorePoint.ToString() + "</color>";
	}
}
