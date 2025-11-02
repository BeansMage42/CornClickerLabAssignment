using System;
using System.Collections;
using TMPro;
using TMPro.Examples;
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
    [SerializeField] private VertexJitter jitter;
    private float jitterSpeed = 0;
    private float jitterTimer = 2;
    private float maxJitter = 2;
    private float currentJitter;
    [SerializeField] private float jitterClickBoost = 0.1f;

    private void Start()
    {
        scoreUIObj = scoreUI.gameObject;
        CornPerSecond(0);
        GameManager.Instance.cornClicker.OnClickAction += UpdateScore;
        GameManager.Instance.cornClicker.OnClickAction += ClickEventJitter;

    }
    private void Update()
    {
        
        
            jitterTimer -= Time.deltaTime;
            if( jitterTimer <= 0 && currentJitter > 0)
            {
                jitterTimer = 0;
                currentJitter -= Time.deltaTime;
                
                
            }
            if(currentJitter <= 0)
            {
                jitterSpeed = 0;
            }
        
        jitter.AngleMultiplier = currentJitter;
        jitter.SpeedMultiplier = jitterSpeed;
        jitter.CurveScale = currentJitter * 0.5f * 25f;

        
    }
    public void ClickEventJitter(float jigglejiggle)
    {
        jitterSpeed = 1;
        jitterTimer = 2;
        currentJitter = Math.Clamp(currentJitter + jitterClickBoost, 0,maxJitter);

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
