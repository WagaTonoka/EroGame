using System.Collections;
using UnityEngine;
using TMPro;

public class SpeechPrinter : MonoBehaviour
{
    [SerializeField] private TMP_Text _selfText;
    [SerializeField] private GameObject _charPrefab;

    private IEnumerator _printText;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _selfText.GetComponent<TMP_Text>();
    }

    public void PrintText(float time = 0.025f)
    {
        if (_printText != null) { StopCoroutine(_printText); }
        _printText = PrintTextCoroutine(time);
        StartCoroutine(_printText);
    }

    private IEnumerator PrintTextCoroutine(float time)
    {
        _selfText.ForceMeshUpdate();
        yield return null;

        TMP_TextInfo textInfo = _selfText.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charaInfo = textInfo.characterInfo[i];
            if (!charaInfo.isVisible) continue;

            char content = charaInfo.character;
            CharColorType color = CharColorType.white;
            Vector3 localCenter = (charaInfo.bottomLeft + charaInfo.topRight) * 0.5f;

            SpeechChar charObject =
                Instantiate(_charPrefab, _selfText.transform).GetComponent<SpeechChar>();
            charObject.Initialize(content, color, localCenter);

            charObject.Enter();
            yield return new WaitForSeconds(time);
        }
        yield return null;
    }
}
