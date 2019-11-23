using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	private GameObject scoreText;
	private int score;


	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText");
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){

		string othertag;
		othertag = other.gameObject.tag;
		if (othertag == "SmallStarTag") {
			this.score += 5;
		} else if (othertag == "LargeStarTag") {
			this.score += 10;
		} else if (othertag == "SmallCloudTag") {
			this.score += 15;
		} else if (othertag == "LargeCloudTag") {
			this.score += 30;
		}
		this.scoreText.GetComponent<Text> ().text = "Score:" + this.score;
	}
}
































