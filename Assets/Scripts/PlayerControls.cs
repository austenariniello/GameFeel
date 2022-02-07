using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Vector2 speed;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Jump");
        
        /*
        if (grounded) {
            inputY = ;
        }
        else {
            inputY = 0;
        } */
        
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    /*
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = true;
        }
        else {
            grounded = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }
    */

    
}
