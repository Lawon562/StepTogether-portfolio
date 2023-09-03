using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TargetHandler : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController; // (사용자정의 O) 네비게이션 컨트롤러
    [SerializeField]
    private TextAsset targetModelData;
    [SerializeField]
    private TMP_Dropdown targetDataDropdown; // (사용자정의 X) 드롭다운 UI 컴포넌트

    [SerializeField]
    private GameObject targetObjectPrefab;
    [SerializeField]
    private Transform[] targetObjectsParentTransforms;

    private List<TargetFacade> currentTargetItems = new List<TargetFacade>(); // 현재 사용 가능한 타겟 목록

    private void Start()
    {
        GenerateTargetItems();
        FillDropdownWithTargetItems();
    }

    // 타겟 데이터 생성
    private void GenerateTargetItems()
    {
        IEnumerable<Target> targets = GenerateTargetDataFromSource();
        foreach (Target target in targets)
        {
            currentTargetItems.Add(CreateTargetFacade(target));
        }
    }

    // json 파일을 통해 타겟 데이터 생성
    private IEnumerable<Target> GenerateTargetDataFromSource()
    {
        return JsonUtility.FromJson<TargetWrapper>(targetModelData.text).TargetList;
    }

    // 타겟 데이터로 타겟 프리팹 생성
    private TargetFacade CreateTargetFacade(Target target)
    {
        GameObject targetObject = Instantiate(targetObjectPrefab, targetObjectsParentTransforms[target.FloorNumber], false);
        targetObject.SetActive(true);
        targetObject.name = $"{target.FloorNumber} - {target.Name}";
        targetObject.transform.localPosition = target.Position;
        targetObject.transform.localRotation = Quaternion.Euler(target.Rotation);

        TargetFacade targetData = targetObject.GetComponent<TargetFacade>();
        targetData.Name = target.Name;
        targetData.FloorNumber = target.FloorNumber;

        return targetData;
    }

    // 드롭다운 UI를 채움
    private void FillDropdownWithTargetItems()
    {
        List<TMP_Dropdown.OptionData> targetFacadeOptionData =
            currentTargetItems.Select(x => new TMP_Dropdown.OptionData
            {
                text = $"{x.FloorNumber} - {x.Name}"
            }).ToList();

        targetDataDropdown.ClearOptions();
        targetDataDropdown.AddOptions(targetFacadeOptionData);
    }

    // 선택된 드롭다운 아이템으로 타겟 위치 설정
    public void SetSelectedTargetPositionWithDropdown(int selectedValue)
    {
        print(selectedValue);
        navigationController.TargetPosition = GetCurrentlySelectedTarget(selectedValue);
    }

    // 현재 선택된 타겟 프리팹의 위치 반환
    private Vector3 GetCurrentlySelectedTarget(int selectedValue)
    {
        if (selectedValue >= currentTargetItems.Count)
        {
            return Vector3.zero;
        }

        return currentTargetItems[selectedValue].transform.position;
    }

    // 타겟 이름으로 타겟 프리팹 반환
    public TargetFacade GetCurrentTargetByTargetText(string targetText)
    {
        return currentTargetItems.Find(x =>
            x.Name.ToLower().Contains(targetText.ToLower()));
    }

}
