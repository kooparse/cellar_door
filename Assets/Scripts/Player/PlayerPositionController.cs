using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Player {
	public class PlayerPositionController : MonoBehaviour {
		void OnEnable() {
			gameObject.transform.position = PlayerManager.TmpPosition;
		}

		void OnDisable() {
			PlayerManager.TmpPosition = gameObject.transform.position;
		}
	}
}