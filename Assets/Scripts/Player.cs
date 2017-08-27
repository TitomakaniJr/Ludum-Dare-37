using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public float moveSpeedX;
	public float moveSpeedY;
	public float textTime = 7f;
	public Text text;
	public Sprite up;
	public Sprite down;
	public Sprite down_d;
	public Sprite up_d;

	float textTimer;
	Animator anim;
	Transform myTransform;
	Rigidbody2D rb2d;
	Vector3 currentPos;
	SpriteRenderer sr;
	Coroutine cr;

	// Use this for initialization
	void Start () {
		textTimer = 0 ;
		currentPos = transform.position;
		anim = GetComponent<Animator> ();
		myTransform = GetComponent<Transform> ();
		rb2d = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		//text.rectTransform.pivot = new Vector2 (-.41f, -1.03f); 
	}
	
	// Update is called once per frame
	void Update () {
		//text.rectTransform.position = new Vector3 (52, 100, 0);
		if (textTimer > 0) {
			textTimer -= Time.deltaTime;
		} else if (text.text != "" && textTimer < 0) {
			text.text = "";
		}
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		//Check for movement to set animations
		if (input.x != 0 || input.y != 0) {
			if (input.x != 0) {
				myTransform.localScale = new Vector3 (input.x, myTransform.localScale.y, myTransform.localScale.z);
				if (input.y == 0 || input.y == -1) {
					anim.SetBool ("up_D", false);
					anim.SetBool ("up_S", false);
					anim.SetBool ("down_S", false);
					anim.SetBool ("down_D", true);
				} else if (input.y == 1) {
					anim.SetBool ("down_D", false);
					anim.SetBool ("up_S", false);
					anim.SetBool ("down_S", false);
					anim.SetBool ("up_D", true);
				} 
			} else if (input.y != 0) {
				switch ((int)input.y) {
				case 1:
					anim.SetBool ("down_D", false);
					anim.SetBool ("up_D", false);
					anim.SetBool ("down_S", false);
					anim.SetBool ("up_S", true);
					break;
				case -1:
					anim.SetBool ("down_D", false);
					anim.SetBool ("up_D", false);
					anim.SetBool ("up_S", false);
					anim.SetBool ("down_S", true);
					break;
				}
			}
			//Move the player
			rb2d.MovePosition (new Vector2 (myTransform.position.x + (moveSpeedX * input.x), 
				myTransform.position.y + (moveSpeedY * input.y)));
			//Adjust the text to the new position
		} else {
			anim.SetBool ("down_D", false);
			anim.SetBool ("up_D", false);
			anim.SetBool ("up_S", false);
			anim.SetBool ("down_S", false);
		}
		currentPos = myTransform.position;
	}

	void LateUpdate(){
	}

	public void displayText(string inText){
		if (cr != null) {
			StopCoroutine (cr);
		}
		text.text = "";
		cr = StartCoroutine(AnimateText(inText));
		textTimer = textTime;
	}

	IEnumerator AnimateText(string inText){
		int i = 0;
		while (i < inText.Length) {
			text.text += inText [i++];
			yield return new WaitForSeconds (.02f);
		}
	}

	public void HitWall(){
		myTransform.position = currentPos;
	}
}
