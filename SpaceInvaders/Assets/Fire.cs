using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public float speed;
    public GameObject gm;
    GameManager gmManager;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager");
        gmManager = gm.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position += Vector3.up * speed;

        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            gmManager.pScore += 10;
            Destroy(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }

}
