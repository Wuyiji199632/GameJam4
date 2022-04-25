using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // We need to counter the score for game manager
    public int score;
    public int HighestScore;
    public Text ScoreText;
    public Text HighScoreText;
    public Text TimerText;
    public GameObject GameOverPanel;
    public GameObject VictoryPanel;
    public AudioClip[] SliceSounds;
    private AudioSource AudioSource;
    public bool IsSlicingFruit = false;
    public float TimeDuringNotSlicingFruits;
    public float TimeDuringResetting;
    public bool Reset = false;
    void Start()
    {
        GameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        HighestScore = PlayerPrefs.GetInt("HighestScore");
        HighScoreText.text = "Highest Score: " + HighestScore;
        AudioSource = GetComponent<AudioSource>();
        TimerText.text = "Time Before Fail: "+ TimeDuringNotSlicingFruits.ToString();
    }
     void Update()
     {
        //CheckSlicingFruits();
        TimingOfWinOrLoss();
     }
    public void IncreaseScore(int points)
    {
        score += points;
        ScoreText.text = score.ToString();
        if(score>=HighestScore)
        {
            PlayerPrefs.SetInt("HighestScore", score);
            HighScoreText.text = score.ToString();
        }
        
        
    }
    public void OnBombHit()
    {
        Time.timeScale = 0;
        Debug.Log("I hit the bomb!");
        GameOverPanel.SetActive(true);
        VictoryPanel.SetActive(false);
    }
    public void Victory()
    {
        Time.timeScale = 0;
        Debug.Log($"I hit the victory!");
        VictoryPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }
    public void PlayRandomSound()
    {
        AudioClip Sounds = SliceSounds[Random.Range(0, SliceSounds.Length)];
        AudioSource.PlayOneShot(Sounds);
    }
    //public void CheckSlicingFruits()
    //{
    //    if (!IsSlicingFruit)
    //    {
    //        TimeDuringNotSlicingFruits -= Time.deltaTime;
    //        TimerText.text = "Time Before Fail: " + TimeDuringNotSlicingFruits.ToString();
    //        if (TimeDuringNotSlicingFruits <= 0)
    //        {
    //            OnBombHit();
    //        }
    //    }
    //    else
    //    {
    //        TimeDuringNotSlicingFruits = 20f;
    //        IsSlicingFruit = true;
    //        if (IsSlicingFruit)
    //        {
    //            TimeDuringResetting -= Time.deltaTime;
    //            if (TimeDuringResetting <= 0)
    //            {
    //                TimeDuringResetting = 0;
    //                IsSlicingFruit = false;
    //                Reset = true;
    //            }
    //            if (Reset)
    //            {
    //                TimeDuringResetting = 1f;
    //                TimeDuringResetting -= Time.deltaTime;
    //                Reset = false;
    //            }
    //        }
    //    }

    //}
    public void TimingOfWinOrLoss()
    {
        TimeDuringNotSlicingFruits -= Time.deltaTime;
        TimerText.text = "Time Before Fail: " + TimeDuringNotSlicingFruits.ToString();
        if (TimeDuringNotSlicingFruits<=0&&score<=30)
        {
            TimeDuringNotSlicingFruits = 0;
            OnBombHit();
        }
        if(score>0)
        {
            TimeDuringNotSlicingFruits = 0;
            Victory();
        }
    }
}
