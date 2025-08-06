using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Stage_Enter : MonoBehaviour
{
    [Header("설정")]
    public string[] oecdCountryTags = { "Korea" , "Japan" , "Au" };

    [Header("UI 요소")]
    public GameObject stageInfoPanel;
    public Image flagImage;

    private GameObject currentStageTrigger = null;
    private bool canInteract = false;

    void Start()
    {
        if (stageInfoPanel != null)
        {
            stageInfoPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            OpenStagePanel();
        }

        if (stageInfoPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseStagePanel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ★★★ 여기가 핵심 변경 부분입니다! ★★★
        // 만약 충돌한 오브젝트의 태그가 'oecdCountryTags' 배열에 포함되어 있다면,
        if (other.isTrigger && oecdCountryTags.Contains(other.tag))
        {
            Debug.Log($"유효한 스테이지 진입: {other.gameObject.name} (태그: {other.tag})");
            canInteract = true;
            currentStageTrigger = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentStageTrigger)
        {
            Debug.Log($"스테이지 벗어남: {other.gameObject.name}");
            canInteract = false;
            currentStageTrigger = null;
            CloseStagePanel();
        }
    }

    private void OpenStagePanel()
    {
        if (currentStageTrigger == null) return;

        string countryTag = currentStageTrigger.tag;
        Sprite countryFlagSprite = Resources.Load<Sprite>("Flags/" + countryTag);

        if (countryFlagSprite != null)
        {
            flagImage.sprite = countryFlagSprite;
            stageInfoPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"'{countryTag}' 태그에 맞는 국기 이미지를 Resources/Flags/ 폴더에서 찾을 수 없습니다.");
        }
    }

    private void CloseStagePanel()
    {
        if (stageInfoPanel != null)
        {
            stageInfoPanel.SetActive(false);
        }
    }
}
