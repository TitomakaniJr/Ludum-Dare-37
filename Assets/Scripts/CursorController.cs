using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

	public GameObject eye;
	public GameObject hand;
	public Player player;

	Objects curObject;
	Transform myTransform;

	// Use this for initialization
	void Start () {
		//We don't want to see the normal mouse cursor
		Cursor.visible = false;
		myTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Clicked on the object
		if(Input.GetMouseButtonDown(0)){
			UseObject ();
		}
	}

	void LateUpdate(){
		//Update cursor position;
		Vector3 mousePos = Input.mousePosition;
		Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos);
		myTransform.position = Vector3.Lerp (myTransform.position, new Vector3(newPos.x + .4f, newPos.y -.66f, 0), 1);
	}

	//Called when the mouse button is clicked, use or observe the object
	void UseObject(){
		if (curObject != null) {
			if (curObject.usable) {
				curObject.Use ();
			} else {
				curObject.Observe ();
			}
		}
	}

	//Take in the object we are hovering over and set it to the cursor's current object
	public void SetObject(Objects foundObject){
		curObject = foundObject;
		if (curObject.usable) {
			hand.SetActive (true);
		} else {
			eye.SetActive (true);
		}
	}

	//Remove the object
	public void ResetObject(){
		curObject = null;
		hand.SetActive (false);
		eye.SetActive (false);
	}
		
}
