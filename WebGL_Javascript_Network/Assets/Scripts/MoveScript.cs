using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    void Start()
    {
        var cube = gameObject;
        cube.transform.DOMoveX(1, 1).SetLoops(-1, LoopType.Yoyo);
    }
}
