using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour {

	public bool highlighted = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Shader defaultShader = Shader.Find ("Standard");
		Shader highlightShader = Shader.Find ("Legacy Shaders/Self-Illumin/Diffuse");

		if (highlighted) {
			transform.GetComponent<Renderer> ().material.shader = highlightShader;
		} else {
			transform.GetComponent<Renderer> ().material.shader = defaultShader;
		}
	}

	void LateUpdate(){
		highlighted = false;
	}
}
