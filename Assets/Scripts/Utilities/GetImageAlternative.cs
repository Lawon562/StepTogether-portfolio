using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using ZXing;

public class GetImageAlternative : MonoBehaviour
{

    [SerializeField]
    private ARCameraBackground arCameraBackground; // (사용자정의 X) AR 배경에 대한 정보를 가진 컴포넌트입니다.
    [SerializeField]
    private RenderTexture targetRenderTexture; // (사용자정의 X) 렌더링 대상 텍스처입니다.
    [SerializeField]
    private TextMeshProUGUI qrCodeText; // (사용자정의 X) QR 코드 결과를 표시할 TextMeshProUGUI 컴포넌트입니다.

    private Texture2D cameraImageTexture;
    private IBarcodeReader reader = new BarcodeReader(); // 바코드 리더 인스턴스 생성

    private void Update()
    {
        // 현재 핸드폰 화면의 AR 배경 내용을 렌더링 타겟 텍스처에 복사합니다

        //Graphics.Blit은 화면 복사의  기능을 합니다, 구조 : (원본,복사대상,이미지에 입힐 메테리얼)
        //즉 arCameraBackground의 메테리얼로 씌워진 새로운 targetRenderTexture를 만드는 코드입니다

        Graphics.Blit(null, targetRenderTexture, arCameraBackground.material);

        // 렌더링 타겟 텍스처의 데이터로 텍스처 생성
        // AR 배경화면을 바로 활용하지 않고 복사하는 이유는  QR 코드 인식 라이브러리(ZXing)가 처리할 수 있는 형식의 텍스처를 준비하기 위함입니다.
        //마지막의 bool값은 mip maps이라는 요소로 성능을 위해 텍스쳐의 다양한 해상도 버전을 생성해 최적화에 도움을 주는기능을 킬지 말지 결정하는 요소입니다
        cameraImageTexture = new Texture2D(targetRenderTexture.width, targetRenderTexture.height, TextureFormat.RGBA32, false);
        //구조 (복사할 텍스쳐, 복사한 텍스쳐가 들어갈 변수)
        Graphics.CopyTexture(targetRenderTexture, cameraImageTexture);

        // 복사한 텍스처에서 바코드 인식
        var result = reader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

        // 바코드 인식 결과 처리
        if (result != null)
        {
            qrCodeText.text = result.Text;
        }
    }
}
