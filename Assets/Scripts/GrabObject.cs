using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GrabObject : MonoBehaviour {

	public int viewDistance;
	public LayerMask layer;
	public int rotateSpeed;
	public GameObject player;
	public int resetWait;
	public GameObject door;

	private bool objectHold;
	private GameObject currentObject;
	private Vector3 objectPosition;
	private Quaternion objectRotation;
	private bool mouseReleased;

	void Start(){
		objectHold = false;
		mouseReleased = true;
	}

	void Update(){
		if (!Input.GetMouseButtonDown (0) && !mouseReleased) {
			mouseReleased = true;
		}
	}

	void FixedUpdate(){

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (transform.position, forward, out hit, viewDistance, layer) && !objectHold) {
			hit.transform.gameObject.GetComponent<HighlightObject>().highlighted = true;
			if (Input.GetMouseButtonDown (0) && mouseReleased) {
				player.transform.gameObject.GetComponent<RigidbodyFirstPersonController> ().LockMovement();
				mouseReleased = false;
				objectHold = true;
				currentObject = hit.transform.gameObject;
				objectPosition = currentObject.transform.position;
				objectRotation = currentObject.transform.rotation;
				HoldObject ();
			} else {
				//push button
				door.GetComponent<Door>().state = DoorState.Opening;
				GameObject button = hit.transform.gameObject; 
			}
		}

		if(objectHold){
			HoldObject ();

			currentObject.transform.Rotate (new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);

			if (Input.GetMouseButtonDown (0) && mouseReleased) {
				player.transform.gameObject.GetComponent<RigidbodyFirstPersonController> ().UnlockMovement ();
				mouseReleased = false;
				objectHold = false;
				//currentObject.transform.position = objectPosition;
				//currentObject.transform.rotation = objectRotation;
				StartCoroutine(ResetPosition(currentObject, objectPosition, objectRotation));
				currentObject = null;
			}
		}

	}

	void HoldObject(){
		currentObject.transform.position = transform.position + transform.forward;
	}

	void HighlightObject(){
		
	}

	IEnumerator ResetPosition(GameObject obj, Vector3 position, Quaternion rotation){
		obj.transform.position = new Vector3 (0,0,-5);
		yield return new WaitForSeconds (resetWait);
		obj.transform.position = position;
		obj.transform.rotation = rotation;
	}
}