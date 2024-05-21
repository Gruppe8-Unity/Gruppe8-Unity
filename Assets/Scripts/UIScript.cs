using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIScript : MonoBehaviour
{
    public Player player;
    private float _scoreCount;
    private float _experienceCount;
    private float _requiredExperience;
    private int _levelCount;
    
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerExperience;
    public TextMeshProUGUI playerCurrentLevel;
    public Image experienceBar;
    public Image healthBar;
    
    private void Start()
    {
        _scoreCount = 0;
        _experienceCount = 0;
        _levelCount = 1;
        _requiredExperience = 10;
    }

    private void Update()
    {
        UpdateHealthBar();
        UpdateScore();
        UpdateExperience();
    }
    
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(player.currentPlayerHealth / player.maxPlayerHealth, 0, 1);
    }
    private void UpdateScore()
    {
        _scoreCount += Time.deltaTime; // Placeholder until enemies grant experience/score.
        playerScore.text = $"Score: {Mathf.Round(_scoreCount)}"; 
    }
    private void UpdateExperience()
    {
        _experienceCount += Time.deltaTime; //Placeholder until enemies grant experience/score.
        experienceBar.fillAmount = Mathf.Clamp( _experienceCount / _requiredExperience , 0, 1);
        
        playerExperience.text = $"{Mathf.Round(_experienceCount)} / {Mathf.Round(_requiredExperience)}";
        playerCurrentLevel.text = $"Level: {Mathf.Round(_levelCount)}";
        
        if (_experienceCount < _requiredExperience)
        {
            return;
        }
        
        _experienceCount = 0;
        _levelCount++;
        _requiredExperience = _requiredExperience * 1.2f;
    }
    
}
