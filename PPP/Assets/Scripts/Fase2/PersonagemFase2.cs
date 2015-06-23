using UnityEngine;
using System.Collections;

public class PersonagemFase2 : MonoBehaviour {
	//Atributos:
	public float velocidade = 5;

    //Extras:
    private int pontos = 0;
    private GerenciadorDeFim gerentefim = null;

	// Use this for initialization
	void Start () {
        do {
            gerentefim = GameObject.Find("GeradorDeFrases").GetComponent<GerenciadorDeFim>();
        } while (gerentefim == null);
	}
    
    public void MarcarPonto(){
        this.pontos++;
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.A)){
            //spriteRenderer.sprite = sprites[3];
			this.gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * velocidade), gameObject.transform.position.y);
		}
        if (Input.GetKey(KeyCode.D)){
            //spriteRenderer.sprite = sprites[1];
			this.gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * velocidade), gameObject.transform.position.y);
		}
        // Touch:
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).position.x < Screen.width / 2){
                //spriteRenderer.sprite = sprites[3];
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * velocidade), gameObject.transform.position.y);
			}
            if(Input.GetTouch(0).position.x > Screen.width / 2){
                //spriteRenderer.sprite = sprites[1];
				this.gameObject.transform.position = new Vector3(gameObject.transform.position.x + (Time.deltaTime * velocidade), gameObject.transform.position.y);
			}
        }
	}

    void OnCollisionEnter2D(Collision2D collision){
        gerentefim.fim = true; // Morreu;
        //if(collision.gameObject.tag == "enemy"){
            //Destroy(collision.gameObject); // Destrói inimigo que avança;
            //DerrotouInimigo();//this.pontos++;
        //}
    }

    void OnGUI(){
        if(!gerentefim.fim) // Se for falso;
            GUI.Label(new Rect(Screen.width/2 - ((Screen.width/2)/2), Screen.height*0.05f, Screen.width/2, Screen.height*0.2f), "Escapou de ser pego:"+pontos+" vezes.");
    }
}
