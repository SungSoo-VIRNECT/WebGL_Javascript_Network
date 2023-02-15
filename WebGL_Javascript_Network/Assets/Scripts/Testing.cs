using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;

public class Testing : MonoBehaviour
{
    public Button infoButton;
    public Button startButton;
    public Button endButton;
    public Button quizEndButton;


    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void ChangeToL1();

    [DllImport("__Internal")]
    private static extern void SendMessageToJS(string s);

    void Start()
    {
        infoButton.onClick.AddListener(() => SendMessageToJS("lectureInfo"));
        startButton.onClick.AddListener(() => SendMessageToJS("lectureStart"));
        endButton.onClick.AddListener(() => SendMessageToJS("lectureEnd"));
        //quizEndButton.onClick.AddListener(() => SendMessageToJS("lectureQuizEnd"));
        quizEndButton.onClick.AddListener(ChangeToL1);

        Hello();

        HelloString("This is a string.");

        float[] myArray = new float[10];
        PrintFloatArray(myArray, myArray.Length);

        int result = AddNumbers(5, 7);
        Debug.Log(result);

        Debug.Log(StringReturnValueFunction());


    }

}
