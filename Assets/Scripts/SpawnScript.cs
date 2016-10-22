using System.Text.RegularExpressions;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	public Transform[] spawnPoint;
    public float spawnTime = 1.5f;

    public GameObject pickUps;
    public GameObject purplePickUp;

    private PlayerController controller;
    private bool[] spawnPointAvailability;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnPickUps",0.5f,0);
	}

    void SpawnPickUps(){
		int spawnIndex = Random.Range(0,spawnPoint.Length);
        int luckyNumber = Random.Range(0,spawnPoint.Length);
        if (luckyNumber.Equals(10)){
            Instantiate(purplePickUp, spawnPoint[spawnIndex].position, pickUps.transform.rotation);
        }
        else {
                Instantiate(pickUps, spawnPoint[spawnIndex].position, pickUps.transform.rotation);
        }

    }

}
