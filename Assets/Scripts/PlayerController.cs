using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float speed;
    private Vector3 movementVertical;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody>();
        movementVertical = new Vector3(0,0,2);
	}

	void FixedUpdate() {

        //Horizontal Movement between Lanes
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.AddForce(movement * speed);


        //Automatic Vertical Movement
        rb.AddForce(movementVertical);
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
        }
    }
}
