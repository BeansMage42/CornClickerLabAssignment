using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
    
}
