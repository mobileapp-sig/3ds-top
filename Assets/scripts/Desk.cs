using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Desk : MonoBehaviour {

	public GameObject booksPrefab;
	public GameObject stackArea;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 v ;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			v = hit.point;
			v.y = 2.5f;
			Instantiate(booksPrefab, v, Quaternion.identity);
		}
	}

}
