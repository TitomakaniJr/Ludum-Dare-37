using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

	//Text to be displayed when object is clicked on
	public string[,] objectText;
	//Is the object usable, or only observable
	public bool usable;
	public GameManager gm;
	public Player player;


	int counter;

	void Start(){
		gm = FindObjectOfType<GameManager> ();
		player = FindObjectOfType<Player> ();
		counter = 0;
	}

	//Cursor has entered the object collider
	void OnTriggerEnter2D(Collider2D col){
		CursorController cursorObject = col.GetComponent<CursorController> ();
		if (cursorObject != null) {
			cursorObject.SetObject (this);
		}
	}

	//Cursor has left the object collider
	void OnTriggerExit2D(Collider2D col){
		CursorController cursorObject = col.GetComponent<CursorController> ();
		if (cursorObject  != null) {
			cursorObject.ResetObject ();
		}
	}

	public virtual void Use(){}

	//Object was clicked on, display the text
	public void Observe(){
		if (counter < objectText.GetLength (1)) {
			string observeString = objectText [gm.GetDay (), counter];
			player.displayText (observeString);
			counter++;
		} else {
			int index;
			index = Random.Range (0, objectText.GetLength (1));
			string observeString = objectText [gm.GetDay (), index];
			player.displayText (observeString);
		}
	}
}
