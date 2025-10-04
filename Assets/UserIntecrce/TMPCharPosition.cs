using TMPro;
using UnityEngine;

public class TMPCharSpawner_Local : MonoBehaviour
{
    public TMP_Text sourceText;    // TextMeshPro 또는 TextMeshProUGUI
    public GameObject textPrefab;  // TMP_Text가 붙은 프리팹

    void Start()
    {
        sourceText.ForceMeshUpdate();
        TMP_TextInfo textInfo = sourceText.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var ci = textInfo.characterInfo[i];
            if (!ci.isVisible) continue;

            // 글자 중심 (로컬)
            Vector3 localCenter = (ci.bottomLeft + ci.topRight) * 0.5f;

            // sourceText의 자식으로 생성 → localPosition을 그대로 사용
            GameObject go = Instantiate(textPrefab, sourceText.transform);
            go.transform.localPosition = localCenter;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;

            Debug.Log(sourceText.transform.position);

            var tmp = go.GetComponent<TMP_Text>();
            tmp.text = ci.character.ToString();
            tmp.alignment = TextAlignmentOptions.Center; // 중심 정렬 권장
        }
    }
}
