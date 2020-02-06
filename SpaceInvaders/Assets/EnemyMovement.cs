using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {


    public Transform enemyContainer;
    public float speed;
    public int animCounter = 0;



    // Use this for initialization
    void Start ()
    {
        enemyContainer = GetComponent<Transform>();
        InvokeRepeating("enemyMove", 0.1f, 0.3f);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void enemyMove()
    {
        enemyContainer.position += Vector3.right * speed;
        if (animCounter == 0)
        {
            animCounter++;
        }
        else
        {
            animCounter = 0;
        }
        
        int counter = 0;

        foreach (Transform enemy in enemyContainer)
        {
            if (enemy.position.x < -7.5 || enemy.position.x > 7.5)
            {
                if (counter < 1)
                {
                    counter++;
                    speed = -speed;
                    enemyContainer.position += Vector3.down * 0.5f;
                } 
            }

            if (enemy.position.y <= -2)
            {
                SceneManager.LoadScene("EndScreenLost");
            }
        }


        if (enemyContainer.childCount <= 8)
        {
            CancelInvoke();
            InvokeRepeating("enemyMove", 0.1f, 0.25f);
        }

        if (enemyContainer.childCount == 0)
        {
            SceneManager.LoadScene("EndScreenWon");
        }

    }
}
