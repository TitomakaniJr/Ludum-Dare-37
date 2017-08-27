using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedMale : Objects {

	void Awake(){
		usable = true;
		objectText = new string[,] { { "I should talk to Lisa" }, { "I should make a new log" } };
	}

	public override void Use ()
	{
		if (gm.dayTask [gm.GetDay (), 0]) {
			if (gm.dayTask [gm.GetDay (), 1]) {
				gm.NextDay ();
			} else {
				player.displayText ("I should make a new log");
			}
		} else {
			player.displayText ("I should talk to Lisa");
		}
	}
}
