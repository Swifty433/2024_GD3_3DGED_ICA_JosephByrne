using TMPro;
using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Allows us to attach multiple responses to a selected object
    /// </summary>
    public class AdvancedSelectionManager : MonoBehaviour
    {
        [SerializeField]
        private IRayProvider rayProvider;

        [SerializeField]
        private ISelector selector;

        [SerializeField]
        private ISelectionResponse response;

        [SerializeField]
        [Tooltip("The UI Text element to display the name of hovered object.")]
        private TextMeshProUGUI hoverText;

        private Transform currentSelection;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            //get a ray provider
            rayProvider = GetComponent<IRayProvider>();

            //get a selector
            selector = GetComponent<ISelector>();

            //get a reponse
            response = GetComponent<ISelectionResponse>();

            if(hoverText != null)
                hoverText.text = string.Empty;
        }

        private void Update()
        {
            //set de-selected
            if (currentSelection != null)
            {
                response.OnDeselect(currentSelection);
                ClearHoverText();
            }

            //create/get ray
            selector.Check(rayProvider.CreateRay());

            //get current selection (cast ray, do tag/layer comparison)
            currentSelection = selector.GetSelection();

            //set selected
            if (currentSelection != null)
            {
                response.OnSelect(currentSelection);
                UpdateHoverText(currentSelection);
            }
        }

        private void UpdateHoverText(Transform selection)
        {
            if (hoverText != null)
                hoverText.text = selection.name;
        }

        private void ClearHoverText()
        {
            if(hoverText != null)
                hoverText.text = string.Empty;
        }
    }
}