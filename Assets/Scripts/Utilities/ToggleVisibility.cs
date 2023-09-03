using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{

    [SerializeField]
    private GameObject toggleObject; // (��������� X) �ش� ���� ������Ʈ�� Ȱ��ȭ/��Ȱ��ȭ�� ���

    public void Toggle()
    {
        toggleObject.SetActive(!toggleObject.activeSelf); // (��������� X) �ش� ���� ������Ʈ�� Ȱ��ȭ/��Ȱ��ȭ
    }
}
