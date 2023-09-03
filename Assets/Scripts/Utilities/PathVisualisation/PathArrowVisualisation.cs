using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathArrowVisualisation : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController; // (사용자정의 O) 경로 계산을 위한 NavigationController 스크립트 참조
    [SerializeField]
    private GameObject arrow; // (사용자정의 O) 시각화에 사용될 화살표 게임 오브젝트
    [SerializeField]
    private Slider navigationYOffset; // (사용자정의 O) Y축 이동 거리를 조절할 슬라이더
    [SerializeField]
    private float moveOnDistance; // (사용자정의 O) 다음 경로 지점을 선택하는 거리

    private NavMeshPath path;
    private float currentDistance;
    private Vector3[] pathOffset;
    private Vector3 nextNavigationPoint = Vector3.zero;

    private void Update()
    {
        path = navigationController.CalculatedPath;

        AddOffsetToPath();
        SelectNextNavigationPoint();
        AddArrowOffset();

        arrow.transform.LookAt(nextNavigationPoint);
    }

    // 경로에 오프셋 추가
    private void AddOffsetToPath()
    {
        pathOffset = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            pathOffset[i] = new Vector3(path.corners[i].x, transform.position.y, path.corners[i].z);
        }
    }

    // 거리 기준 다음 경로 지점 선택
    private void SelectNextNavigationPoint()
    {
        nextNavigationPoint = SelectNextNavigationPointWithinDistance();
    }

    // 다음 경로 지점 계산
    private Vector3 SelectNextNavigationPointWithinDistance()
    {
        for (int i = 0; i < pathOffset.Length; i++)
        {
            currentDistance = Vector3.Distance(transform.position, pathOffset[i]);
            if (currentDistance > moveOnDistance)
            {
                return pathOffset[i];
            }
        }
        return navigationController.TargetPosition;
    }

    // Y축 이동 거리 추가
    private void AddArrowOffset()
    {
        if (navigationYOffset.value != 0)
        {
            arrow.transform.position = new Vector3(arrow.transform.position.x, navigationYOffset.value, arrow.transform.position.z);
        }
    }

}
