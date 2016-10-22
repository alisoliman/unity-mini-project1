using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {


    public CharacterController controller;
    private Vector3 movementVector;
    private AudioSource Source;
    public AudioClip cubeCollected;
    public AudioClip originalSound;


    // Scores Calculations
    private float difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int countTriggers = 0;
    private int triggerToNextLevel = 30;
    private double score;
    public Text scoreText;


    public GameManager gameManager;
    private int destroyCounter;
    private Color currentFieldColor;
    private bool dividedScore = true;

    // Floats
    private float speed = 5.0f;
    private float hardnessLevel;

    // Rigid bodies
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        // Initialisations
        Source = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
	    rb = GetComponent<Rigidbody>();
        score = 0;
        destroyCounter = 0;
        setCountText();
        currentFieldColor = gameManager.redMaterial.color;


        gameManager.instantiateField();
        gameManager.instantiateField();
        gameManager.instantiateField();

	}

    void Update() {

        //Moving the Player
        movementVector = Vector3.zero;
        movementVector.x = Input.GetAxisRaw("Horizontal")*0.5f;
        if (Input.GetKeyDown(KeyCode.Space)){
            movementVector.y = 20.0f*speed*Time.deltaTime;
        }
        else{
            if (controller.isGrounded) {
                movementVector.y = -0.08f;
            }
            else{
                movementVector.y -= 1.0f * Time.deltaTime;
            }
        }

        movementVector.z = (speed+difficultyLevel)*Time.deltaTime;


        controller.Move(movementVector);





        // Changing the Player's Material upon clicking any of these Inputs
        if (Input.GetKeyDown(KeyCode.Q)){
            GetComponent<Renderer>().material = gameManager.redMaterial;
        }
        if (Input.GetKeyDown(KeyCode.W)){
            GetComponent<Renderer>().material = gameManager.blueMaterial;
        }
        if (Input.GetKeyDown(KeyCode.E)){
            GetComponent<Renderer>().material = gameManager.greenMaterial;
        }

        // Adjusting Difficulty Level
        if (countTriggers>=triggerToNextLevel)
            LevelUp();
    }


    void LevelUp(){
        difficultyLevel += 1;
        triggerToNextLevel = triggerToNextLevel + 30;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")){
            Source.clip = cubeCollected;
            StartCoroutine(StartClip());
            Destroy(other.gameObject);
            score += 20;
            setCountText();
        }
        if (other.gameObject.CompareTag("Purple Pick Up")){
            Destroy(other.gameObject);
            Source.clip = cubeCollected;
            StartCoroutine(StartClip());
            for (int i = 1; i < 4; i++){
                gameManager.changeColor(gameManager.field[destroyCounter+i],gameManager.greyMaterial);
            }
        }
        if (other.gameObject.CompareTag("Generate Trigger")){
            countTriggers += 1;
            gameManager.instantiateField();

        }
        if (other.gameObject.CompareTag("Destroy Trigger")){
            if (destroyCounter != 0){
                Destroy(gameManager.field[destroyCounter]);
            }
            destroyCounter++;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Generate Trigger")){
            currentFieldColor = gameManager.field[destroyCounter+1].transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial.color;
            if (currentFieldColor.Equals(gameManager.greyMaterial.color) == false
            && !gameObject.GetComponent<Renderer>().material.color.Equals(currentFieldColor)){
            decreaseScore();
            }
        }
    }

    void decreaseScore(){
        //Checking the material and adjusting the score
        if (gameObject.GetComponent<Renderer>().material.Equals(currentFieldColor) == false){
            score = Math.Floor(score/2);
            setCountText();
        }
    }

    void setCountText(){
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator StartClip() {

        Source.Play();
        yield return new WaitForSeconds(Source.clip.length);
        Source.clip = originalSound;
        Source.Play();
    }
}
