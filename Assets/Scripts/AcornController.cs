using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour
{

    [HideInInspector] public bool playEnabled;
    [SerializeField] private GameObject acorn;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;
    [SerializeField] private SoundController soundController;
    private const float X_OFFSET_LEFT = -0.3f;
    private const float X_OFFSET_MIDDLE = 0f;
    private const float X_OFFSET_RIGHT = 0.597f;
    private const float Y_OFFSET = 2.6f;
    private System.Random rand = new System.Random();
    private float timeBuffer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playEnabled) return;
        if (timeBuffer < 12) {
            timeBuffer += Time.deltaTime;
        } else {
            Spawn();
            timeBuffer = 0;
        }

    }

    void Spawn() {
        float placement = GetRandomPlacement();
        acorn.transform.position = new Vector2(placement, Y_OFFSET);
        spriteRenderer.enabled = true;
        rb.velocity = new Vector2(0f, -1 * speed * Time.deltaTime);
        soundController.Acorn();
    }

    float GetRandomPlacement() {
        int dir = rand.Next(-1, 2);
        if (dir == -1) return X_OFFSET_LEFT;
        else if (dir == 0) return X_OFFSET_MIDDLE;
        else return X_OFFSET_RIGHT;
    }

    public void Eat() {
        soundController.Eat();
        spriteRenderer.enabled = false;
    }

    public void Die() {
        playEnabled = false;
    }
}
