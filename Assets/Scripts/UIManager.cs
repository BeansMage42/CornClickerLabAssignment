using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI cornPerClickText;
    [SerializeField] GameObject scoreUIObj;

    //Maybe later
    /*[Header("Shake variables")]
    [SerializeField] float baseShakeIntensity = 1.0f;
    [SerializeField] float maxShakeIntensity;
    [SerializeField] float shakeIntensityIncreaseSpeed;
    float shakeIntensityModifier;
    [SerializeField] float shakeCooldownSpeed;*/
    

    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreUIObj = scoreUI.gameObject;
    }
    public void UpdateScore(float newScore)
    {
        scoreUI.text = "Corn Clicked: " + newScore;
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
}
