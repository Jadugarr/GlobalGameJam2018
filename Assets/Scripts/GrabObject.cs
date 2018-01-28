using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Events;

public class GrabObject : MonoBehaviour {

	public int viewDistance = 4;
	public LayerMask layer;
	public int rotateSpeed = 100;
	public GameObject player;
	public int resetWait = 1;
	public float objectDistance = 1;

	public AudioManager audioManager;
	private bool objectHold;
	private GameObject currentObject;
	private Vector3 objectPosition;
	private Quaternion objectRotation;
	private bool mouseReleased;
	private bool hasButton;
	private GameObject buttonOfInteractable;

	
	private GameObject interactableObject;

	private EventManager eventManager = EventManager.Instance;

	void Start(){
		objectHold = false;
		mouseReleased = true;
		hasButton = false;
	}

	void LateUpdate(){
		if(interactableObject != null){
			Shader highlightShader = Shader.Find ("Legacy Shaders/Self-Illumin/Diffuse");
			interactableObject.GetComponent<Renderer>().material.shader = highlightShader;
		}

		interactableObject = null;
	}

	void Update(){
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (transform.position, forward, out hit, viewDistance, layer) && !objectHold) {
			interactableObject = hit.transform.gameObject;
			bool isButton = interactableObject.GetComponent<InteractableObject> ().isButton;
			if (Input.GetMouseButtonDown (0) && mouseReleased) {
				if (!isButton) {
					audioManager.PlayPickUpSound();
					interactableObject.GetComponent<Collider>().enabled = false;
					if(player != null){
						player.transform.gameObject.GetComponent<RigidbodyFirstPersonController> ().LockMovement ();
					} else{
						Debug.Log("lock mouse movement");
						transform.GetComponent<MouseCamera>().LockMovement();
					}
					mouseReleased = false;
					objectHold = true;
					currentObject = hit.transform.gameObject;
					objectPosition = currentObject.transform.position;
					objectRotation = currentObject.transform.rotation;
					foreach(Transform child in currentObject.transform){
						if(child.GetComponent<InteractableObject>() != null && child.GetComponent<InteractableObject>().isButton){
							hasButton = true;
							buttonOfInteractable = child.gameObject;
							break;
						}
					}
					Debug.Log("has button: " + hasButton);
					HoldObject ();
				} else {
					interactableObject.GetComponent<InteractableObject> ().ButtonPressed ();
				}
			}
		}

		if(objectHold){
			HoldObject ();

			currentObject.transform.Rotate (new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);

			if(Input.GetKeyDown(KeyCode.E) && hasButton){
				Debug.Log("Button on interactable object triggered");
				buttonOfInteractable.GetComponent<InteractableObject>().ButtonPressed();
			}

			if (Input.GetMouseButtonDown (0) && mouseReleased) {
				currentObject.GetComponent<Collider>().enabled = true;
				if(player != null){
					player.transform.gameObject.GetComponent<RigidbodyFirstPersonController> ().UnlockMovement ();
				} else{
					Debug.Log("unlock mouse movement");
					transform.GetComponent<MouseCamera>().UnlockMovement();
				}
				mouseReleased = false;
				objectHold = false;
				StartCoroutine(ResetPosition(currentObject, objectPosition, objectRotation));
				currentObject = null;
				sendInput ();
			}
		}

		if (!Input.GetMouseButtonDown (0) && !mouseReleased) {
			mouseReleased = true;
		}

	}

	void HoldObject(){
		currentObject.transform.position = transform.position + transform.forward * objectDistance;
	}

	IEnumerator ResetPosition(GameObject obj, Vector3 position, Quaternion rotation){
		obj.transform.position = new Vector3 (0,0,-5);
		yield return new WaitForSeconds (resetWait);
		obj.transform.position = position;
		obj.transform.rotation = rotation;
	}

	private void sendInput(){
		Debug.Log("Fire Grabbed Event");
		eventManager.FireEvent(EventTypes.SendGrabbed, new SendGrabbedEvent(true));
	}
}