using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The UI panel used to display item facts")]
    private GameObject itemFactPanel;

    [SerializeField]
    [Tooltip("The Text UI element to display item facts.")]
    private TextMeshProUGUI itemFactText;

    //[SerializeField]
    //[Tooltip("The duration the fact is displayed for.")]
    //private float displayDuration = 3f;

    //private Coroutine displayCoroutine;

    [SerializeField]
    [Tooltip("The Button to stop displaying on screen text")]
    private Button closeButton;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        // Ensure the panel is starts hidden
        if (itemFactPanel != null)
            itemFactPanel.SetActive(false);

        if (closeButton != null)
            closeButton.onClick.AddListener(HideItemFact);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

    /// <summary>
    /// Displays the fact about an item.
    /// </summary>
    /// <param name="fact">The fact to display.</param>
    public void DisplayItemFact(string fact)
    {
        if (itemFactPanel == null || itemFactText == null) return;

        //if (displayCoroutine != null)
        //{
        //    StopCoroutine(displayCoroutine);
        //}

        itemFactText.text = fact;
        itemFactPanel.SetActive(true);

        //displayCoroutine = StartCoroutine(HideItemFactAfterDelay());
    }

    public void HideItemFact()
    {
        if (itemFactPanel != null)
            itemFactPanel.SetActive(false);
    }

    //private System.Collections.IEnumerator HideItemFactAfterDelay()
    //{
    //    yield return new WaitForSeconds(displayDuration);
    //    if (itemFactPanel != null)
    //        itemFactPanel.SetActive(false);
    //}

    //private IEnumerator ShowFactCoroutine(string fact)
    //{
    //    itemFactText.text = fact;
    //    yield return new WaitForSeconds(displayDuration);
    //    itemFactText.text = "";
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
