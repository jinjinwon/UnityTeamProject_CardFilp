using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlarmAnim : MonoBehaviour
{
    [Header("��� ����")]
    public Color alarmColor = Color.red;
    [Header("Ʈ�� ���� �ð�")]
    public float duration = 0.5f;

    // ���� ���� �����
    private Color originalColor;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        originalColor = cam.backgroundColor;
    }

    [ContextMenu("�˶� �׽�Ʈ ����")]
    public void AlarmStart()
    {
        DOTween.To(
            () => cam.backgroundColor,          
            x => cam.backgroundColor = x,       
            alarmColor,                         
            duration                            
        )
        .SetLoops(-1, LoopType.Yoyo)            
        .SetEase(Ease.Linear)                  
        .SetTarget(this.gameObject);                  
    }

    [ContextMenu("�˶� �׽�Ʈ ����")]
    public void AlarmStop()
    {
        DOTween.Kill(this.gameObject);
        cam.backgroundColor = originalColor;
    }
}
