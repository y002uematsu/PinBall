using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;
	private float defaultAngle = 20;
	private float flickAngle = -20;

	private Touch myTouch;
	private float myScreenWid = 1118;

	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint> ();
		SetAngle (this.defaultAngle);

		myScreenWid = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}


		for(int i = 0;i < Input.touchCount;i++){
			this.myTouch = Input.GetTouch (i);
			Debug.Log (myTouch.position);

			if (myTouch.phase == TouchPhase.Began && myTouch.position.x < this.myScreenWid/2 && tag == "LeftFripperTag") {
				SetAngle (this.flickAngle);
			}
			if (myTouch.phase == TouchPhase.Ended && myTouch.position.x < this.myScreenWid/2 &&tag == "LeftFripperTag") {
				SetAngle (this.defaultAngle);
			}
			if (myTouch.phase == TouchPhase.Began && myTouch.position.x> this.myScreenWid/2 && tag == "RightFripperTag") {
				SetAngle (this.flickAngle);
			}
			if (myTouch.phase == TouchPhase.Ended && myTouch.position.x> this.myScreenWid/2 &&tag == "RightFripperTag") {
				SetAngle (this.defaultAngle);
			}
		}
	}

	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
