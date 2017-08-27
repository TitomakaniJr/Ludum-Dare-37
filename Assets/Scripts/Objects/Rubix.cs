using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubix : Objects {

	public Sprite[] sprites;

	SpriteRenderer sr;
	int[] count = new int[4];
	void Awake(){
		objectText = new string[,] {{
				"I suppose I have plenty of time to figure this thing out",
				"Maybe Lisa can help me, she seems fairly... on the cube",
				"Someday..."}, {
				"I'm a space expolorer for God's sake... Maybe another day", "I'm a space expolorer for God's sake... Maybe another day",
				"I really don't want to play with this anymore"
			}, {"She... solved... it.The audacity of this woman", "She... solved... it.The audacity of this woman",
				"Months of getting this cube where I want it and she sweeps in for the glory?!"
			}, { "I hate you", "I hate you", "I hate you" }
		};
		for (int i = 0; i < count.Length; i++) {
			count [i] = 0;
		}
		sr = GetComponent<SpriteRenderer> ();
	}
		

	void Update(){
		if (count [gm.GetDay()] < 3 && (gm.GetDay()!= 2 || gm.GetDay() != 3)) {
			usable = true;
		}
		if (gm.GetDay() == 2) {
			sr.sprite = sprites [14];
			usable = false;
		}
	}

	public override void Use ()
	{
		if (count [gm.GetDay()] < 3) {
			int index = Random.Range (0, sprites.Length - 2);
			sr.sprite = sprites [index];
			count [gm.GetDay ()]++;
		}
		if (count [gm.GetDay ()] == 3) {
			usable = false;
		}
	}
}
