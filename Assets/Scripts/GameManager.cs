using UnityEngine;

public class GameManager : SingletonPersistant<GameManager>
{
    public static GameManager instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Application.Quit();
        }

    }

}
