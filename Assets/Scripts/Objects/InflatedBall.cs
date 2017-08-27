using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflatedBall : Objects {
	void Awake(){
		objectText = new string[,] { {
				"Well isn't this fun, great for long hours in front of the computer and rather bouncy"
			}, {
				"I think this thing might be deflating"
			}, {"Why couldn't we have just gotten a normal chair for this thing, was this her idea"
			}, { "Jesus christ this thing is pathetic" }
		};
	}
}
