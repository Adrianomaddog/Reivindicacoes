using UnityEngine;
using System.Collections;

public class Fim_Fase3 : MonoBehaviour {
    public bool fim = false;
    protected GeradorDeFrases geradorFrases = null;
    protected string _frase = null; // Frase a ser desenhada;

	// Use this for initialization
	void Start () {
        do{
	        geradorFrases = GameObject.Find("GeradorDeFrases").GetComponent<GeradorDeFrases>();
        } while (this.geradorFrases == null);
	}

    public string frase()
    {
        //frase = new string();
        if (_frase == null)
            _frase = ((GeradorDeFrases)this.geradorFrases).pegarFrase(); // Pega uma frase randômica;
        return _frase;
    }

    public void OnCollisionEnter2D(Collision2D c){
        if (c.gameObject.tag == "granada")
            fim = true;
    }

    // Deve ser sobrescrita na classe filha:
    public void logicaDeFim(){
        //Debug.Log("Add a lógica aqui pra testar quando mostra a frase. Padronizar ao toque");
    }

    //public void Update(){
    //    logicaDeFim();
    //}

    public void logica()
    {
        float posY = Screen.height / 2 - ((Screen.height / 2) / 2);
        GUI.Label(new Rect(Screen.width / 2 - ((Screen.width / 2) / 2), posY, Screen.width / 2, Screen.height / 2), frase()); //Rect(posX - altura/2, posY - largura/2, largura, altura);
        // Buttons:
        posY += 50;
        if (GUI.Button(new Rect(Screen.width / 2 - ((Screen.width / 2) / 2), posY, Screen.width / 2, Screen.height * 0.05f), "Recomeçar"))
        {
            Time.timeScale = 1.0f; // Retorna ao normal;
            Application.LoadLevel(Application.loadedLevel); // Recarrega nível/fase;
        }
    }

    // Remover posteriormente:
    public void OnGUI()
    {
        if (fim)
        {
            logica();
        }
        else
        {
            if (_frase != null)
                _frase = null;
        }
    }
}
    //void OnTriggerEnter2D(Collider2D c)
    //{
    //    //if (c.gameObject.tag == "enemy")
    //    //{
    //    //    fim = true;
    //    //    Time.timeScale = 0.5f; // Metade do tempo normal; Slow time;
    //    //}
    //}