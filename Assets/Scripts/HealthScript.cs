using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = new Vector3(-1.6f, 0, -2f);
		//GameObject.Find("Health Bar").transform.localScale.x = 3.0;
		Vector3 temp = this.transform.localScale;
		temp.x = PlayerScript.health * 0.01f;
		this.transform.localScale = temp;
	}
}
