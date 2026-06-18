using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UniversalPopupUI : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI messageText;
    public Button acceptButton;
    public Button rejectButton;

    private Action onAccept;
    private Action onReject;

    private void Start()
    {
        Hide();
    }

    public void Show(string title, string message, Action acceptAction, Action rejectAction = null, bool showReject = true)
    {
        popupPanel.SetActive(true);

        titleText.text = title;
        messageText.text = message;

        onAccept = acceptAction;
        onReject = rejectAction;

        acceptButton.onClick.RemoveAllListeners();
        rejectButton.onClick.RemoveAllListeners();

        acceptButton.onClick.AddListener(() =>
        {
            Hide();
            onAccept?.Invoke();
        });

        rejectButton.onClick.AddListener(() =>
        {
            Hide();
            onReject?.Invoke();
        });

        rejectButton.gameObject.SetActive(showReject);
    }

    public void Hide()
    {
        popupPanel.SetActive(false);
    }
}