using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public bool playEnabled;
    [SerializeField] private GameObject go;
    private TextMeshProUGUI textMeshPro;
    private float startTime = 0f;

    [SerializeField] private TextMeshProUGUI textMeshScoreDeath;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = go.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playEnabled) return;
        if (startTime == 0f) {
            startTime = Time.time;
        }
        float timeSinceStart = Time.time - startTime;
        score = (int)System.Math.Floor(timeSinceStart);
        textMeshPro.SetText(score.ToString());
    }

    public void Die() {
        playEnabled = false;
        textMeshScoreDeath.SetText(score.ToString());
        score = 0;
        startTime = 0f;
    }
}
