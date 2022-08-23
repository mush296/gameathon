using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    public Button startbtn;

    // Start is called before the first frame update
    void Start()
    {
        startbtn.onClick.AddListener(() => {
            UIController.SetScreen(UIController.Screen.GAME);
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
