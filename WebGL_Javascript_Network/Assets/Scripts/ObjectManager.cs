using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{

    public Button startButton;
    public Button endButton;
    public Button quizEndButton;
    public GameObject leftModel;
    public GameObject rightModel;
    
    void Start()
    {
        startButton.onClick.AddListener(StartScene);
        endButton.onClick.AddListener(EndScene);
        quizEndButton.onClick.AddListener(EndQuizTime);

    }

    public void StartScene()
    {
        leftModel.transform.DOMoveX(-3.699f, 3).SetLoops(3, LoopType.Yoyo);
        rightModel.transform.DOMoveX(3.153f, 3).SetLoops(3, LoopType.Yoyo);
        startButton.interactable = false;
    }
    
    public void EndScene()
    {
        DOTween.PauseAll();
        endButton.interactable = false;
    }

    public void QuizTime()
    {

    }

    public void EndQuizTime()
    {
        quizEndButton.interactable = false;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
