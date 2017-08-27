using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleDead : Objects {
	void Awake(){
		objectText = new string[,] { {
				"", ""
			}, {
				"", ""
			}, {"", ""
			}, { "I'm not sure what she was planning but at least I will never have to find out", 
				"Why did you have to hurt someone I loved, it didn't have to be this way" }
		};
	}
}
