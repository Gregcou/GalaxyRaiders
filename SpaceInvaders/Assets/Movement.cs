using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public GameObject bullet;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    public float maxBound, minBound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {


        float moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        if (transform.position.x < minBound && moveHorizontal < 0)
        {
            moveHorizontal = 0;
        }
        else if (transform.position.x > maxBound && moveHorizontal > 0)
        {
            moveHorizontal = 0;
        }

        transform.Translate(new Vector2(moveHorizontal, 0f));

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position + new Vector3(0,0.4f,0), shotSpawn.rotation);
        }

        //float h = Input.GetAxis("Horizontald");
        //transform.position += Vector3.right * h * moveSpeed;
    }

    private void FixedUpdate()
    {
        
    }
}
