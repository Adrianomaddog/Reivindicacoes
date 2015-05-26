using UnityEngine;
using System.Collections;

public class GeradorDeInimigos_Fase1 : MonoBehaviour {
    protected float time = 0;
    public float horaDeCriar = 1; // Cria inimigos a cada 1 segundo;
    private float xSorteado;
    public GameObject[] inimigos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(time >= horaDeCriar){
            // Random process:
            // Choose enemy:
            int idInimigo = Random.Range(0, inimigos.Length);
            // Choose position on X (Width) of the screen:
            xSorteado = Random.Range((Screen.width*0.05f), (Screen.width*0.95f)); // O os objetos são posicionados entre 0.05 e 0.95 da tela;
            xSorteado = Camera.main.ScreenToWorldPoint(new Vector3(xSorteado, 0, 0)).x; // Retornando só o X;
            // Instanciando o inimigo:
            Instantiate(inimigos[idInimigo], new Vector3(xSorteado, gameObject.transform.position.y), Quaternion.identity);

            // Reset time:
            time = 0;
        }
        time += Time.deltaTime;
	}
}
