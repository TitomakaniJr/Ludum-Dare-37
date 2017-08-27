using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : Objects {
	void Awake(){
		objectText = new string[,] { {
				"When I was approached by Valkus to take this voyage I was overcome with joy. I can't repay them enough for giving me this chance"
			}, {
				"I'm sure they will notice we are far off course and be sending someone out soon"
			}, {"Valkus... Don't let me down, you put me in this situation. There should be some sort of guidelines or codes for a happening like this"
			}, { "Did you know she was deranged when you sent her up here with me? You must have known after she spent so long in deep space travel" }
		};
	}
}
