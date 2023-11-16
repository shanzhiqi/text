using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;


public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance;
    private TMP_Text text;
    private Image[] image;

    private Button retryButton;
    private Button homeButton;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

    }
    private void Start()
    {
        text = FindObjectOfType<TMP_Text>();
        image = FindObjectsOfType<Image>(true);
        homeButton = transform.GetChild(1).GetChild(4).GetComponent<Button>();
        homeButton.onClick.AddListener(home);
        retryButton = transform.GetChild(1).GetChild(3).GetComponent<Button>();
        retryButton.onClick.AddListener(retry);
        
    }

    private void home()
    {
        SceneManager.LoadScene("main");
    }

    private void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void addScoreUI()
    {
        text.text = GameManager.Instance.score.ToString("000");
    }

    public void gameOverUI()
    {
        for (int i = 0; i < image.Length; i++)
        {
            if (image[i].CompareTag("overUI"))
            {
                
                image[i].gameObject.SetActive(true);
                TMP_Text scoreText= image[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
                TMP_Text beatScoreText = image[i].transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
                scoreText.text = GameManager.Instance.score.ToString("000");
                beatScoreText.text = GameManager.Instance.maxScore.ToString("000");
            }
        }
    }
}
