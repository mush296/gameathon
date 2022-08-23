using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject pauseScreen;
    public GameObject resultsScreen;

    GameController gameController;

    private static UIController instance;

    private void Awake()
    {
        instance = this;
        gameController = GetComponent<GameController>();
    }

    private void Start()
    {

    }

    public static void SetScreen(Screen screen)
    {
        switch (screen)
        {
            case Screen.HOME:
                instance.homeScreen.SetActive(true);
                instance.gameController.ResetGame();
                break;
            case Screen.PAUSE:
                instance.pauseScreen.SetActive(true);
                break;
            case Screen.GAME:
                instance.gameController.StartGame();
                break;
            case Screen.RESULTS:
                instance.resultsScreen.SetActive(true);
                break;
        }
    }

    public enum Screen
    {
        HOME,
        PAUSE,
        GAME,
        RESULTS
    }
}
