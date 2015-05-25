using UnityEngine;
using System.Collections;

public class Personagem_Fase1 : MonoBehaviour {
	//Atributos:
	public float velocidade = 5;
	int IDArma = 0;
	public GameObject prefabTiro;
	private float count = 0; // Contador;

	// Use this for initialization
	void Start () {
	
	}

	void Atirar(){
		//cadencia = cadencia * Time.deltaTime;
		Instantiate(prefabTiro, this.gameObject.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		// Se for Android:
		if(Application.platform == RuntimePlatform.Android)
			this.gameObject.transform.position = Input.GetTouch(0).position;
		else{
			// Mover XY:
			if(Input.GetKey(KeyCode.W)){
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (Time.deltaTime * velocidade));
			}
			if (Input.GetKey (KeyCode.S)) {
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (Time.deltaTime * velocidade));
			}
			if(Input.GetKey(KeyCode.A)){
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * velocidade), gameObject.transform.position.y);
			}
			if(Input.GetKey(KeyCode.D)){
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * velocidade), gameObject.transform.position.y);
			}
		}

		switch(IDArma){
			case 0:
				if(count>1){
					this.Atirar();
					count = 0;
				}
				break;
			case 1:
				// Escudo; Trocar para sprite com escudo;
				break;
			default:
				Debug.Log ("ERRO: Não pegou arma nenhuma!");
				break; // Just needed by Unity! kkkkk;
		}
		count += Time.deltaTime;
	}
}
