using UnityEngine;
using System.Collections;

public class bookPick : MonoBehaviour {

	private bool moveOn;
	private int count;

	// Use this for initialization
	void Start () {
		moveOn = false;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveOn) {
			Vector3 v;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			v = hit.point;
			v.y = 0.7f;

			transform.position = Vector3.MoveTowards(transform.position, v, 1);
		}
	}

	void OnMouseDown() {
		Debug.Log ("key down"+(count++));
		Vector3 v;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		v = hit.point;
		v.y = 0.7f;
		transform.position = v;

		this.GetComponent<Rigidbody> ().isKinematic = true;
		moveOn = true;
	}

	void OnMouseUp() {
		Debug.Log ("key up"+(count++));
		this.GetComponent<Rigidbody> ().isKinematic = false;

		moveOn = false;
	}
}
