using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this

public class LapManager : MonoBehaviour
{
    public GameObject YouWinPanel;
    public AudioSource winAudio;
    public TMP_Text lapCountText; // Change from Text to TMP_Text
    public int totalLaps = 3;
    private int currentLap = 0;

    void Start()
    {
        // Initialize lap text
        if (lapCountText != null)
        {
            lapCountText.text = "Lap: " + currentLap.ToString() + "/" + totalLaps.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentLap++;
            if (lapCountText != null)
            {
                lapCountText.text = "Lap: " + currentLap.ToString() + "/" + totalLaps.ToString();
            }

            if (currentLap >= totalLaps)
            {
                YouWinPanel.SetActive(true);
                winAudio.Play();
                Time.timeScale = 0f;
            }
        }
    }
}