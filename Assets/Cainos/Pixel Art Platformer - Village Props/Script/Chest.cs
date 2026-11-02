using UnityEngine;
using Cainos.Common;
using UnityEngine.InputSystem;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    //code used: -https://www.youtube.com/watch?v=swwUZrlDopQ
    public class Chest : MonoBehaviour
    {
        [FoldoutGroup("Reference")]
        public Animator animator;
        private PlayerInput playerInput;
        public int pointsReward = 10;
        private PlayerScore playerScore;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerInput>(out var input))
            {
                playerInput = input;
                playerScore = input.GetComponent<PlayerScore>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerInput>(out var input))
            {
                if (input == playerInput)
                {
                    playerInput = null;
                }
            }
        }

        private void Update() 
        {
            if (isOpened || playerInput == null)
                return;

            if (playerInput.actions["Interact"].WasPressedThisFrame()) 
            {
                Open();

            }
        }

        [FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        [FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            if (isOpened)
                return;

            IsOpened = true;

            if (playerScore != null) 
            {
                playerScore.AddPoints(pointsReward);
            }
        }

        [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }
    }
}
