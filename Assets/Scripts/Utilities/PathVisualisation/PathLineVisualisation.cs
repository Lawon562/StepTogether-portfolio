using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathLineVisualisation : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController; // (��������� O) ��� ����� ���� NavigationController ������Ʈ
    [SerializeField]
    private LineRenderer line; // (��������� O) ��� ������ �׸��� ���� LineRenderer ������Ʈ
    [SerializeField]
    private Slider navigationYOffset; // (��������� X) ��� ������ ���� ������ ���� UI �����̴�

    private NavMeshPath path; // (��������� O) ���� ��� ������ ���� NavMeshPath ��ü
    private Vector3[] calculatedPathAndOffset; // ��ο� ���� �������� �ݿ��� ��θ� ������ Vector3 �迭

    private void Update()
    {
        path = navigationController.CalculatedPath; // NavigationController���� ���� ��� ��������
        AddOffsetToPath(); // ��ο� ���� ������ �ݿ�
        AddLineOffset(); // ��� ���ο� ���� ������ �ݿ�
        SetLineRendererPositions(); // LineRenderer�� ���� ��ġ�� ���� ��ο� ��ġ�ϵ��� ����
    }

    private void AddOffsetToPath()
    {
        calculatedPathAndOffset = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedPathAndOffset[i] = new Vector3(path.corners[i].x, transform.position.y, path.corners[i].z); // y���� ���� ��ü�� y������ �����Ͽ� ���� �������� �ݿ����� �ʵ��� ��
        }
    }

    private void AddLineOffset()
    {
        if (navigationYOffset.value != 0)
        { // ���� �������� 0�� �ƴ� ��쿡�� �ݿ�
            for (int i = 0; i < calculatedPathAndOffset.Length; i++)
            {
                calculatedPathAndOffset[i] += new Vector3(0, navigationYOffset.value, 0); // y���� ���� �������� ����
            }
        }
    }

    private void SetLineRendererPositions()
    {
        line.positionCount = calculatedPathAndOffset.Length; // ���� �������� ������ ������ ��� ����Ʈ ������ ��ġ�ϵ��� ����
        line.SetPositions(calculatedPathAndOffset); // ���� �������� ������ ���� ���� ��ο� ��ġ�ϵ��� ����
    }
}
