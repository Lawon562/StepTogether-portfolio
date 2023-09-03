using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugTest : MonoBehaviour
{
    public ImageDetector EntranceTarget;
    public ImageDetector LobbyTarget;
    public ImageDetector RomaTarget;
    public ImageDetector OfficeTarget;
    public ImageDetector RestAreaTarget;
    public Text Entrance;
    public Text Lobby;
    public Text Roma;
    public Text Office;
    public Text RestArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Entrance.GetComponent<Text>().text = EntranceTarget.flag.ToString();
        Lobby.GetComponent<Text>().text = LobbyTarget.flag.ToString();
        Roma.GetComponent<Text>().text = RomaTarget.flag.ToString();
        Office.GetComponent<Text>().text = OfficeTarget.flag.ToString();
        RestArea.GetComponent<Text>().text = RestAreaTarget.flag.ToString();
    }
}
