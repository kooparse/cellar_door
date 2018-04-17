using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Renderer render = gameObject.GetComponent<Renderer>();
		render.material.color = Color.red;
	}

	// Update is called once per frame
	void Update () {

	}
}
