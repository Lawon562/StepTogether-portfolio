using TMPro;
using UnityEngine;

public class SetUiText : MonoBehaviour {

    [SerializeField]
    private TMP_Text textField; // (��������� X) �ؽ�Ʈ�� ǥ���� TMP_Text ������Ʈ�� �����ϴ� �����Դϴ�.
    [SerializeField]
    private string fixedText; // (��������� X) UI �ؽ�Ʈ�� ���� �ؽ�Ʈ�Դϴ�.

    public void OnSliderValueChanged(float numericValue)
    {
        textField.text = $"{fixedText}: {numericValue}"; // (��������� X) �����̴� ���� �Բ� �ؽ�Ʈ�� ǥ���մϴ�.
    }
}
