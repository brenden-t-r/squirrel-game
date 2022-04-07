using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTreeTexture : MonoBehaviour
{
    [HideInInspector] public bool playEnabled;
    public float speed;
    [SerializeField] private Renderer r;
    private float startTime;
    private float startSpeed;

    private Vector2 offsetBuffer;

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = speed;
        offsetBuffer = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playEnabled) return;
        if (startTime == 0f) {
            startTime = Time.time;
        }
        float timeSinceStart = Time.time - startTime;
        r.material.mainTextureOffset = offsetBuffer + new Vector2(0f, timeSinceStart * speed);
    }

    public void SpeedUp() {
        startTime = Time.time;
        offsetBuffer = r.material.mainTextureOffset;
        speed += 0.05f;
    }

    public void Die() {
        playEnabled = false;
        speed = startSpeed;
        startTime = 0f;
        r.material.mainTextureOffset = new Vector2(0f, 0f);
    }
}
