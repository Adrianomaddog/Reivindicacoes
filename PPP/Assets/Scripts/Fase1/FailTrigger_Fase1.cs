using UnityEngine;
using System.Collections;
//using MadSet;

public class FailTrigger_Fase1 : FailTrigger {
    //public bool fim = false;
    ////protected RandomPhrase frases;
    //protected GeradorDeFrases geradorFrases = null;
    //protected string _frase = null; // Frase a ser desenhada;

    void Start(){
        base.Start();
        //do{
        //    this.geradorFrases = this.gameObject.GetComponent<GeradorDeFrases>();
        //} while(this.geradorFrases == null);
    }

    void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.tag == "enemy"){
            fim = true;
            Time.timeScale = 0.5f; // Metade do tempo normal; Slow time;
        }
    }

    //string frase(){
    //    //frase = new string();
    //    if(_frase == null)
    //        _frase = ((GeradorDeFrases)this.geradorFrases).pegarFrase(); // Pega uma frase randômica;
    //    return _frase;
    //}

    //// Remover posteriormente:
    //void OnGUI(){
    //    if(fim){
    //        float posY = Screen.height / 2 - ((Screen.height/2) / 2);
    //        GUI.Label(new Rect(Screen.width / 2 - ((Screen.width / 2) / 2), posY, Screen.width / 2, Screen.height / 2), frase()); //Rect(posX - altura/2, posY - largura/2, largura, altura);
    //        // Buttons:
    //        posY += 50;
    //        if (GUI.Button(new Rect(Screen.width / 2 - ((Screen.width / 2) / 2), posY, Screen.width / 2, Screen.height*0.05f), "Recomeçar")){
    //            Time.timeScale = 1.0f; // Retorna ao normal;
    //            Application.LoadLevel(Application.loadedLevel); // Recarrega nível/fase;
    //        }
    //    } else{
    //        if(_frase != null)
    //            _frase = null;
    //    }
    //}
}
