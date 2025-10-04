using System;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : SingletonPersistant<UIManager>
{

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI cornPerClickText;
    [SerializeField] TextMeshProUGUI cornPerSecondText;
    [SerializeField] GameObject scoreUIObj;

    //Maybe later
    /*[Header("Shake variables")]
    [SerializeField] float baseShakeIntensity = 1.0f;
    [SerializeField] float maxShakeIntensity;
    [SerializeField] float shakeIntensityIncreaseSpeed;
    float shakeIntensityModifier;
    [SerializeField] float shakeCooldownSpeed;*/
    

    private void Start()
    {
        scoreUIObj = scoreUI.gameObject;
        CornPerSecond(0);
    }
    public void UpdateScore(float newScore)
    {
        scoreUI.text = "Corn Clicked: " + String.Format("{0:0.00}", newScore);
    }
    public void TextColor(Color color)
    {
        scoreUI.color = color;
    }

    public void SetButtonText(TextMeshProUGUI text, string name, string desc, float cost, int level)
    { 
        text.text = $"{name} \n {desc} \n Costs: {cost} corn \n level: {level}";
    }

    public void CornPerClick(float cornPerClick)
    {
        cornPerClickText.text = $"Corn Per Click: {cornPerClick}";
    }
    public void CornPerSecond(float cornPerSecond)
    {
        cornPerSecondText.text = $"Corn Per Second: {cornPerSecond}";
    }
}
