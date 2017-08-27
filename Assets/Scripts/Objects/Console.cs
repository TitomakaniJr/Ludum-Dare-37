using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : Objects {
	public GameObject image;
	public GameObject playerObject;
	public GameObject cursor;
	public Sprite playerSprite;
	public GameObject creditsImage;
	public Text text;
	float compTime = 1f;
	float screenTime = 10f;
	bool turnOn;
	bool screenOn;
	bool end;
	AudioSource audioS;
	Coroutine co;

	float ScreenTimer;
	float compTimer;
	Animator anim;

	void Awake(){
		objectText = new string[,] { {
				"Today we had a rather significant accident when a meteor hit our ship. We lost comms and navigation along with " +
				"some other less important systems. Lisa has been out for most of the day trying to figure out how much damage there is and " +
				"if it is fixable. If all goes well and the damage is not as bad as it seems we should be back on course within a couple days. A week tops.      PRESS SPACE... "
			}, {"The damage was worse than we imagined, after a month we figured our only hope is some sort of rescue. However I am not a child and I understand " +
				"the odds of anyone finding us in the vastness of space is extremely small. However we are broadcasting an SOS to anyone who " +
				"may be in the near vicinity I have instead decided to focus my efforts on keeping morale up.      PRESS SPACE..."
			}, {"Lisa has started acting very strange. she keeps to herself most days, reading and taking notes. Some days we hardly even exchange two words. " +
				"I have begun to wonder if she is planning something sinister for my friends and I. I have asked Link to keep an eye on her while I'm in the bathroom but " +
				"so far he has given me the all clear. Chair thinks I'm starting to lose it. The headaches are getting worse.      PRESS SPACE..."
			}, { "Chair is gone. I know this was that bitch Lisa. When I was asleep she took him into the airlock and flushed him out. I have put up with her shifty behaviours " +
				"for too long, now it has cost a life and I must take a stand. Anyone who finds this log must know what sort of monster I was dealing with, understand that what I must " +
				"do is justified.      PRESS SPACE..."}, 
			{
				"Things are getting worse with Rick. He is constantly mumbling to his doll and there are periods when he doesn't seem to be there at all. " +
				"Three night ago I woke up to him dragging his chair across the room into the airlock. The next day he accused me of the act, getting in my face... becoming physical. I am worried for my safety. " +
				"The hunger and exhaustion have begun to take a toll on me, but I am more concerned the stress of the situation has caused something to break inside Rick. " +
				"I will continue to keep to myself. To anyone reading these logs... if we didn't make it please tell my family I love them and the prospect of seeing them again was the only thing" +
				" that kept me going on this voyage.      PRESS SPACE..."
			}
		};
		anim = GetComponent<Animator> (); 
		usable = true;
		turnOn = false;
		screenOn = false;
		end = false;
		audioS = GetComponent<AudioSource> ();
	}

	void Update(){
		if (gm.end) {
			FinalDisplay ();
			screenOn = true;
			end = true;
			gm.end = false;
		}
		if (compTimer > 0) {
			compTimer -= Time.deltaTime;
		} else if(turnOn) {
			image.SetActive (true);
			player.displayText ("");
			playerObject.SetActive (false);
			cursor.SetActive (false);
			text.text = "";
			co = StartCoroutine(AnimateText(objectText[gm.GetDay(), 0]));
			ScreenTimer = screenTime;
			turnOn = false;
			screenOn = true;
		}
		if (screenOn && Input.GetKeyDown (KeyCode.Space)) {
			if (end) {
				creditsImage.SetActive (true);
			} else {
				text.text = "";
				anim.SetTrigger ("off");
				StopCoroutine (co);
				screenOn = false;
				SpriteRenderer playerSR = playerObject.GetComponent<SpriteRenderer> ();
				playerSR.sprite = playerSprite;
				playerObject.SetActive (true);
				cursor.SetActive (true);
				image.SetActive (false);
			}
		}
	}

	public override void Use(){
		gm.dayTask [gm.GetDay (), 1] = true;
		if (!turnOn && !screenOn) {
		anim.SetTrigger ("on");
			compTimer = compTime;
			turnOn = true;
			audioS.Play ();
		}

	}

	IEnumerator AnimateText(string inText){
		int i = 0;
		while (i < inText.Length) {
			text.text += inText [i++];
			yield return new WaitForSeconds (.02f);
		}
	}

	public void FinalDisplay(){
		image.SetActive (true);
		StartCoroutine(AnimateText(objectText[4, 0]));
	}
}
