using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 100;
    public float rightPos = 6.0f;
    public float leftPos = -6.0f;
    public float speed = 0.04f;
    private bool moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
        StartCoroutine(Move());

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= rightPos) {
            moveLeft = true;
        }

        if (transform.position.x <= leftPos) {
            moveLeft = false;
        }
    }

    private IEnumerator Move(){
        while(true) {
            if(moveLeft) {
                transform.Translate(-1*speed, 0, 0);
            }
            else {
                transform.Translate(speed, 0, 0);
            }
            yield return null;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}
