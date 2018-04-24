using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Player {
  public class PlayerTrackingController : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {
      Vector3 currentPosition = gameObject.transform.position;
      Vector3 targetPosition = target.transform.position;

      gameObject.transform.position = new Vector3(
          targetPosition.x,
          targetPosition.y + 1.5f,
          currentPosition.z
      );
    }
  }
}