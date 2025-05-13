using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public TMP_Text speedText; // Use TMP_Text since your project is using TextMeshPro
    public Rigidbody carRigidbody;
    public float speedMultiplier = 3.6f; // For km/h

    // You can reference the car via code (instead of drag-and-drop)
    void Start()
    {
        // Find the car if not already assigned
        if (carRigidbody == null)
        {
            // Try to find car by tag
            GameObject playerCar = GameObject.FindGameObjectWithTag("Player");
            if (playerCar != null)
            {
                carRigidbody = playerCar.GetComponent<Rigidbody>();
            }
        }
    }

    void Update()
    {
        if (carRigidbody != null && speedText != null)
        {
            float speed = carRigidbody.velocity.magnitude * speedMultiplier;
            speedText.text = "Speed: " + Mathf.RoundToInt(speed) + " km/h";
        }
    }
}