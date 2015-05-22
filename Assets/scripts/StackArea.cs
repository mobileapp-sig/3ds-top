using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StackArea : MonoBehaviour {

	private List<Collider> bookList;

	// Use this for initialization
	void Start () {
		bookList = new List<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if ("Book".Equals (other.tag)) {
			if (!other.attachedRigidbody.isKinematic) {
				bookList.Add(other);
			}
			ArrangeBooks();
		}
	}

	private void ArrangeBooks() {
		if (bookList.Count > 0) {
			int xPosCnt = 0;
			int zPosCnt = 0;
			for (int i=0; i<bookList.Count; i++) {
				Vector3 v = new Vector3(0f,0f,4.5f);
				v.x = -4.5f + 0.7f*(xPosCnt++);
				v.z = 4.3f - 1.2f*zPosCnt;
				if (v.x > 0) {
					xPosCnt = 1;
					zPosCnt++;
					v.x = -4.5f;
					v.z = 4.3f - 1.2f*zPosCnt;
				}
				if (!bookList[i].attachedRigidbody.isKinematic) {
					bookList[i].gameObject.transform.position = v;
					bookList[i].attachedRigidbody.isKinematic = true;
				}
			}

		}
	}
}
