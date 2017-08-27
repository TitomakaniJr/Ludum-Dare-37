using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Objects {
	SpriteRenderer sr;

	void Awake(){
		objectText = new string[,] { {
				"Now THIS is one nice chair, those colors, the back support, the cushion. Perfect"
			}, {
				"I know this situation seem worrisome, but we will make it through. Thank you for your support"
			}, {"There you are buddy, I was worried about you. I had a nightmare that something terrible happened"
			}, { "I know it was her, must have sent him right out of the airlock. I'll have my revenge" }
		};
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if (gm.GetDay () == 3) {
			sr.sprite = null;
		}
	}
}
