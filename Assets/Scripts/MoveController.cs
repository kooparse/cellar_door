using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController: MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float Horizontal = Input.GetAxis("Horizontal");
		float deltaTime = Time.deltaTime;
		CharacterController controller = GetComponent<CharacterController>();

        // Moving our player
        moveDirection = new Vector3(Horizontal, 0, 0);
		moveDirection.x *= PlayerManager.walkSpeed;

		controller.Move(moveDirection * deltaTime);
	}

	void OnEnable() {
		gameObject.transform.position = PlayerManager.TmpPosition;
		Debug.Log("2d Enabled!");
	}

	void OnDisable() {
		PlayerManager.TmpPosition = gameObject.transform.position;
		Debug.Log("2d Disable!");
	}
}
