using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Vector2 speed;
    private bool grounded;
    private Rigidbody2D body;

    //Dust Particle Effects
    public ParticleSystem dustTrail;
    public ParticleSystem dustCloud;

    public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        
        if ((grounded) && (inputX != 0)) {
            MakeDustTrail();
        }
        
        if ((grounded) && (Input.GetButtonDown("Jump"))) {
            body.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);
            
        }
        
        Vector3 movement = new Vector3(speed.x * inputX, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = true;
            MakeDustCloud();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }

    private void MakeDustTrail() {
        dustTrail.Play();
    }
    
    private void MakeDustCloud() {
        dustCloud.Play();
    }
    
}
