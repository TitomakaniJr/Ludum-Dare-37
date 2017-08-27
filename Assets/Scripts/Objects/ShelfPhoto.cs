using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfPhoto : Objects {
	void Awake(){
		objectText = new string[,] {{
				"I remember spending weeks at a time hiking around the coasts, seems like a lifetime ago"}, {
				"Part of me wishes I could go back, I haven't seen an actual tree or body of water in ages"
			}, {"Back home I could always get away, now I'm seemingly forever stuck in a room with this woman"
			}, { "I could bury her right next to that river... more peaceful than she deserves"}
		};
	}
}
