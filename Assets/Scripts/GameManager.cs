using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	int day = 0;
	public Animator anim;
	public GameObject player;
	public GameObject female;
	public GameObject trophy;
	public GameObject DeathAnim;
	public Image fadeImage;
	public float fadeSpeed = .5f;
	public float blinkSpeed = 1.5f;
	public float killTime = 3f;
	public Color c0;
	public Color c1;
	public Color cDefault;
	public bool[,] dayTask;
	public bool blink;
	public bool end;

	bool fading;
	bool newDay;
	bool canKill;
	float killTimer;
	int fadeDir;
	float alpha;
	Light dl;

	void Start(){
		dl = FindObjectOfType<Light> ();
		newDay = false;
		dayTask = new bool[,] { { false, false }, { false, false }, { false, false }, { false, false } };
		end = false;
	}
	// Update is called once per frame
	void Update(){
		if (canKill) {
			if (killTimer > 0) {
				killTimer -= Time.deltaTime;
			} else {
				SetFade (1);
			}
		}
		if (fading) {
			Color temp = fadeImage.color;
			temp.a += fadeDir * fadeSpeed * Time.deltaTime;
			temp.a = Mathf.Clamp01 (temp.a);
			fadeImage.color = temp;
			if (temp.a == 1 && fadeDir == 1) {
				fading = false;
				if (canKill) {
					player.SetActive (false);
					female.SetActive (false);
					trophy.SetActive (false);
					DeathAnim.SetActive (true);
					blink = true;
					SetFade (-1);
					anim.SetTrigger ("Kill");
					player.transform.position = new Vector3 (-11.83f, -2.2f, 0);
					player.transform.localScale = new Vector3 (-1, 1, 1);
					canKill = false;
				}
				if (newDay) {
					day++;
					SetFade (-1);
					newDay = false;
				}
			} else if (temp.a == 0 && fadeDir == -1) {
				fading = false;
			}
		}
		if (blink) {
			float t = Mathf.PingPong (Time.time, blinkSpeed) / blinkSpeed;
			dl.color = Color.Lerp (c0, c1, t);
		} else if (dl.color != cDefault) {
			dl.color = cDefault;
		}
	}

	public void SetBlink(bool blinkVal){
		blink = blinkVal;
	}

	public void SetFade(int dir){
		fading = true;
		fadeDir = dir;
	}

	public int GetDay(){
		return day;
	}

	public void NextDay(){
		if (day != 3) {
			newDay = true;
		} else {
			end = true;
		}
		SetFade(1);
	}

	public void Kill(){
		killTimer = killTime;
		canKill = true;
	}
}
