using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapAndSpeedManager : MonoBehaviour
{
    public GameObject YouWinPanel;
    public AudioSource winAudio;

    // Support both Text types
    public Text regularLapText;
    public TMP_Text tmpLapText;

    public Text regularSpeedText;
    public TMP_Text tmpSpeedText;

    public int totalLaps = 3;
    private int currentLap = 0;

    private Rigidbody playerRigidbody;
    public float speedMultiplier = 3.6f; // For km/h

    void Start()
    {
        // Initialize lap text
        UpdateLapText();

        // Find the player car
        GameObject playerCar = GameObject.FindGameObjectWithTag("Player");
        if (playerCar != null)
        {
            playerRigidbody = playerCar.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (playerRigidbody != null)
        {
            UpdateSpeedText(playerRigidbody.velocity.magnitude * speedMultiplier);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentLap++;
            UpdateLapText();

            if (currentLap >= totalLaps)
            {
                YouWinPanel.SetActive(true);
                if (winAudio != null)
                    winAudio.Play();
                Time.timeScale = 0f;
            }
        }
    }

    private void UpdateLapText()
    {
        string lapString = "Lap: " + currentLap.ToString() + "/" + totalLaps.ToString();

        if (regularLapText != null)
            regularLapText.text = lapString;

        if (tmpLapText != null)
            tmpLapText.text = lapString;
    }

    private void UpdateSpeedText(float speed)
    {
        string speedString = "Speed: " + Mathf.RoundToInt(speed) + " km/h";

        if (regularSpeedText != null)
            regularSpeedText.text = speedString;

        if (tmpSpeedText != null)
            tmpSpeedText.text = speedString;
    }
}