using UnityEngine;

public class SwitchPathVisualisation : MonoBehaviour
{

    [SerializeField]
    private PathLineVisualisation pathLineVis; // (��������� O) ��� �� �ð�ȭ
    [SerializeField]
    private PathArrowVisualisation arrowLineVis; // (��������� O) ȭ��ǥ ��� �ð�ȭ

    private int visualisationCounter = 0; // (��������� O) ���� Ȱ��ȭ�� �ð�ȭ�� �����ϱ� ���� ī����
    private GameObject activeVisualisation; // (��������� O) ���� Ȱ��ȭ�� �ð�ȭ ��ü

    private void Start()
    {
        activeVisualisation = pathLineVis.gameObject; // ���� �� ��� �� �ð�ȭ�� Ȱ��ȭ
    }

    // �ð�ȭ ����� ��ȯ�ϴ� ���
    public void NextLineVisualisation()
    {
        visualisationCounter++;

        DisableAllPathVisuals();
        EnablePathVisualsByIndex(visualisationCounter);
    }

    private void DisableAllPathVisuals()
    {
        pathLineVis.gameObject.SetActive(false); // ��� �� �ð�ȭ ��Ȱ��ȭ
        arrowLineVis.gameObject.SetActive(false); // ȭ��ǥ ��� �ð�ȭ ��Ȱ��ȭ
    }

    private void EnablePathVisualsByIndex(int visIndex)
    {
        switch (visIndex)
        {
            case 1:
                activeVisualisation = arrowLineVis.gameObject; // �ð�ȭ ����� ȭ��ǥ ��η� ����
                break;
            default:
                activeVisualisation = pathLineVis.gameObject; // �ð�ȭ ����� ��� ������ ����
                visualisationCounter = 0; // �ð�ȭ ��� ī���� �ʱ�ȭ
                break;
        }

        activeVisualisation.SetActive(true); // ����� �ð�ȭ ��� Ȱ��ȭ
    }

    public void ToggleVisualVisibility()
    {
        activeVisualisation.SetActive(!activeVisualisation.activeSelf); // �ð�ȭ ��ü�� Ȱ��ȭ/��Ȱ��ȭ ���� ��ȯ
    }
}
