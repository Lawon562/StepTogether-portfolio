using TMPro;
using UnityEngine;

public class SetUiText : MonoBehaviour {

    [SerializeField]
    private TMP_Text textField; // (사용자정의 X) 텍스트를 표시할 TMP_Text 컴포넌트를 저장하는 변수입니다.
    [SerializeField]
    private string fixedText; // (사용자정의 X) UI 텍스트의 고정 텍스트입니다.

    public void OnSliderValueChanged(float numericValue)
    {
        textField.text = $"{fixedText}: {numericValue}"; // (사용자정의 X) 슬라이더 값과 함께 텍스트를 표시합니다.
    }
}
