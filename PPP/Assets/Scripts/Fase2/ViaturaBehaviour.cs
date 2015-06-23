using UnityEngine;
using System.Collections;

public class ViaturaBehaviour : MonoBehaviour {
    public float vel = 5; // Velocidade;
    public float s = 1; // Escala;
    //protected Sprite sprite;

	// Use this for initialization
	void Start () {
        //sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
        // Atualiza:
        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (vel * Time.deltaTime));
        s += (vel * 0.2f) * Time.deltaTime;
        this.gameObject.transform.localScale = new Vector3(s,s,1);
	}
}
