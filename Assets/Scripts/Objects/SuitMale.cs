using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitMale : Objects {
	void Awake(){
		objectText = new string[,] {{
				"Now this is a thing of beauty, such a sleek design",
				"Whoever made these suits is truly a genius",}, {
				"Wait a minute, is this a newer model", 
				"I'm sure this thing has seen some serious action in it's time, I hope to have as many adventures with mine",
			}, {"If there was a catastrophic accident would she give her suit to me?", "If there was a catastrophic accident would she give her suit to me?"
			}, { "No need to worry about this anymore, looks like mine is the best suit now"
				, "She might try to steal mine, I need to keep a very close eye on that woman" }
		};
	}
}
