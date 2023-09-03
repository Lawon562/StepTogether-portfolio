using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{

    public Vector3 TargetPosition { get; set; } = Vector3.zero; // (��������� O) ��ǥ ��ġ�� �����ϴ� �Ӽ��Դϴ�.

    public NavMeshPath CalculatedPath { get; private set; } // (��������� O) ���� ��θ� �����ϴ� �Ӽ��Դϴ�.

    private void Start()
    {
        CalculatedPath = new NavMeshPath(); // (��������� O) NavMeshPath �ν��Ͻ��� �����ϰ� �ʱ�ȭ�մϴ�.
    }

    private void Update()
    {
        if (TargetPosition != Vector3.zero)
        { // (��������� O) ��ǥ ��ġ�� ������ ��쿡�� ��θ� ����մϴ�.
            NavMesh.CalculatePath(transform.position, TargetPosition, NavMesh.AllAreas, CalculatedPath); // (��������� O) ���� ��ġ�� ��ǥ ��ġ�� ������� ��θ� ����մϴ�.
        }
    }
}
