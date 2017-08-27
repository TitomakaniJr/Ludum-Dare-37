using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : Objects {
	public Sprite[] sprites;
	SpriteRenderer sr;

	void Awake(){
		sr = GetComponent<SpriteRenderer> ();
	}
	
	void Update(){
		if (gm.GetDay () < 4) {
			if (sr.sprite != sprites [gm.GetDay ()]) {
				sr.sprite = sprites [gm.GetDay ()];
			}
		}
	}
}
