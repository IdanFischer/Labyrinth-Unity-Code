using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    private int score;

    void UpdateScore()
    {
        scoreText.text = "Score :" + score;
    }

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    void OnTriggerEnter(Collider other)
    {
        // if you collided with a "Collectible" then eat coin and get points
        if (other.gameObject.CompareTag("Collectible"))
        {

            other.gameObject.SetActive(false); // eats the coin
            score = score + 20;
            UpdateScore();
        }
        else
        {
            // if not a coin, we die...
            SceneManager.LoadScene("Scene 3");
            // Destroy(gameObject, 0.3f)p
        }
    }
}