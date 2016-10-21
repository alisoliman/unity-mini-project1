using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

    private GameObject player;
    private Light light;

	void Start() {
        light = gameObject.GetComponent<Light>();
	}

	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
		light.color = player.gameObject.GetComponent<Renderer>().material.color;
	}
}
