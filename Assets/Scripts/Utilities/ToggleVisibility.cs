using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{

    [SerializeField]
    private GameObject toggleObject; // (사용자정의 X) 해당 게임 오브젝트를 활성화/비활성화할 대상

    public void Toggle()
    {
        toggleObject.SetActive(!toggleObject.activeSelf); // (사용자정의 X) 해당 게임 오브젝트를 활성화/비활성화
    }
}
