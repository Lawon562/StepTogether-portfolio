using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TargetHandler : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController; // (��������� O) �׺���̼� ��Ʈ�ѷ�
    [SerializeField]
    private TextAsset targetModelData;
    [SerializeField]
    private TMP_Dropdown targetDataDropdown; // (��������� X) ��Ӵٿ� UI ������Ʈ

    [SerializeField]
    private GameObject targetObjectPrefab;
    [SerializeField]
    private Transform[] targetObjectsParentTransforms;

    private List<TargetFacade> currentTargetItems = new List<TargetFacade>(); // ���� ��� ������ Ÿ�� ���

    private void Start()
    {
        GenerateTargetItems();
        FillDropdownWithTargetItems();
    }

    // Ÿ�� ������ ����
    private void GenerateTargetItems()
    {
        IEnumerable<Target> targets = GenerateTargetDataFromSource();
        foreach (Target target in targets)
        {
            currentTargetItems.Add(CreateTargetFacade(target));
        }
    }

    // json ������ ���� Ÿ�� ������ ����
    private IEnumerable<Target> GenerateTargetDataFromSource()
    {
        return JsonUtility.FromJson<TargetWrapper>(targetModelData.text).TargetList;
    }

    // Ÿ�� �����ͷ� Ÿ�� ������ ����
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

    // ��Ӵٿ� UI�� ä��
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

    // ���õ� ��Ӵٿ� ���������� Ÿ�� ��ġ ����
    public void SetSelectedTargetPositionWithDropdown(int selectedValue)
    {
        print(selectedValue);
        navigationController.TargetPosition = GetCurrentlySelectedTarget(selectedValue);
    }

    // ���� ���õ� Ÿ�� �������� ��ġ ��ȯ
    private Vector3 GetCurrentlySelectedTarget(int selectedValue)
    {
        if (selectedValue >= currentTargetItems.Count)
        {
            return Vector3.zero;
        }

        return currentTargetItems[selectedValue].transform.position;
    }

    // Ÿ�� �̸����� Ÿ�� ������ ��ȯ
    public TargetFacade GetCurrentTargetByTargetText(string targetText)
    {
        return currentTargetItems.Find(x =>
            x.Name.ToLower().Contains(targetText.ToLower()));
    }

}
