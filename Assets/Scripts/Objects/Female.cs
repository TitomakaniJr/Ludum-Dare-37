using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Female : Objects {
	public Sprite[] sprites;
	SpriteRenderer sr;

	void Awake(){
		objectText = new string[,] {{
				"Well isn't this quiet the situation, seems like we lost comms and nav. Have you ever seen anything like this?"}, {
				"Well Lisa this really isn't looking up but it's important we keep our heads on straight, if we keep working together we can figure this thing out"
			}, {"What do you have planned? Why are you in your suit? You going out for a picnic, or do you have something more sinister in mind?"
			}, { "Why did you do it? He was my friend and you killed him! I won't let you hurt anymore people" }
		};
		usable = true;
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if (gm.GetDay () == 1) {
			transform.position = new Vector3 (4.3f, -2.9f, 0);
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (gm.GetDay () == 2) {
			sr.sprite = sprites [1];
			transform.position = new Vector3 (35.9f, -1.77f, 0);
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (gm.GetDay () == 3) {
			sr.sprite = sprites [0];
			transform.position = new Vector3 (-8.46f, -2.65f, 0);
			transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public override void Use ()
	{
		if (gm.GetDay () == 3) {
			if (gm.dayTask [gm.GetDay (), 1] == false) {
				player.displayText ("I should make a new log");
			} else {
				gm.dayTask [gm.GetDay (), 0] = true;
				player.displayText (objectText [gm.GetDay (), 0]);
				gm.Kill ();
			}
		} else {
			gm.dayTask [gm.GetDay (), 0] = true;
			player.displayText (objectText [gm.GetDay (), 0]);
		}
	}
}
