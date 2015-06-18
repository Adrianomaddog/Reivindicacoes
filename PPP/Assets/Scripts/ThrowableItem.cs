using UnityEngine;
using System.Collections;

public class ThrowableItem : MonoBehaviour {
    // Atributos:
    private float lapse; // Instante de tempo salvo;
    private float counter = 15; // Tempo total vivo;
    //private Rigidbody2D body;
    //private float fX = 400.0f, fY = 400.0f; // Força em X e em Y;
    
    //public float forcaX{
    //    set{
    //        this.fX = value;
    //    }
    //    get{
    //        return this.fX;
    //    }
    //}
    //public float forcaY
    //{
    //    set
    //    {
    //        this.fY = value;
    //    }
    //    get
    //    {
    //        return this.fY;
    //    }
    //}

    // Métodos:
    void Start()
    {
        //// Pegando gameObject:
        //body = this.gameObject.GetComponent<Rigidbody2D>();

        //// Aplicando forças:
        //body.AddForce(new Vector2(fX, fY));
        //body.AddTorque(100f);

        lapse = Time.time;
    }

    void Update(){

        // Auto destruição após tempo X:
        if(Time.time >= lapse + counter){
            Destroy(this.gameObject);
        }
    }
}
