using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float score;
    public float maxScore;
    public bool isDead;
    public GameObject smokePrefab;
    

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
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
        smokePrefab = Resources.Load<GameObject>("FlappyBird/Prefab/smoke");
        saveManager.Instance.Load();
    }

    public void addScore()
    {
        score++;
        UIManager.Instance.addScoreUI();
    }

    public void dead(Transform bird)
    {
        isDead = true;
        GameObject.Instantiate(smokePrefab,bird.position,Quaternion.identity);
        if (score > maxScore)
        {
            maxScore = score;
            saveManager.Instance.save();
            saveManager.Instance.Load();
           
        }
           
        UIManager.Instance.gameOverUI();

    }


}
