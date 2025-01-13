using UnityEngine;
using TMPro;

namespace GD.Selection
{
    /// <summary>
    /// Displays the name of the selected object in the UI when it is selected.
    /// </summary>
    public class TextSelectionResponse : SelectionResponse
    {
        [SerializeField]
        [Tooltip("The UI Text element to display the selected object's name.")]
        private TextMeshProUGUI selectionText;  

        [SerializeField]
        [Tooltip("The format of the displayed text.")]
        private string textFormat = "Selected: {0}";  
        
        public override void OnSelect(Transform currentTransform)
        {
            if (currentTransform == null || selectionText == null) return;

            string objectName = currentTransform.name;

            selectionText.text = string.Format(textFormat, objectName);

            base.OnSelect(currentTransform);  
        }

        public override void OnDeselect(Transform currentTransform)
        {
            if (selectionText == null) return;

            selectionText.text = string.Empty;

            base.OnDeselect(currentTransform);  
        }
    }
}
