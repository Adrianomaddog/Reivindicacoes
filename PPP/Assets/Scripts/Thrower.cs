using UnityEngine;
using System.Collections;

public class Thrower : MonoBehaviour {

    // Atributos:
    public GameObject[] prefabs;
    public Vector2 releasePoint;
    public float fx = 400.0f, fy = 400.0f;

	// Use this for initialization
	void Start () {
        this.releasePoint = this.gameObject.transform.position; // Default é o centro;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Rigidbody2D body = ((GameObject)Instantiate(prefabs[0], releasePoint, Quaternion.identity)).gameObject.GetComponent<Rigidbody2D>();
            //Rigidbody2D body = o.gameObject.GetComponent<Rigidbody2D>();

            // Aplicando forças:
            body.AddForce(new Vector2(fx, fy));
            body.AddTorque(100f);
        }	
	}
}
