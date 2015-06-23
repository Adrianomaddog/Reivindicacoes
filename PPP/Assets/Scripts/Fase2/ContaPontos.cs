using UnityEngine;
using System.Collections;

public class ContaPontos : MonoBehaviour {
    PersonagemFase2 p;

	// Use this for initialization
	void Start () {
        p = GameObject.Find("Personagem").GetComponent<PersonagemFase2>();
	}

    void OnTriggerEnter2D(Collider2D c){
        if (c.gameObject.tag == "viatura")
            p.MarcarPonto();
    }
}
