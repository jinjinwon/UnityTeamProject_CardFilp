using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardMover : MonoBehaviour
{
    public Card _card = null;

    [Header("카드 이동 시간 / 카드 딜레이 시간")]
    public float moveDuration = 0.5f;           // 이동 시간
    public float delayBetween = 0.1f;           // 딜레이 시간

    [Header("이동 타입")]
    public Ease moveEase = Ease.OutBack;        // 이동 타입

    [Header("카드의 초기 크기 ~ 최종 크기")]
    public Vector3 startScale = Vector3.zero;   // 시작 스케일
    public Vector3 endScale = Vector3.one;      // 끝 스케일

    public void Show(Vector2 vec_TargetPos, Card card, int index)
    {
        if (_card != null) return;
        _card = card;

        Transform tf = _card.transform;

        // 초기화: 중앙(0,0,0), 스케일 startScale
        tf.localPosition = Vector3.zero;
        tf.localScale = startScale;

        float delay = delayBetween * index;

        // 로컬 위치 이동
        tf
          .DOLocalMove(vec_TargetPos, moveDuration)
          .SetDelay(delay)
          .SetEase(moveEase);

        // 스케일 애니메이션
        tf
          .DOScale(endScale, moveDuration)
          .SetDelay(delay)
          .SetEase(moveEase);
    }

    private void OnDisable()
    {
        _card = null;
    }
}
