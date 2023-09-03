using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathLineVisualisation : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController; // (사용자정의 O) 경로 계산을 위한 NavigationController 컴포넌트
    [SerializeField]
    private LineRenderer line; // (사용자정의 O) 경로 라인을 그리기 위한 LineRenderer 컴포넌트
    [SerializeField]
    private Slider navigationYOffset; // (사용자정의 X) 경로 라인의 높이 조절을 위한 UI 슬라이더

    private NavMeshPath path; // (사용자정의 O) 계산된 경로 저장을 위한 NavMeshPath 객체
    private Vector3[] calculatedPathAndOffset; // 경로와 높이 조절값이 반영된 경로를 저장할 Vector3 배열

    private void Update()
    {
        path = navigationController.CalculatedPath; // NavigationController에서 계산된 경로 가져오기
        AddOffsetToPath(); // 경로에 높이 조절값 반영
        AddLineOffset(); // 경로 라인에 높이 조절값 반영
        SetLineRendererPositions(); // LineRenderer의 라인 위치를 계산된 경로와 일치하도록 설정
    }

    private void AddOffsetToPath()
    {
        calculatedPathAndOffset = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedPathAndOffset[i] = new Vector3(path.corners[i].x, transform.position.y, path.corners[i].z); // y값은 현재 객체의 y값으로 설정하여 높이 조절값을 반영하지 않도록 함
        }
    }

    private void AddLineOffset()
    {
        if (navigationYOffset.value != 0)
        { // 높이 조절값이 0이 아닌 경우에만 반영
            for (int i = 0; i < calculatedPathAndOffset.Length; i++)
            {
                calculatedPathAndOffset[i] += new Vector3(0, navigationYOffset.value, 0); // y값에 높이 조절값을 더함
            }
        }
    }

    private void SetLineRendererPositions()
    {
        line.positionCount = calculatedPathAndOffset.Length; // 라인 렌더러의 포지션 개수를 경로 포인트 개수와 일치하도록 설정
        line.SetPositions(calculatedPathAndOffset); // 라인 렌더러의 포지션 값을 계산된 경로와 일치하도록 설정
    }
}
