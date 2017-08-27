using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitFemale : Objects{
	SpriteRenderer sr;

	void Awake(){
		objectText = new string[,] {{
				"Lisa's Suit, similar specs to my own",
				"There really isn't much sexier than a woman in a space suit",}, {
				"Wait a minute, is this a newer model", 
				"I'm sure this thing has seen some serious action in it's time, I hope to have as many adventures with mine",
			}, {"If there was a catastrophic accident would she give her suit to me?", "If there was a catastrophic accident would she give her suit to me?"
			}, { "No need to worry about this anymore, looks like mine is the best suit now"
				, "She might try to steal mine, I need to keep a very close eye on that woman" }
		};
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if (gm.GetDay() == 3 || gm.GetDay() == 2) {
			sr.sprite = null;
		}
	}
}
