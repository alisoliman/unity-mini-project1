using System.Text.RegularExpressions;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	public Transform[] spawnPoint;
    public float spawnTime = 1.5f;

    public GameObject pickUps;

    private PlayerController controller;
    private bool[] spawnPointAvailability;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnPickUps",0.5f,0);
	}

    void SpawnPickUps(){
		int spawnIndex = Random.Range(0,spawnPoint.Length);

		Collider collider = Physics.OverlapSphere(spawnPoint[spawnIndex].position,1)[0];
		if (!collider.CompareTag("Pick Up"))
            Instantiate(pickUps, spawnPoint[spawnIndex].position, pickUps.transform.rotation);

    }

}
