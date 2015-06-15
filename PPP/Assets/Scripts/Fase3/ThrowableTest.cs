using UnityEngine;
using System.Collections;

public class ThrowableTest : MonoBehaviour {
    // Atributos:
    private Rigidbody2D body;

    // Métodos:
	// Use this for initialization
	void Start () {
        body = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.T)){
            //Instantiate(TiroPrefab);
// Não pode ser feito aqui, cada jogador deve controlar seu lado para atirar, sendo assim este script não pode estar no objeto bala e sim em um gerenciador de tiros, que irá instanciar os tiros quando for requerido;
        }
        body.AddForce(new Vector2(1.0f, 10.1f));
        //body.gravityScale = 0;
	}
}
