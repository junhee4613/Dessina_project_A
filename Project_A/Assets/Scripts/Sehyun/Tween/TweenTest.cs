using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                  //DoTween�� ����ϱ� ���� �߰�

public class TweenTest : MonoBehaviour
{   
    void Start()
    {
        //Tween ����
        //transform.DOMoveX(5, 2);                  //�� �������� 2�ʵ��� X�� 5�� �̵� ��Ų��.   
        //transform.DORotate(new Vector3(0, 0, 180), 2);      //�� ������Ʈ�� 2�ʵ��� Z������ 180�� ȸ�� ��Ų��. 
        //transform.DOScale(new Vector3(2, 2, 2), 2);         //�� ������Ʈ�� 2�ʵ��� Scale�� 2�� �ǵ��� Ű���.

        Sequence sequence = DOTween.Sequence();             //Tween�� �̾ ������� ���� �����ִ� ���� 
        sequence.Append(transform.DOMoveX(5, 1));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 1));
        sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 1));

    }
   
    void Update()
    {
        
    }
}
