using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Player {
  public class PlayerBodyMoveController : MonoBehaviour {

    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
      float Horizontal = Input.GetAxis("Horizontal");
      float deltaTime = Time.deltaTime;
      CharacterController controller = GetComponent<CharacterController>();

      // Moving even when is jumping
      moveDirection = new Vector3(Horizontal, moveDirection.y, 0);
      // Moving forward our player
      moveDirection.x *= PlayerManager.walkSpeed;

      if (controller.isGrounded && Input.GetKey(KeyCode.Space)) {
        moveDirection.y = PlayerManager.jumpSpeed;
      }

      moveDirection.y -= PlayerManager.gravity * Time.deltaTime;
      controller.Move(moveDirection * deltaTime);
    }

  }
}