using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class LapManager : MonoBehaviour
{
    public GameObject YouWinPanel;
    public AudioSource winAudio;
    public TMP_Text lapCountText;
    public int totalLaps = 3;
    private int currentLap = 0;

    void Start()
    {
        Debug.Log("LapManager started");

        // Initialize lap text
        if (lapCountText != null)
        {
            lapCountText.text = "Lap: " + currentLap.ToString() + "/" + totalLaps.ToString();
            Debug.Log("Lap text initialized: " + lapCountText.text);
        }
        else
        {
            Debug.LogError("Lap Count Text is not assigned!");
        }

        // Make sure win panel is inactive at start
        if (YouWinPanel != null)
        {
            YouWinPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Win Panel not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name + " with tag: " + other.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected! Incrementing lap...");
            currentLap++;

            if (lapCountText != null)
            {
                lapCountText.text = "Lap: " + currentLap.ToString() + "/" + totalLaps.ToString();
                Debug.Log("Updated lap text: " + lapCountText.text);
            }

            if (currentLap >= totalLaps)
            {
                Debug.Log("Race completed! Activating win panel.");
                if (YouWinPanel != null)
                {
                    YouWinPanel.SetActive(true);
                }


                if (winAudio != null)
                {
                    winAudio.Play();
                }

                Time.timeScale = 0f;
            }
        }
    }
}