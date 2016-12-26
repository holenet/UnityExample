using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

		if (Input.GetKey (KeyCode.Space) && CheckPlace()) {
			rb.velocity = new Vector3 (rb.velocity.x, 5, rb.velocity.z);
		}
	}

	void LateUpdate() {
		if (transform.position.y < -0.5f) {
			winText.text = "You Lose!";
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}
 
	void SetCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 15)
			winText.text = "You Win!";
	}

	bool CheckPlace() {
		print ("x=" + transform.position.x + " z=" + transform.position.z);
		return 0.0f<transform.position.y &&
			transform.position.y < 0.6f &&
		-10.5f < transform.position.x &&
		transform.position.x < 10.5f &&
		-10.5f < transform.position.z &&
		transform.position.z < 10.5f;
	}
}