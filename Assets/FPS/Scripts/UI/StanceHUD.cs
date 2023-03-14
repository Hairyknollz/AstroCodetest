using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class StanceHUD : MonoBehaviour
    {
        [Tooltip("Image component for the stance sprites")]
        public Image StanceImage;

        [Tooltip("Sprite to display when standing")]
        public Sprite StandingSprite;

        [Tooltip("Sprite to display when crouching")]
        public Sprite CrouchingSprite;

        [Tooltip("Sprite to display when sliding")]
        public Sprite SlidingSprite;

        void Start()
        {
            PlayerCharacterController character = FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, StanceHUD>(character, this);
            character.OnStanceChanged += OnStanceChanged;

            OnStanceChanged("standing");
        }

        void OnStanceChanged(string stanceName)
        {
            //changes stanceHUD image to correct image depending on current stance

            switch (stanceName)
            {
                case "crouched":
                    StanceImage.sprite = CrouchingSprite;
                    break;
                case "standing":
                    StanceImage.sprite = StandingSprite;
                    break;
                case "sliding":
                    StanceImage.sprite = SlidingSprite;
                    break;
                default:
                    StanceImage.sprite = StandingSprite;
                    break;
            }
        }
    }
}