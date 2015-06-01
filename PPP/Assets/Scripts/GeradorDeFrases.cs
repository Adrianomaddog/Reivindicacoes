using UnityEngine;
using System.Collections;
using MadSet;

public class GeradorDeFrases : MonoBehaviour {
    protected RandomPhrase _frases = new RandomPhrase(); // Data base;
    public string[] frases = null;

	// Use this for initialization
	void Start () {
        //this._frases.addPhrase("Será que você policial está correto atacando as pessoas assim?");
        //this._frases.addPhrase("Será que os protestantes estão corretos em tentar atacar o parlamento?");
        if(frases != null)
            for(int i = 0; i < frases.Length; i++)
            {
                this._frases.addPhrase(frases[i]);
            }
	}

    public string pegarFrase(){
        return this._frases.getOne();
    }
	
    //// Update is called once per frame
    //void Update () {
    //    //Debug.Log(this.frases.getOne());
    //}
}
