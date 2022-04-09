using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource currentMusic;
    public AudioSource[] soundsMusic;
    public AudioSource[] soundsEat;
    public AudioSource[] soundsAcorn;
    public AudioSource[] soundsSpider;
    public AudioSource[] soundsUhOh;
    public AudioSource[] soundsRelief;
    public AudioSource soundSpiderChatter;
    private bool isPlayEnabled = true;
    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        GameObject music = GameObject.Find("SoundsMusic");
        soundsMusic = music.GetComponentsInChildren<AudioSource>(false);
        if (soundsMusic.Length > 0) {
            currentMusic = soundsMusic[0];
            currentMusic.loop = true;
            currentMusic.Play();
        }
        soundsEat = GameObject.Find("SoundsEat").GetComponentsInChildren<AudioSource>(false);
        soundsAcorn = GameObject.Find("SoundsAcorn").GetComponentsInChildren<AudioSource>(false);
        soundsSpider = GameObject.Find("SoundsSpider").GetComponentsInChildren<AudioSource>(false);
        soundsUhOh = GameObject.Find("SoundsUhOh").GetComponentsInChildren<AudioSource>(false);
        soundsRelief = GameObject.Find("SoundsRelief").GetComponentsInChildren<AudioSource>(false);
        soundSpiderChatter = GameObject.Find("SoundsSpiderChatter").GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        // currentMusic.Stop();
        currentMusic = soundsMusic[1];
        currentMusic.loop = true;
        currentMusic.Play();
    }

    public void Die() {
        isPlayEnabled = false;
        currentMusic.Stop();
        soundsMusic[2].Play();
    }

    public void Eat() {
        if (!isPlayEnabled) return;
        int index = rand.Next(0, soundsEat.Length);
        soundsEat[index].Play();
    }

    public void Acorn() {
        if (!isPlayEnabled) return;
        int index = rand.Next(0, soundsAcorn.Length);
        soundsAcorn[index].Play();
    }

    public void Spider() {
        if (!isPlayEnabled) return;
        int index = rand.Next(0, soundsSpider.Length);
        soundsSpider[index].Play();
        soundSpiderChatter.Play();
    }

    public void UhOh() {
        if (!isPlayEnabled) return;
        int index = rand.Next(0, soundsUhOh.Length);
        soundsUhOh[index].Play();
    }

    public void Relief() {
        if (!isPlayEnabled) return;
        int index = rand.Next(0, soundsRelief.Length);
        soundsRelief[index].Play();
    }
}
