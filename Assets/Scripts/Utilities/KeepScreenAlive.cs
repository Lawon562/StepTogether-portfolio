using UnityEngine;

public class KeepScreenAlive : MonoBehaviour {

    private void Start() {
        // ȭ�� ���� ��� ��Ȱ��ȭ
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
