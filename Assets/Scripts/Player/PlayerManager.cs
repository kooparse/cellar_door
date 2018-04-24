using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Player {
  public class PlayerManager : MonoBehaviour {

    [SerializeField, Range(1, 50)] static public int walkSpeed = 20;
    [SerializeField, Range(1, 50)] static public int runSpeed = 20;
    [SerializeField, Range(1, 50)] static public float jumpSpeed = 15f;
    [SerializeField] static public float gravity = 40f;
    // Position to keep track of player position between views
    public static Vector3 TmpPosition = new Vector3(0f, 0.3f, -2.0f);

    [SerializeField] GameObject FPSController;
    [SerializeField] GameObject BodyController;
    [SerializeField] bool isViewForced = false;
    [SerializeField] public bool is2DActive = false;
    [SerializeField] bool isDefaultPositionIsActive = false;
    [SerializeField] Vector3 defaultPosition = new Vector3(0f, -0.3f, -2.0f);

    private GameObject _currentControllerRef;

    // Use this for initialization
    void Start() {
      GameObject.Find("DefaultCamera").SetActive(false);
      setPlayerPerspective(is2DActive);
      if (isDefaultPositionIsActive)
        _currentControllerRef.transform.position = defaultPosition;
    }

    // Update is called once per frame
    void Update() {
      // If Shift is pressed, activate the 3D mode
      if (isViewForced) return;

      bool switcherModeIsPressed = !Input.GetKey(KeyCode.LeftShift);
      if (is2DActive != switcherModeIsPressed) {
        is2DActive = switcherModeIsPressed;
        setPlayerPerspective(is2DActive);
      }
    }

    public void setPlayerPerspective(bool is2DMode) {
      Transform transform = gameObject.transform;
      GameObject controller = is2DMode ? BodyController : FPSController;

      Destroy(_currentControllerRef);
      _currentControllerRef = Instantiate(controller, TmpPosition, Quaternion.identity) as GameObject;
      _currentControllerRef.transform.parent = transform;

      if (is2DMode) {
        _currentControllerRef.transform.position = new Vector3(TmpPosition.x, TmpPosition.y, defaultPosition.z);
      }
    }
  }
}
