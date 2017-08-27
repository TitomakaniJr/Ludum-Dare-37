using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	//Public Variables
	public Vector2 focusAreaSize;
	public float verticalOffset;
	public float lookAheadDstX;
	public float lookSmoothTimeX;
	public float verticalSmoothTime;
	public BoxCollider2D playerBox;
	public CursorController curs;

	//Private variables
	Random random;
	FocusArea focusArea;

	float currentLookAheadX;
	float targetLookAheadX;
	float lookAheadDirX;
	float smoothLookVelocityX;
	float smoothVelocityY;
	float smoothRotation;
	float rotationTimer;


	int rotationDir;

	bool lookAheadStopped;
	bool backwards;

	void Start(){
		focusArea = new FocusArea (playerBox.bounds, focusAreaSize);
	}
		

	void LateUpdate(){
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		focusArea.Update (playerBox.bounds);
		Vector2 focusPosition = focusArea.center + Vector2.up * verticalOffset;

		if (focusArea.velocity.x != 0) {
			lookAheadDirX = Mathf.Sign (focusArea.velocity.x);
			if (Mathf.Sign (input.x) == Mathf.Sign (focusArea.velocity.x) && input.x != 0) {
				lookAheadStopped = false;
				targetLookAheadX = lookAheadDirX * lookAheadDstX;
			} else {
				if (!lookAheadStopped) {
					lookAheadStopped = true;
					targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX) / 4f;
				}
			}
		}
			
		currentLookAheadX = Mathf.SmoothDamp (currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);
		focusPosition += Vector2.right * currentLookAheadX;
		focusPosition.y = 0;
		focusPosition.x = Mathf.Clamp (focusPosition.x, -28.68f, 29.7f);
		transform.position = (Vector3)focusPosition + Vector3.forward * -10;
	}

	//draw the camera focus area for debugging purposes
	void OnDrawGizmos(){
		Gizmos.color = new Color (1, 0, 0, .5f);
		Gizmos.DrawCube (focusArea.center, focusAreaSize);
	}

	//Focus area that allows the camera to follow the player game object within a predetermined area.
	struct FocusArea{
		public Vector2 center;
		public Vector2 velocity;

		float left, right;
		float top, bottom;

		public FocusArea(Bounds targetBounds, Vector2 size){
			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y + size.y;

			velocity = Vector2.zero;
			center = new Vector2((left + right) /2, (top + bottom)/2);
		}

		public void Update(Bounds targetBounds){
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			center = new Vector2((left + right) /2, (top + bottom)/2);
			velocity = new Vector2 (shiftX, 0);
		}
	}
		
}