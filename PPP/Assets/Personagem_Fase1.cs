using UnityEngine;
using System.Collections;

public class Personagem_Fase1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W)){
			this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1);
		}
	}
}
