using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBullet : MonoBehaviour {

    public float speed;
    public GameObject gm;
    GameManager gmManager;
    public GameObject player;

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager");
        gmManager = gm.GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.down * speed;
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(other.gameObject);
            gmManager.pLives -= 1;
            Instantiate(player, new Vector3(0, -4.5f, 0), new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
            
        }
        else if(other.tag != "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }


    }
}
