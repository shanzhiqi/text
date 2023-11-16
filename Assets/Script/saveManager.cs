using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveManager : MonoBehaviour
{
    public static saveManager Instance;
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
    

    public void save()
    { 
        
        PlayerPrefs.SetFloat("score", GameManager.Instance.maxScore);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            GameManager.Instance.maxScore = PlayerPrefs.GetFloat("score");
        }
       
       
    }
}
