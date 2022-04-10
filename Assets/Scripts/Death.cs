using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    public bool isDead = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Follower deathSpider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die() {
        sr.enabled = true;
        deathSpider.enabled = true;
        scoreText.enabled = true;
        scoreValue.enabled = true;
        isDead = true;
    }
    
    public void Reset() {
        sr.enabled = false;
        isDead = false;
    }
}
