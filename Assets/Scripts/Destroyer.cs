using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    private float destroyTime = 10.0f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject,10.0f);
	}

}
