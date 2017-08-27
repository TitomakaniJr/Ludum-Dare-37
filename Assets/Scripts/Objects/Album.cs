using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Album : Objects {
	void Awake(){
		objectText = new string[,] {{
				"Manners, one of my favorites",
				"I wonder if Lisa would like this, maybe we could dance",}, {
				"I probably should have brought more music than just this", 
				"Lisa wasn't a fan",
			}, {"Honestly how many times can you listen to one album", "Where is her music? She must be hiding it from me, I'll have to look around while she is in the bathroom"
			}, { "I would rather listen to two people pooping back and forth forever than this one more time"
				, "ENOUGH!" }
		};
	}
}
