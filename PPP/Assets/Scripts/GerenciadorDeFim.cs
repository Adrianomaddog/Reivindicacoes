using UnityEngine;
using System.Collections;

public class GerenciadorDeFim : MonoBehaviour {
    // Atributos:
    public bool fim = false;
    protected GeradorDeFrases geradorFrases = null;
    protected string _frase = null; // Frase a ser desenhada;
    public string linkDoProtesto; // URL do protesto;

    // Protestos:
    // https://pt.wikipedia.org/wiki/Protestos_no_Brasil_em_2013

	// Use this for initialization
	void Start () {
        do{
	        geradorFrases = GameObject.Find("GeradorDeFrases").GetComponent<GeradorDeFrases>();
            if(geradorFrases == null)
                Debug.LogError("Add GeradorDeFrases...");
        } while (this.geradorFrases == null);
	}

    public string frase()
    {
        //frase = new string();
        if (_frase == null)
            _frase = ((GeradorDeFrases)this.geradorFrases).pegarFrase(); // Pega uma frase randômica;
        return _frase;
    }

    // Deve ser sobrescrita na classe filha:
    public void logicaDeFim(){
        //Debug.Log("Add a lógica aqui pra testar quando mostra a frase. Padronizar ao toque");
    }

    public void logica()
    {
        float w = Screen.width * .8f;
        float h = Screen.height * .75f;
        // Ponto superior esquerdo:
        float posX = Screen.width * .02f;
        float posY = Screen.height * .02f;

        GUI.Box(new Rect(posX * 0.5f, posY * 0.5f, w + (w * 0.05f), h + (h * 0.05f)), "");
        GUI.Label(new Rect(posX, posY, w, h), frase()); //Rect(posX - altura/2, posY - largura/2, largura, altura);

        // Set values to the next GUI objects:
        w = Screen.width / 2;
        h = Screen.height / 2;
        // Ponto central:
        posX = Screen.width / 2 - (w / 2);
        posY = Screen.height / 2 - (h / 2);

        // Link:
        posY = Screen.height * 0.85f;
        if (GUI.Button(new Rect(posX, posY, w, Screen.height * 0.05f), "+ Informações +"))
        {
            Application.OpenURL(@linkDoProtesto);
        }
        // Buttons:
        posY = Screen.height * 0.95f;
        if (GUI.Button(new Rect(posX, posY, w, Screen.height * 0.05f), "Recomeçar"))
        {
            Time.timeScale = 1.0f; // Retorna ao normal;
            GameObject.Find("Audio Source").GetComponent<AudioSource>().pitch = 1.0f;
            fim = false;
            Application.LoadLevel(Application.loadedLevel); // Recarrega nível/fase;
        }
        else
        {
            Time.timeScale = 0.5f;
            GameObject.Find("Audio Source").GetComponent<AudioSource>().pitch = 0.5f;
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