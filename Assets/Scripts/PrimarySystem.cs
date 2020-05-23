using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrimarySystem : MonoBehaviour
{
    public GameObject canvasImage;
    public Text scoreText;
    public float deathTimer;
    public int scoreNumber;
    void Awake()
    {
        Cursor.visible = false;
        canvasImage.SetActive(false);
    }

    private void FixedUpdate()
    {
        scoreText.text = "Score: " + scoreNumber.ToString();
    }

    public void GameOver()
    {
        canvasImage.SetActive(true);
        StartCoroutine(GameOverTimer());
    }

    IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(deathTimer);
        // chance scene
        SceneManager.LoadScene("TopeiraScene");
    }
}
