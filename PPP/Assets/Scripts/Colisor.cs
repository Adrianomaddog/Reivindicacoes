using UnityEngine;
using System.Collections;

public class Colisor : MonoBehaviour {
    public string tagDoObjetoQueDeveMeAcertar = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == this.tagDoObjetoQueDeveMeAcertar){
            GameObject.Find("GeradorDeFrases").GetComponent<GerenciadorDeFim>().fim = true;
        }
    }
}
