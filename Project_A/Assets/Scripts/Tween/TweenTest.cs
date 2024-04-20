using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                  //DoTween을 사용하기 위해 추가

public class TweenTest : MonoBehaviour
{   
    void Start()
    {
        //Tween 단위
        //transform.DOMoveX(5, 2);                  //이 오브젝를 2초동안 X축 5로 이동 시킨다.   
        //transform.DORotate(new Vector3(0, 0, 180), 2);      //이 오브젝트를 2초동안 Z축으로 180도 회전 시킨다. 
        //transform.DOScale(new Vector3(2, 2, 2), 2);         //이 오브젝트를 2초동안 Scale이 2가 되도록 키운다.

        Sequence sequence = DOTween.Sequence();             //Tween을 이어서 순서대로 실행 시켜주는 단위 
        sequence.Append(transform.DOMoveX(5, 1));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 1));
        sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 1));

    }
   
    void Update()
    {
        
    }
}
