using UnityEngine;
using System.Collections;

public class TrocaDeTela : MonoBehaviour {
	// Atributos:
	public string nomeDaFase = "[Sem nome]";
	//private string tmpName;

	// Métodos:
	public void Clicked(){
		if(!Application.isLoadingLevel && nomeDaFase != "[Sem nome]"){// && tmpName != nomeDaFase){
			Application.LoadLevel(this.nomeDaFase);
			//tmpName = nomeDaFase;
		} else{
			Debug.LogError("O nome da fase não foi adicionado!");
		}
	}
}
