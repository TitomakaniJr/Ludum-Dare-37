using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : Objects {
	void Awake(){
		objectText = new string[,] {{
				"The door isn't working, I don't have the time to fix it right now though",
				"I don't have enough hours in the day to get this thing working",}, {
				"I wish this thing would just open already", 
				"I bet there is a pretty nice room behind here",
			}, {"I really can't fix this right now", "Will you please open?"
			}, { "I've been dreaming of this room"
				, "Another day I suppose" }
		};
	}
}
