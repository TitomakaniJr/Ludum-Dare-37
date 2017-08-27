using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	Player player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.GetComponent<Player>()){
			player.HitWall ();
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.GetComponent<Player>()){
			player.HitWall ();
		}
	}
}
