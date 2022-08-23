using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    public Button resetbtn;

    // Start is called before the first frame update
    void Start()
    {
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
