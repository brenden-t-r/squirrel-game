using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceMeter : MonoBehaviour
{
    public bool playEnabled;   
    public float speed;
    public float turbulenceSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer squirrelRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;

    [SerializeField] private Animator squirrelAnimator;
    [SerializeField] private Death death;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;
    [SerializeField] private Sprite sprite5;
    private Vector2 startPosition;
    private float startSpeed;
    private float startTurbulenceSpeed;
    private float turbulenceResetTime = 0f;

    private float noiseResetTime = 0f;
    public float noiseSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        startPosition = rb.position;
        startSpeed = speed;
        startTurbulenceSpeed = turbulenceSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate() {
        if (!playEnabled) return;
        float moveHorizontal = Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (moveHorizontal, 0f);
        rb.AddForce (movement * speed); 

        if (turbulenceResetTime > 0.5) {
            int sign = System.Math.Sign(Random.Range(-1, 1));
            Vector2 turbulence = new Vector2(sign * turbulenceSpeed, 0f);
            // rb.velocity = rb.velocity + turbulence;
            rb.AddForce(turbulence, ForceMode2D.Force);
            turbulenceResetTime = 0;
        }
        turbulenceResetTime += Time.deltaTime;

        if (noiseResetTime > 0.15) {
            float noise = Random.Range(-1 * noiseSpeed, noiseSpeed);
            rb.velocity = rb.velocity + new Vector2(noise , 0f);
            noiseResetTime = 0;
        }
        noiseResetTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("MeterEnd")) {
            // death.Die();
        }
    }

/*
middle
-0.1495346, 0.8588654
size: 0.2211256, 0.4128363

left2
-0.3986315, 0.7209724, 0.2922962, 0.2615988

right1
0.2196624, 0.8988988, 0.2656075, 0.2971841

right2
0.4198296, 0.7209724, 0.2922964, 0.2615988
*/
    private void OnTriggerExit2D(Collider2D other) {
        if (!playEnabled) return;
        if (other.CompareTag("MeterL3")) {}
        if (other.CompareTag("MeterL2")) {
            if (rb.velocity.x < 0) {
                squirrelAnimator.SetInteger("MeterState", 1);
                setCollider(-0.3986315f, 0.7209724f, 0.2922962f, 0.2615988f);
                // squirrelRenderer.sprite = sprite1;
            } else {
                squirrelAnimator.SetInteger("MeterState", 2);
                setCollider(-0.1495346f, 0.8588654f,  0.2211256f, 0.4128363f);
                // squirrelRenderer.sprite = sprite2;
            }
        }
        if (other.CompareTag("MeterL1")) {
            if (rb.velocity.x < 0) {
                squirrelAnimator.SetInteger("MeterState", 2);
                setCollider(-0.1495346f, 0.8588654f,  0.2211256f, 0.4128363f);
                // squirrelRenderer.sprite = sprite2;
            } else {
                squirrelAnimator.SetInteger("MeterState", 3);
                setCollider(-0.1495346f, 0.8588654f,  0.2211256f, 0.4128363f);
                // squirrelRenderer.sprite = sprite3;
            }
        }
        if (other.CompareTag("MeterR1")) {
             if (rb.velocity.x > 0) {
                 squirrelAnimator.SetInteger("MeterState", 4);
                // squirrelRenderer.sprite = sprite4;
                setCollider(0.2196624f, 0.8988988f, 0.2656075f, 0.2971841f);
            } else {
                squirrelAnimator.SetInteger("MeterState", 3);
                // squirrelRenderer.sprite = sprite3;
                setCollider(-0.1495346f, 0.8588654f,  0.2211256f, 0.4128363f);
            }
        }
        if (other.CompareTag("MeterR2")) {
            if (rb.velocity.x > 0) {
                squirrelAnimator.SetInteger("MeterState", 5);
                setCollider(0.4198296f, 0.7209724f, 0.2922964f, 0.2615988f);
                // squirrelRenderer.sprite = sprite5;
            } else {
                squirrelAnimator.SetInteger("MeterState", 4);
                // squirrelRenderer.sprite = sprite4;
                setCollider(0.2196624f, 0.8988988f, 0.2656075f, 0.2971841f);
            }
        }
        if (other.CompareTag("MeterR3")) {}
    }

    public void Die() {
        playEnabled = false;
        rb.velocity = new Vector2(0, 0);
        rb.position = startPosition;
        speed = startSpeed;
        turbulenceSpeed = startTurbulenceSpeed;
        squirrelRenderer.sprite = sprite3;
    }

    private void setCollider(float offsetX, float offsetY, float sizeX, float sizeY) {
        boxCollider2D.offset = new Vector2(offsetX, offsetY);
        boxCollider2D.size = new Vector2(sizeX, sizeY);
    }
}
