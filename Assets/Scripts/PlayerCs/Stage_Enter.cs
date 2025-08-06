using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Stage_Enter : MonoBehaviour
{
    [Header("����")]
    public string[] oecdCountryTags = { "Korea" , "Japan" , "Au" };

    [Header("UI ���")]
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
        // �ڡڡ� ���Ⱑ �ٽ� ���� �κ��Դϴ�! �ڡڡ�
        // ���� �浹�� ������Ʈ�� �±װ� 'oecdCountryTags' �迭�� ���ԵǾ� �ִٸ�,
        if (other.isTrigger && oecdCountryTags.Contains(other.tag))
        {
            Debug.Log($"��ȿ�� �������� ����: {other.gameObject.name} (�±�: {other.tag})");
            canInteract = true;
            currentStageTrigger = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentStageTrigger)
        {
            Debug.Log($"�������� ���: {other.gameObject.name}");
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
            Debug.LogWarning($"'{countryTag}' �±׿� �´� ���� �̹����� Resources/Flags/ �������� ã�� �� �����ϴ�.");
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
