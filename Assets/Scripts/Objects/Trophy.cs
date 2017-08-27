using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Objects {
	void Awake(){
		objectText = new string[,] {{"Lisa's award for \"Outstanding Achievements in Space Exploration\"", "I'm sure they will have one of these waiting for me when we get back home"},
			{"I'm really rethinking the rubix cube", "I've got my album and my action figure, what could I possibly be jealous of?"},
			{"If I would have known I was going to be taunted some dumb award I would have brought some of my own", 
				"I bet she is loving how much this thing bugs me, a true scumbag"}, {"If I have to look at this for another day I am going to lose my mind",
				"She thinks there won't be retribution for my sweet innocent seating companion, this is going to be the first to go"}};
	}
}
