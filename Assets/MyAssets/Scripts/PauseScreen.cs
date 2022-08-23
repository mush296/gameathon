using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public Button resumebtn;
    public Button resetbtn;

    // Start is called before the first frame update
    void Start()
    {
        resumebtn.onClick.AddListener(() => {
            UIController.SetScreen(UIController.Screen.GAME);
            gameObject.SetActive(false);
        });

        resetbtn.onClick.AddListener(() =>
        {
            UIController.SetScreen(UIController.Screen.HOME);
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
