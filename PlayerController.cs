using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    // sound to play when a coin is collected.
    public AudioSource coinPickupSound;
    public AudioSource youDiedSound;

    private int score;
    private bool isAlive = true;

    private Rigidbody rb;
    public float speed = 10.0f; // 10.0 => double point

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        UpdateScore();
        isAlive = true;
    }

    // FixedUpdate is for applying physics
    void FixedUpdate()
    {
        if (isAlive)
        {
            // calc force in x
            float moveHorizontal = Input.GetAxis("Horizontal");
            // calc force in z
            float moveVertical = Input.GetAxis("Vertical");
            // put those together
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            // apply to player
            rb.AddForce(movement * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if you collided with a "Collectible" then eat coin and get points
        if (other.gameObject.CompareTag("Collectible"))
        {
            coinPickupSound.Play();
            other.gameObject.SetActive(false); // eats the coin
            score = score + 20;
            UpdateScore();
        } else
        {
            // if not a coin, we die...
            isAlive = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            youDiedSound.Play();
            StartCoroutine(ReloadScene(1));
            // Destroy(gameObject, 0.3f);

        }
    }

    IEnumerator ReloadScene(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Scene 2");
    }

    void UpdateScore()
    {
        scoreText.text = "Score :" + score;
    }
}
