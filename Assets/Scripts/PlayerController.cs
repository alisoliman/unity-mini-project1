using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {


    // Vertical Movement Vector
    private Vector3 movementVertical;

    // Scores Calculations
    private int score;
    public Text scoreText;


    public GameManager gameManager;
    private int destroyCounter;

    // Floats
    public float speed;

    // Rigid bodies
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        // Initialisations
	    rb = GetComponent<Rigidbody>();
        score = 0;
        setCountText();
        movementVertical = new Vector3(0,0,2);
        destroyCounter = 0;

        gameManager.instantiateField();

	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)){
            GetComponent<Renderer>().material = gameManager.redMaterial;
        }
        if (Input.GetKeyDown(KeyCode.W)){
            GetComponent<Renderer>().material = gameManager.blueMaterial;
        }
        if (Input.GetKeyDown(KeyCode.E)){
            GetComponent<Renderer>().material = gameManager.greenMaterial;
        }
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
            Destroy(other.gameObject);
            score += 20;
            setCountText();
        }
        if (other.gameObject.CompareTag("Generate Trigger")){
            gameManager.instantiateField();
        }
        if (other.gameObject.CompareTag("Destroy Trigger")){
            if (destroyCounter != 0){
                Destroy(gameManager.field[destroyCounter]);
            }
            destroyCounter++;
        }
    }

    void setCountText(){
        scoreText.text = "Score: " + score.ToString();
    }
}
