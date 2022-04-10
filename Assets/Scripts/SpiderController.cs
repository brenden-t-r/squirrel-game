using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    [HideInInspector] public bool playEnabled;
    [SerializeField] private GameObject spider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private SoundController soundController;
    private const float X_OFFSET_LEFT = -0.28f;
    private const float X_OFFSET_MIDDLE = 0.1f;
    private const float X_OFFSET_RIGHT = 0.69f;
    private const float Y_OFFSET = 3.2f;
    private System.Random rand = new System.Random();
    private float timeBuffer = 0;
    private bool survivedSoundPlayed = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playEnabled) return;
        if (timeBuffer > 5 && !survivedSoundPlayed) {
            survivedSoundPlayed = true;
            soundController.Relief();
        }
        if (timeBuffer < 15) {
            timeBuffer += Time.deltaTime;
        } else {
            SpawnSpider();
            timeBuffer = 0;
            survivedSoundPlayed = false;
        }
    }

    void SpawnSpider() {
        float placement = GetRandomPlacement();
        spider.transform.position = new Vector2(placement, Y_OFFSET);
        rb.velocity = new Vector2(0f, -1 * speed * Time.deltaTime);
        soundController.Spider();
    }

    float GetRandomPlacement() {
        int dir = rand.Next(-1, 2);
        Debug.Log(dir);
        if (dir == -1) return X_OFFSET_LEFT;
        else if (dir == 0) return X_OFFSET_MIDDLE;
        else return X_OFFSET_RIGHT;
    }

    public void Die() {
        playEnabled = false;
    }
}
