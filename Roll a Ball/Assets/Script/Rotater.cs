using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3 (30, 30, 30) * Time.deltaTime);
	}
}
