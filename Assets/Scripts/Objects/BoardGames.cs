using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGames : Objects{
	void Awake(){
		objectText = new string[,] {{
				"Oh man I love this thing",
				"All grown up and still collecting toys, take that mom",}, {
				"I love the green, wish I would have splurged and bought the red and blue tunics", 
				"I wonder if Lisa ever played with these",
			}, {"I've seen her looking at you, she thinks you are just some simple play thing", "I'm starting to think you are the only one I can trust"
			}, { "We need to do something about her. First it was our four legged friend, who knows what she might do to you"
				, "I won't let her hurt you" }
		};
	}
}
