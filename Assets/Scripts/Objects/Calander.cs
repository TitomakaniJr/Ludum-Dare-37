using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calander : Objects {
	public Sprite[] sprites;
	SpriteRenderer sr;

	void Awake(){
		objectText = new string[,] { {
				"What is that a pug? Some kind of a goat? It's adorable either way"
			}, {
				"Ahh Valentines day is coming up, I wonder if Lisa would be interested in having dinner with me. Hard to say no... because of the implication"
			}, {"Space Day, now that was my kind of holiday"
			}, { "This calander has been one of the few things keeping me sane these last months. Thank you goat... dog thing" }
		};
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if (sr.sprite != sprites [gm.GetDay ()]) {
			sr.sprite = sprites [gm.GetDay ()];
		}
	}
}
