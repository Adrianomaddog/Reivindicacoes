//ALK>
//
using UnityEngine;
using System.Collections;

public class Inimigo_Fase1 : MonoBehaviour {
    public float velocidade = 1;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (Time.deltaTime * velocidade)); // Indo para baixo;
	}

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "shot"){
            Destroy(collider.gameObject);
            Destroy(gameObject); // Auto-destruição;

            // Pontos para jogador:
            GameObject.Find("Player_Fase1").GetComponent<Personagem_Fase1>().DerrotouInimigo();
        }
    }
}
