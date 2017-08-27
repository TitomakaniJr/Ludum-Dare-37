using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnAwake : MonoBehaviour {
	public GameObject DF;
	public GameObject player;

	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
		sr.enabled = false;
		DF.SetActive (true);
		player.SetActive (true);
	}
}
