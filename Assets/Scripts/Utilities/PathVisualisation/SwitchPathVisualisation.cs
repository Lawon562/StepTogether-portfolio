using UnityEngine;

public class SwitchPathVisualisation : MonoBehaviour
{

    [SerializeField]
    private PathLineVisualisation pathLineVis; // (사용자정의 O) 경로 선 시각화
    [SerializeField]
    private PathArrowVisualisation arrowLineVis; // (사용자정의 O) 화살표 경로 시각화

    private int visualisationCounter = 0; // (사용자정의 O) 현재 활성화된 시각화를 변경하기 위한 카운터
    private GameObject activeVisualisation; // (사용자정의 O) 현재 활성화된 시각화 객체

    private void Start()
    {
        activeVisualisation = pathLineVis.gameObject; // 시작 시 경로 선 시각화를 활성화
    }

    // 시각화 방식을 전환하는 기능
    public void NextLineVisualisation()
    {
        visualisationCounter++;

        DisableAllPathVisuals();
        EnablePathVisualsByIndex(visualisationCounter);
    }

    private void DisableAllPathVisuals()
    {
        pathLineVis.gameObject.SetActive(false); // 경로 선 시각화 비활성화
        arrowLineVis.gameObject.SetActive(false); // 화살표 경로 시각화 비활성화
    }

    private void EnablePathVisualsByIndex(int visIndex)
    {
        switch (visIndex)
        {
            case 1:
                activeVisualisation = arrowLineVis.gameObject; // 시각화 방식을 화살표 경로로 변경
                break;
            default:
                activeVisualisation = pathLineVis.gameObject; // 시각화 방식을 경로 선으로 변경
                visualisationCounter = 0; // 시각화 방식 카운터 초기화
                break;
        }

        activeVisualisation.SetActive(true); // 변경된 시각화 방식 활성화
    }

    public void ToggleVisualVisibility()
    {
        activeVisualisation.SetActive(!activeVisualisation.activeSelf); // 시각화 객체의 활성화/비활성화 상태 전환
    }
}
