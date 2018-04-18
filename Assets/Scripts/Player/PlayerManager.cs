using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Player {
	public class PlayerManager : MonoBehaviour {

		[SerializeField] GameObject FPSController;
		[SerializeField] GameObject BodyController;

		public static int walkSpeed = 10;
		public static int runSpeed = 20;

		public bool is2DActive = false;
		public static Vector3 TmpPosition = new Vector3(0f, 0f, 0f);

		private GameObject _currentControllerRef;

		// Use this for initialization
		void Start () {
			GameObject.Find("DefaultCamera").SetActive(false);
			setPlayerPerspective(is2DActive);
		}
		
		// Update is called once per frame
		void Update () {
			// If Shift is pressed, activate the 3D mode
			bool switcherModeIsPressed = !Input.GetKey(KeyCode.LeftShift);
			if (is2DActive != switcherModeIsPressed) {
				is2DActive = switcherModeIsPressed;
                setPlayerPerspective(is2DActive);
			}
		}

		public void setPlayerPerspective(bool is2DMode) {
			GameObject controller = is2DMode ? BodyController : FPSController;
			Destroy(_currentControllerRef);
			_currentControllerRef = Instantiate(controller, TmpPosition, Quaternion.identity) as GameObject;
			_currentControllerRef.transform.parent = gameObject.transform;
		}
	}
}