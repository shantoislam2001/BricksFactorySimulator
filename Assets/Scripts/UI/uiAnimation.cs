using UnityEngine;
using UnityEngine.UI;

public class MultiPanelAnimationScript : MonoBehaviour
{
    [System.Serializable]
    public class UIPanel
    {
        public GameObject panel;        // The UI panel to animate
        public float fadeDuration = 1f; // Duration of the fade animation
        [HideInInspector]
        public CanvasGroup canvasGroup; // CanvasGroup component of the panel
    }

    public UIPanel[] uiPanels; // Array of UI panels to animate

    private void Start()
    {
        // Assign a CanvasGroup to each panel and initialize transparency
        foreach (var panel in uiPanels)
        {
            panel.canvasGroup = panel.panel.GetComponent<CanvasGroup>();
            if (panel.canvasGroup == null)
            {
                panel.canvasGroup = panel.panel.AddComponent<CanvasGroup>();
            }
            panel.canvasGroup.alpha = 0f; // Start with the panel fully transparent (optional)
        }
    }

    // Call this method to fade in a specific UI panel
    public void FadeIn(int panelIndex)
    {
        if (panelIndex >= 0 && panelIndex < uiPanels.Length)
        {
            StartCoroutine(FadeUI(uiPanels[panelIndex].canvasGroup, uiPanels[panelIndex].canvasGroup.alpha, 1f, uiPanels[panelIndex].fadeDuration));
        }
    }

    // Call this method to fade out a specific UI panel
    public void FadeOut(int panelIndex)
    {
        if (panelIndex >= 0 && panelIndex < uiPanels.Length)
        {
            StartCoroutine(FadeUI(uiPanels[panelIndex].canvasGroup, uiPanels[panelIndex].canvasGroup.alpha, 0f, uiPanels[panelIndex].fadeDuration));
        }
    }

    private System.Collections.IEnumerator FadeUI(CanvasGroup cg, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null;
        }

        cg.alpha = endAlpha;
    }
}
