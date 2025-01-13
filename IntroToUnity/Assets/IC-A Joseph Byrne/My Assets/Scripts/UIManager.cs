using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance { get; private set; }

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

    [SerializeField]
    [Tooltip("The tutorial panel displayed at game start")]
    private GameObject tutorialPanel;

    [SerializeField]
    [Tooltip("The button to close tutorial panel")]
    private Button closeTutorialButton;

    private void Awake()
    {
        // Check if there's already an instance of UIManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // Destroy the duplicate UIManager
        }
        else
        {
            Instance = this;
            // Create a new root GameObject and attach the UIManager to it
            GameObject rootObject = new GameObject("UIManagerRoot");
            transform.SetParent(rootObject.transform);  // Set UIManager as a child of the root GameObject
            DontDestroyOnLoad(rootObject);  // Apply DontDestroyOnLoad to the root object
        }

        // Ensure the panel is starts hidden
        if (itemFactPanel != null)
            itemFactPanel.SetActive(false);

        if (closeButton != null)
            closeButton.onClick.AddListener(HideItemFact);

        if (winPanel != null)
            winPanel.SetActive(false);

        if (closeButton != null)
            closeButton.onClick.AddListener(HideItemFact);

        if(tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            if(closeTutorialButton != null)
                closeTutorialButton.onClick.AddListener(HideTutorialPanel);
        }
    }

    public void ShowWinPanel()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
    }

    public void HideVictoryScreen()
    { 
        if(winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
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

    ///<summary>
    /// Hides the tutorial Panel
    /// </summary>
    private void HideTutorialPanel()
    {
        if(tutorialPanel != null)
            tutorialPanel.SetActive(false);
    }
}
