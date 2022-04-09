using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{

   [SerializeField] private Death death;
   [SerializeField] private Score score;
   [SerializeField] private AcornController acorn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        if (other.CompareTag("Spider")) {
            death.Die();
        }
        if (other.CompareTag("Acorn")) {
            // play sound
            score.acornsCollected += 1;
            acorn.Eat();
        }
    }
}
