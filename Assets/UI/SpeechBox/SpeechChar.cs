using UnityEngine;
using TMPro;

public class SpeechChar : UITransitionBase
{
    private string _originContent;
    private Vector3 _originPosition;
    private Vector3 _previousPosition;

    [SerializeField] private TMP_Text _selfText;

    public void Initialize(char content, CharColorType color, Vector2 position)
    {
        base.Initialize();

        // 변수 설정
        _originContent = content.ToString();

        _originPosition = position;
        _previousPosition = position + new Vector2(5f, -5f);

        // 초기값 설정
        _selfText.text = _originContent;
        _selfText.alignment = TextAlignmentOptions.Center;
        _selfText.alignment = TextAlignmentOptions.Midline;

        SetPosition(TransitionType.Instant, 0f, Vector3.zero, _originPosition);
        SetRotate(TransitionType.Instant, 0f, Vector3.zero, Vector3.zero);
        SetScale(TransitionType.Instant, 0f, Vector3.zero, Vector3.one);
        SetAlpha(TransitionType.Instant, 0f, 0f, 0f);
    }

    public void Enter()
    {
        SetPosition(TransitionType.Smooth, 0.1f, _previousPosition, _originPosition);
        SetAlpha(TransitionType.Smooth, 0.1f, 0f, 1f);
    }

    public void EnterInstant()
    {
        SetPosition(TransitionType.Instant, 0f, Vector3.zero, _originPosition);
        SetAlpha(TransitionType.Instant, 0f, 0f, 0f);
    }

    public void Exit()
    {

    }
}
