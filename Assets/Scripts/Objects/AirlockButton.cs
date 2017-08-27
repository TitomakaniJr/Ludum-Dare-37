using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockButton : Objects{
	void Awake(){
		objectText = new string[,] { {
				"The button to open and close the airlock, need to be rather careful around this"
			}, {
				"I really shouldn't be getting too close to this thing, edge of the void and all"
			}, {"How can she go out there knowing her life is in my hands, we are running out of supplies after all"
			}, { "Perfect for disposing of garbage" }
		};
	}
}
