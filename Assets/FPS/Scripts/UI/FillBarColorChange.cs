using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class FillBarColorChange : MonoBehaviour
    {
        [Header("Foreground")] [Tooltip("Image for the foreground")]
        public Image ForegroundImage;

        [Tooltip("Default foreground color")] public Color DefaultForegroundColor;

        [Tooltip("Flash foreground color when full")]
        public Color FlashForegroundColorFull;

        [Header("Background")] [Tooltip("Image for the background")]
        public Image BackgroundImage;

        [Tooltip("Default background color")]
        public Color DefaultBackgroundColor;

        [Tooltip("background color when low ammo")]
        public Color LowAmmoBackgroundColor;

        [Tooltip("background color when empty")]
        public Color BackgroundColorEmpty;

        [Header("Values")] [Tooltip("Value to consider full")]
        public float FullValue = 1f;

        [Tooltip("Value to consider low ammo")] public float LowAmmoValue = .3f;

        [Tooltip("Value to consider empty")] public float EmptyValue = 0f;

        [Tooltip("Sharpness for the color change")]
        public float ColorChangeSharpness = 5f;

        float m_PreviousValue;

        public void Initialize(float fullValueRatio, float emptyValueRatio)
        {
            FullValue = fullValueRatio;
            EmptyValue = emptyValueRatio;

            m_PreviousValue = fullValueRatio;
        }

        public void UpdateVisual(float currentRatio)
        {
            if (currentRatio == FullValue && currentRatio != m_PreviousValue)
            {
                ForegroundImage.color = FlashForegroundColorFull;
            }else if (currentRatio > EmptyValue && currentRatio <= LowAmmoValue)
            {
                ForegroundImage.color = LowAmmoBackgroundColor;
            }
            else if (currentRatio == EmptyValue)
            {
                BackgroundImage.color = BackgroundColorEmpty;
            }
            else
            {
                ForegroundImage.color = Color.Lerp(ForegroundImage.color, DefaultForegroundColor,
                    Time.deltaTime * ColorChangeSharpness);
                BackgroundImage.color = Color.Lerp(BackgroundImage.color, DefaultBackgroundColor,
                    Time.deltaTime * ColorChangeSharpness);
            }

            m_PreviousValue = currentRatio;
        }
    }
}