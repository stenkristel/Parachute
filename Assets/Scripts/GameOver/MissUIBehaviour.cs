using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameOver
{
    //Made by: Sten Kristel
    /// <summary>
    /// Updates the UI whenever the player misses a parachute, to show how many parachutes the player has missed
    /// </summary>
    public class MissUIBehaviour : MonoBehaviour
    {
        [SerializeField] private List<RawImage> missImages = new();                 //The UI images that depict how many parachutes the player has missed.
        [SerializeField] private Texture missedSharkTexture;                        //The texture the images should get when the player misses a parachute.

        private void Start() => AssignEvents();                 //Assigns events on start

        private void OnDestroy() => UnAssignEvents();           //Unassigns events on destroy (prevents issues on scene changes)

        private void AssignEvents() => GameOverManager.Instance.OnParachuteMissed += UpdateMissedParachutesUI;    //assigns UpdateMissedParachutesUI on OnParachuteMissed event
        private void UnAssignEvents() => GameOverManager.Instance.OnParachuteMissed -= UpdateMissedParachutesUI;  //unAssigns UpdateMissedParachutesUI on OnParachuteMissed event

        /// <summary>
        /// Updates an image with a new texture that represents a miss, and changes colour to default, to reset the alpha
        /// </summary>
        /// <param name="missedParachutes">the amount of parachutes the player has missed to determine which image to change</param>
        private void UpdateMissedParachutesUI(int missedParachutes)
        {
            if (missedParachutes > missImages.Count) return;
            var image = missImages[missedParachutes - 1];
            image.texture = missedSharkTexture;
            image.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
