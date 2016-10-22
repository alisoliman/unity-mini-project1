using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Material redMaterial;
    public Material blueMaterial;
    public Material greyMaterial;
    public Material greenMaterial;

    public GameObject fieldPiece;
    private Vector3 connectingPoint;
    public List<GameObject> field;


	// Use this for initialization
	void Start () {
        field = new List<GameObject>();
        field.Add(gameObject);
        connectingPoint = new Vector3(0,0,10);
        instantiateField();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeColor(GameObject gameObject,Material material){
        for (int i =0; i<transform.childCount; i++){
            gameObject.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = material;
        }
    }

    public void instantiateField(){
        GameObject fieldSpawn = (GameObject)Instantiate(fieldPiece,connectingPoint,transform.rotation);
        int randomColor = Random.Range(1, 5);
        switch (randomColor)
        {
            case 1:
                changeColor(fieldSpawn,redMaterial);
                break;
            case 2:
                changeColor(fieldSpawn,blueMaterial);
                break;
            case 3:
                changeColor(fieldSpawn,greenMaterial);
                break;
            case 4:
                changeColor(fieldSpawn,greyMaterial);
                break;
            default:
                print ("Incorrect Value.");
                break;
        }
        connectingPoint.z = connectingPoint.z + 10;
        field.Add(fieldSpawn);
    }
}
