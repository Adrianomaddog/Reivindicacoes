using UnityEngine;
using System.Collections;

public class Personagem_Fase1 : MonoBehaviour {
	//Atributos:
	public float velocidade = 5;
	int IDArma = 0;
	public GameObject prefabTiro;
	private float count = 0; // Contador;
    public float cadencia = 1; // Atira a cada 1 segundo;

    //Extras:
    private int pontos = 0;

    // Deprecated...
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}

	void Atirar(){
		//cadencia = cadencia * Time.deltaTime;
		Instantiate(prefabTiro, this.gameObject.transform.position, Quaternion.identity);
	}

    // Methods for Buttons:
    public void SelecionaArma(){
        this.IDArma = 0;
    }
    public void SelecionaEscudo(){
        this.IDArma = 1;
    }

    public void DerrotouInimigo(){
        this.pontos++;
    }
	
	// Update is called once per frame
	void Update () {
		// Se for Android:
		if(Application.platform == RuntimePlatform.Android){
			if(Input.touchCount > 0){
                Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                tmp.z = 0;
                this.gameObject.transform.position = tmp;
            }
		} else{
			// Mover XY:

            // Tentativa de tratamento para mouse e touch (OBS: isso substituiria a linha de cima):
            if (Input.GetMouseButton(0))
            { // Left Button;
                Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                tmp.z = 0;
                this.gameObject.transform.position = tmp;
            }

            // Input/entrada via teclado:
			if(Input.GetKey(KeyCode.W)){
                //spriteRenderer.sprite = sprites[0];
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (Time.deltaTime * velocidade));
			}
			if (Input.GetKey (KeyCode.S)) {
                //spriteRenderer.sprite = sprites[2];
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (Time.deltaTime * velocidade));
			}
			if(Input.GetKey(KeyCode.A)){
                //spriteRenderer.sprite = sprites[3];
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * velocidade), gameObject.transform.position.y);
			}
			if(Input.GetKey(KeyCode.D)){
                //spriteRenderer.sprite = sprites[1];
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * velocidade), gameObject.transform.position.y);
			}
		}

		switch(IDArma){
			case 0: // Atirar...
				if(count > cadencia){ // Cadência de tiros;
					this.Atirar();
					count = 0;
				}
				break;
			case 1: // Derrubar com escudo...
				// Escudo; Trocar para sprite com escudo;
				break;
			default:
				Debug.Log ("ERRO: Não pegou arma nenhuma!");
				break; // Just needed by Unity! kkkkk;
		}
		count += Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "enemy"){
            if(this.IDArma == 1){
                Destroy(collision.gameObject); // Destrói inimigo que avança;
                DerrotouInimigo();//this.pontos++;
            }
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(Screen.width/2 - ((Screen.width/2)/2), Screen.height*0.05f, Screen.width/2, Screen.height*0.2f), "Manifestantes detidos:"+pontos);
    }
}
