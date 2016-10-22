using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    private GameObject maxThroughput;
    public Button restartButton;
    public Text highscore;

	// Use this for initialization
	void Start () {
        maxThroughput = GameObject.FindGameObjectWithTag("Finish");
        restartButton.GetComponent<Button>().onClick.AddListener(RestartGame);
        highscore.text = "Highscore : " + maxThroughput.transform.position.x;

	}


    void RestartGame(){
        SceneManager.LoadScene("Main");
    }
}
