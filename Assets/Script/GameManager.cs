using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int timeToMenu=9;

    public int missScore;
    public int hitScore;
    public int comboScore;
    public int highestComboScore;
    //public SimpleHelvetica simpleHelveticaMiss;
    //public SimpleHelvetica simpleHelveticaHit;
    public GameObject hit;
    public GameObject miss;
    public GameObject combo;
    public GameObject time;
    public GameObject spawner;

    public TextMeshPro hitTMP;
    public TextMeshPro missTMP;
    public TextMeshPro comboTMP;

    public float timeLeft = 148.0f;
    public TextMeshPro timeTMP; // used for showing countdown from 3, 2, 1 

    public AudioSource winSound;

    bool playOnce = true;


    // Start is called before the first frame update
    void Start()
    {
        missScore = 0;
        hitScore = 0;
        comboScore = 0;
        highestComboScore = 0;

        hit = GameObject.Find("Hit(TMP)");
        miss = GameObject.Find("Miss(TMP)");
        combo = GameObject.Find("Combo(TMP)");
        time = GameObject.Find("Time(TMP)");
        spawner = GameObject.Find("Spawner");



        //simpleHelveticaHit = hit.GetComponent<SimpleHelvetica>();
        //simpleHelveticaMiss = miss.GetComponent<SimpleHelvetica>();
        hitTMP = hit.GetComponent<TextMeshPro>();
        missTMP = miss.GetComponent<TextMeshPro>();
        comboTMP = combo.GetComponent<TextMeshPro>();
        timeTMP = time.GetComponent<TextMeshPro>();

        winSound = GameObject.Find("AudioSourceWinSound").GetComponent<AudioSource>();

        timeTMP.GetComponent<MeshRenderer>().enabled = false;
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        //timeTMP.SetText(timeLeft.ToString("0"));
        if (timeLeft < 0)
        {

            if (playOnce) {
                timeTMP.GetComponent<MeshRenderer>().enabled = true;
                Debug.Log("hitScore/(hitScore+ missScore)" + (hitScore * 1.0f / (hitScore + missScore)).ToString("2"));
                timeTMP.SetText("Highest Combo: " + highestComboScore + "\n" + "Accuracy: " + (hitScore*100.0f / (hitScore + missScore)).ToString("#.##") + "%");
                winSound.Play();
                spawner.SetActive(false);
                playOnce = false;
            }
            Invoke("menuScene", timeToMenu);
        }
    }

    void menuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void updateMissScore()
    {
        //Debug.Log("score updated!!!!");
        missScore += 1;
        //hitTMP.SetText("10");
        missTMP.SetText(missScore.ToString());

    }

    public void updateHitScore()
    {
        //Debug.Log("score updated!!!!");
        hitScore += 1;
        //hitTMP.SetText("10");
        hitTMP.SetText(hitScore.ToString());

    }

    public void updateComboScore()
    {
        comboScore += 1;
        //Debug.Log("combo score:" + comboScore);
        comboTMP.SetText(comboScore.ToString());

        if (highestComboScore < comboScore)
        {
            //Debug.Log("highest combo score:" + highestComboScore);
            highestComboScore = comboScore;
        }
    }

    public void resetComboScore()
    {
        comboScore = 0;

        comboTMP.SetText(comboScore.ToString());

 
    }
}
