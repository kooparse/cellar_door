using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject FPSController;
    public GameObject BodyController;
	public static Vector3 TmpPosition = new Vector3(0f, 0f, 0f);
  	public static int walkSpeed = 10;
	public int runSpeed = 20;
  	public bool is2DActive = false;

	// Use this for initialization
	void Start () {
		setPlayerPerspective(is2DActive);
	}
	
	// Update is called once per frame
	void Update () {
		// If Shift is pressed, activate the 3D mode
		is2DActive = !Input.GetKey(KeyCode.LeftShift);
		setPlayerPerspective(is2DActive);
	}


	public void setPlayerPerspective(bool is2DMode) {
		FPSController.SetActive(!is2DMode);
		BodyController.SetActive(is2DMode);
	}
}
