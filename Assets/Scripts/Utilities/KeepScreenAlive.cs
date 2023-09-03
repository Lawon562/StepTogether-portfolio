using UnityEngine;

public class KeepScreenAlive : MonoBehaviour {

    private void Start() {
        // 화면 절전 모드 비활성화
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
