using UnityEngine;
using System.Collections;

public class Thrower : MonoBehaviour {

    // Atributos:
    public GameObject[] prefabs = new GameObject[2];
    //public Vector2 releasePoint = new Vector2(3456789.0f, 9876543.0f);
    //public float fx = 400.0f, fy = 400.0f;
    
    // Método 2 de uso...
    protected Vector2 releasePoint1, releasePoint2;
    protected Vector2 forca1 = new Vector2(400.0f, 400.0f), forca2 = new Vector2(-400.0f, 400.0f);
    //protected int platformID = 0; // ID da plataforma que está rodando o jogo;

	// Use this for initialization
	void Start () {
        // Touch:
        Input.multiTouchEnabled = true;
        // Se for Android:
        if (Application.platform == RuntimePlatform.Android)
        {
            //this.platformID = 1;
        }

        if (prefabs.Length < 2) {
            Debug.LogError("There is no GameObject attached to 'prefabs' or there are less than two, please add at least two objects to throw!");
        }

        // Encontra objetos filhos para gerar os pontos de lançamento:
        if (this.gameObject.transform.childCount >= 2)
        {
            // Ponto de lançamento esquerdo:
            releasePoint1 = this.gameObject.transform.GetChild(0).transform.position;
            // Ponto de lançamento direito:
            releasePoint2 = this.gameObject.transform.GetChild(1).transform.position;
        }
        else {
            Debug.LogError("You need at least two GameObjects attached as children to this GameObject in order to this shit works!");
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        // Randomizar forças aplicadas:
        //forca1.x = Random.RandomRange(100, 800);
        //forca1.y = Random.RandomRange(100, 800);

        //forca2.x = Random.RandomRange(-100, -800);
        //forca2.y = Random.RandomRange(100, 800);

//// PC:
        if(Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x <= Screen.width / 2) // Atira da esquerda;
            {
                Rigidbody2D body = ((GameObject)Instantiate(prefabs[0], releasePoint1, Quaternion.identity)).gameObject.GetComponent<Rigidbody2D>();

                // Aplicando forças:
                body.AddForce(forca1);
                body.AddTorque(100f);
            }
            else // Atira da direita;
            {
                Rigidbody2D body = ((GameObject)Instantiate(prefabs[1], releasePoint2, Quaternion.identity)).gameObject.GetComponent<Rigidbody2D>();

                // Aplicando forças:
                body.AddForce(forca2);
                body.AddTorque(-100f);
            }
        }

        // ou
///// TOUCH:
        if (Input.touchCount > 0)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began) // Se iniciou;
                {
                    if (Input.GetTouch(i).position.x <= Screen.width / 2) // Atira da esquerda;
                    {
                        Rigidbody2D body = ((GameObject)Instantiate(prefabs[0], releasePoint1, Quaternion.identity)).gameObject.GetComponent<Rigidbody2D>();

                        // Aplicando forças:
                        body.AddForce(forca1);
                        body.AddTorque(100f);
                    }
                    else // Atira da direita;
                    {
                        Rigidbody2D body = ((GameObject)Instantiate(prefabs[1], releasePoint2, Quaternion.identity)).gameObject.GetComponent<Rigidbody2D>();

                        // Aplicando forças:
                        body.AddForce(forca2);
                        body.AddTorque(-100f);
                    }
                }

                i++;
            }
        }
    }
}
