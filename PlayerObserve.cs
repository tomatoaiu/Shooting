using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObserve : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;

	Unit unit1;
	Unit unit2;

	// Use this for initialization
	void Start () {
		unit1 = p1.GetComponent<Unit>();
		unit2 = p2.GetComponent<Unit>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (unit1.health);
		if(unit1.health <= 0 && unit2.health <= 0){
			SceneManager.LoadScene ("GameOver");
		}
	}
}
