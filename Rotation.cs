using UnityEngine;
using System.Collections;

public class doRotate : MonoBehaviour {

	static public bool rot = false;
	private Quaternion myRot;
	private int myRotAmt = 0;

	// Use this for initialization
	void Start () {
		myRot =  this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		if (rot == true) {
			myRotAmt = myRotAmt+1;
		}
		if (myRotAmt > 10) {
			myRotAmt = 0;
			rot =  false;
		}

		myRot.y = myRotAmt;
		this.transform.rotation = myRot;
	}
}
