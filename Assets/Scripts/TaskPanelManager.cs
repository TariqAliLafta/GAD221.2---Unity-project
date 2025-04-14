using UnityEngine;
using UnityEngine.UI;

public class TaskPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject taskPanel;
    [SerializeField] private Button taskButton;

    private void Start()
    {
        taskPanel.SetActive(false);
        taskButton.onClick.AddListener(ToggleTaskPanel);
    }

    public void ToggleTaskPanel()
    {
        taskPanel.SetActive(!taskPanel.activeSelf);
    }
}
