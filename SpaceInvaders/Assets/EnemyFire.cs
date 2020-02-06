using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

    public GameObject enemyBullet;
    public float fireRate;
    private float nextFire;
    Transform shotSpawn;
    public float fireDelay;
    Animator enemyAnimator;
    public EnemyMovement enemyMoveScript;

    // Use this for initialization
    void Start ()
    {
        shotSpawn = GetComponent<Transform>();
        fireDelay = Random.Range(1f, 20f);

        enemyAnimator = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextFire + fireDelay)
        {
            nextFire = Time.time + fireRate;
            Instantiate(enemyBullet, shotSpawn.position + new Vector3(0, -0.4f, 0), shotSpawn.rotation);
        }

        if (enemyMoveScript.animCounter == 1)
        {
            enemyAnimator.SetBool("JustMoved", true);
        }
        else
        {
            enemyAnimator.SetBool("JustMoved", false);
        }
    }
}
