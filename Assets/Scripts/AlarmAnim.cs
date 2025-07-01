using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlarmAnim : MonoBehaviour
{
    [Header("비상 색상")]
    public Color alarmColor = Color.red;
    [Header("트윈 지속 시간")]
    public float duration = 0.5f;

    // 원래 배경색 저장용
    private Color originalColor;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        originalColor = cam.backgroundColor;
    }

    [ContextMenu("알람 테스트 시작")]
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

    [ContextMenu("알람 테스트 종료")]
    public void AlarmStop()
    {
        DOTween.Kill(this.gameObject);
        cam.backgroundColor = originalColor;
    }
}
