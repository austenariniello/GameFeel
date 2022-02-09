using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    // Toggles
    public Toggle DustToggle;
    public Toggle SFXToggle;
    public Toggle ShakeToggle;

    public Vector2 speed;
    private bool grounded;
    private bool facingRight;
    private Rigidbody2D body;

    //Dust Particle Effects
    public ParticleSystem dustTrail;
    public ParticleSystem dustCloud;

    // Camera Shake
    public GameObject myCamera;
    public CameraShake cameraShake;

    public AudioSource jumpSFX;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        facingRight = true;
        cameraShake = myCamera.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        
        if ((grounded) && (inputX != 0) && (DustToggle.isOn)) {
            MakeDustTrail();
        }
        
        if ((grounded) && (Input.GetButtonDown("Jump"))) {
            body.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);

            if (SFXToggle.isOn)
                jumpSFX.Play();
        }

        HandleMovement();
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = true;

            if(DustToggle.isOn)
                MakeDustCloud();
        }

        if(other.gameObject.CompareTag("Enemy")) {
            if(ShakeToggle.isOn)
            {
                StartCoroutine(cameraShake.Shake(.15f, .4f));
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (facingRight)
                Flip();

            body.velocity = new Vector2(-speed.x, body.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!facingRight)
                Flip();
            body.velocity = new Vector2(speed.x, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }

    private void MakeDustTrail() {
        dustTrail.Play();
    }
    
    private void MakeDustCloud() {
        dustCloud.Play();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
