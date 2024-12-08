using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup; // Assign the Panel with CanvasGroup component
        public TextMeshProUGUI fadeText;    // If using TextMeshPro
        public Text fadeTextUI;            // If using standard Text
        public float fadeDuration = 1f;
    
        private void Start()
        {
            // Ensure the CanvasGroup starts fully transparent
            fadeCanvasGroup.alpha = 0;
            fadeText.enabled = false;
            if (fadeTextUI != null) fadeTextUI.enabled = false;
            
            // Start the coroutine
            //StartCoroutine(RunAfterDelay());
        }
        
        
        private IEnumerator RunAfterDelay()
        {
            // Wait for 15 seconds
            yield return new WaitForSeconds(15f);
            
            _FadeToBlack("Loading...");

            // Code to execute after 15 seconds
            Debug.Log("15 seconds have passed!");
        }

        public void _FadeToBlack(string message)
        {
            // Set text and start fade coroutine
            if (fadeText != null) fadeText.text = message;
            if (fadeTextUI != null) fadeTextUI.text = message;
    
            StartCoroutine(FadeIn());
        }
    
        private IEnumerator FadeIn()
        {
            fadeText.enabled = true;
            if (fadeTextUI != null) fadeTextUI.enabled = true;
    
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
                yield return null;
            }
    
            // Keep the screen black and text visible (Optional: trigger additional logic here)
        }
    
        public void FadeOut()
        {
            StartCoroutine(FadeOutRoutine());
        }
    
        private IEnumerator FadeOutRoutine()
        {
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeCanvasGroup.alpha = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
                yield return null;
            }
    
            fadeText.enabled = false;
            if (fadeTextUI != null) fadeTextUI.enabled = false;
        }
}
