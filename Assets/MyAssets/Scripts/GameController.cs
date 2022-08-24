using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public TMP_Text timerTxt;
    public TMP_Text scoreTxt;

    public TMP_Text questionTxt;
    public Transform answersContainer;
    public GameObject answerPrefab;

    public Transform cameraTransform;

    public Vector3 babyCamPos;
    public Quaternion babyCamRot;
    public Vector3 doctorCamPos;
    public Quaternion doctorCamRot;
    public Vector3 nurseCamPos;
    public Quaternion nurseCamRot;
    public Vector3 roomCamPos;
    public Quaternion roomCamRot;

    private float timer = 0;
    private int score = 0;

    public List<Question> questionList;

    int index = 0;

    bool started = false;
    bool paused = false;

    [Serializable]
    public class Question
    {
        public string questionText;
        public List<string> answers;
        public int correctAnswerIndex;
        public float timeToAnswer = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIController.SetScreen(UIController.Screen.HOME);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIController.SetScreen(UIController.Screen.PAUSE);
            PauseGame();
        }

        if(started && !paused)
        {
            if (timer <= 0)
            {
                timer = 0;
                NextQuestion(false);
            }
            else timer -= Time.deltaTime;
        }

        timerTxt.text = timer.ToString("F0");
        scoreTxt.text = score.ToString();
    }

    internal void StartGame()
    {
        if (!started)
        {
            score = 0;
            SetUpQuestion();
        }

        started = true;
        paused = false;
    }

    internal void CheckAnswer(int answerIndex)
    {
        if(answerIndex == questionList[index].correctAnswerIndex)
        {
            score += 10;
        }
        else
        {
            score -= 10;
        }

        NextQuestion(true);
    }

    private void NextQuestion(bool answeredInTime)
    {
        if (!answeredInTime) score -= 5;

        index++;

        SetUpQuestion();
    }

    private void SetUpQuestion()
    {
        if (index >= questionList.Count)
        {
            UIController.SetScreen(UIController.Screen.RESULTS);
            timer = 0;
            started = false;
            return;
        }

        questionTxt.text = questionList[index].questionText;

        foreach (Transform child in answersContainer)
            Destroy(child.gameObject);

        for (int i = 0; i < questionList[index].answers.Count; i++)
        {
            GameObject answerObj = Instantiate(answerPrefab, answersContainer);

            answerObj.GetComponentInChildren<TMP_Text>().text = questionList[index].answers[i];

            int answerIndex = i;

            answerObj.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                CheckAnswer(answerIndex);
            });
        }

        timer = questionList[index].timeToAnswer;
    }

    private void PauseGame()
    {
        paused = true;
    }

    internal void ResetGame()
    {
        index = 0;
        timer = 0;
        started = false;
    }

    public void LookAtBaby()
    {
        cameraTransform.position = babyCamPos;
        cameraTransform.rotation = babyCamRot;
    }

    public void LookAtDoctor()
    {
        cameraTransform.position = doctorCamPos;
        cameraTransform.rotation = doctorCamRot;
    }
    public void LookAtNurse()
    {
        cameraTransform.position = nurseCamPos;
        cameraTransform.rotation = nurseCamRot;
    }
    public void LookAtAll()
    {
        cameraTransform.position = roomCamPos;
        cameraTransform.rotation = roomCamRot;
    }
}
