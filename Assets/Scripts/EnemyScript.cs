using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Toggle flashToggle;
    public int health = 100;
    public float rightPos = 6.0f;
    public float leftPos = -6.0f;
    public float speed = 0.04f;
    private bool moveLeft;
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
        StartCoroutine(Move());
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(collision.gameObject);
        health -= 1;
        //if(flashToggle.isOn)
        //   sr.material = matWhite;
        sr.material = matWhite;
        if (health <= 0)
        {
            // TODO Add particle burst
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        
        }

    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    
    }

    private void SomethingElseOnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health -= 1;
            sr.material = matWhite;
            if (health <= 0)
            {
                // TODO Add particle burst
                Destroy(gameObject);
            }
            
                


        }
    
    }
}
