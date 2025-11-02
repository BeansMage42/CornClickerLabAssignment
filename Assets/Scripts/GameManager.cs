using UnityEngine;

public class GameManager : SingletonPersistant<GameManager>
{
    public CornClicker cornClicker;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Application.Quit();
        }

    }

}
