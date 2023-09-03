using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{

    public Vector3 TargetPosition { get; set; } = Vector3.zero; // (사용자정의 O) 목표 위치를 저장하는 속성입니다.

    public NavMeshPath CalculatedPath { get; private set; } // (사용자정의 O) 계산된 경로를 저장하는 속성입니다.

    private void Start()
    {
        CalculatedPath = new NavMeshPath(); // (사용자정의 O) NavMeshPath 인스턴스를 생성하고 초기화합니다.
    }

    private void Update()
    {
        if (TargetPosition != Vector3.zero)
        { // (사용자정의 O) 목표 위치가 설정된 경우에만 경로를 계산합니다.
            NavMesh.CalculatePath(transform.position, TargetPosition, NavMesh.AllAreas, CalculatedPath); // (사용자정의 O) 현재 위치와 목표 위치를 기반으로 경로를 계산합니다.
        }
    }
}
