using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour {

	void Update () {

		Shader defaultShader = Shader.Find ("Standard");
		transform.GetComponent<Renderer> ().material.shader = defaultShader;
	}
}
