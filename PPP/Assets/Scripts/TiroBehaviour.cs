using UnityEngine;
using System.Collections;

public class TiroBehaviour : MonoBehaviour {
	public float velocidade = 6;
	public float tempoMaximo = 1; // Tempo maximo para destruir;
	private float tempo = 0; // Tempo vivo;

	void MoveUp(){
		this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (Time.deltaTime * velocidade));
	}
	
	// Update is called once per frame
	void Update () {
		MoveUp ();
		// Auto destruicao:
		if(tempo > tempoMaximo){ // Pode destruir;
			Destroy(this.gameObject);
		}
		tempo += Time.deltaTime;
	}
}
