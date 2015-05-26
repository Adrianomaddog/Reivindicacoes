using UnityEngine;
using System.Collections;

public class FailTrigger_Fase1 : MonoBehaviour {
    public bool fim = false;

    void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.tag == "enemy"){
            fim = true;
            Time.timeScale = 0.5f; // Metade do tempo normal; Slow time;
        }
    }

    // Remover posteriormente:
    void OnGUI(){
        if(fim){
            float posY = Screen.height / 2 - ((Screen.height/2) / 2);
            GUI.Label(new Rect(Screen.width / 2 - ((Screen.width / 2) / 2), posY, Screen.width / 2, Screen.height / 2), "Será que você policial está correto atacando as pessoas assim?"); //Rect(posX - altura/2, posY - largura/2, largura, altura);
            // Buttons:
            posY += 50;
            if (GUI.Button(new Rect(Screen.width / 2 - ((Screen.width / 2) / 2), posY, Screen.width / 2, Screen.height*0.05f), "Recomeçar")){
                Time.timeScale = 1.0f; // Retorna ao normal;
                Application.LoadLevel(Application.loadedLevel); // Recarrega nível/fase;
            }
        }
    }
}
