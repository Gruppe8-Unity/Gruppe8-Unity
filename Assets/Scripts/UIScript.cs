using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIScript : MonoBehaviour
{
    public Player player;
    private float _scoreCount = 0f;
    private float _experienceCount = 0f;
    private float _requiredExperience= 10f;
    private int _levelCount;
    
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerExperience;
    public TextMeshProUGUI playerCurrentLevel;
    public Image experienceBar;
    public Image healthBar;
    
    private void Start()
    {
        UpdateExperience(0);
    }

    private void Update()
    {
        UpdateHealthBar();
        UpdateScore();
    }
    
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(player.currentPlayerHealth / player.maxPlayerHealth, 0, 1);
    }
   public void UpdateScore()
   {
       _scoreCount += 1.0f * 0.01f; 
        playerScore.text = $"Score: {Mathf.Round(_scoreCount)}"; 
    }
    
    public void UpdateExperience(float amount)
    {
        _experienceCount += amount;
        if (_experienceCount >= _requiredExperience)
        {
            _experienceCount = 0;
            _levelCount++;
            _requiredExperience *= 1.2f;
        }
        
        experienceBar.fillAmount = Mathf.Clamp( _experienceCount / _requiredExperience , 0, _requiredExperience);

        playerExperience.text = $"{Mathf.Round(_experienceCount)} / {Mathf.Round(_requiredExperience)}";
        playerCurrentLevel.text = $"Level: {Mathf.Round(_levelCount)}";

    }
}
