using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VinoUtility.Game
{
    public class WorldspaceHealthBar : MonoBehaviour
    {
        [Tooltip("Health component to track")] public Health health;

        [Tooltip("Image component displaying health left")]
        public Image HealthBarImage;

        [Tooltip("The floating healthbar pivot transform")]
        public Transform HealthBarPivot;

        [Tooltip("Whether the health bar is visible when at full health or not")]
        public bool HideFullHealthBar = true;

        void Update()
        {
            // update health bar value
            HealthBarImage.fillAmount = health.GetRatio();

            // hide health bar if needed
            if (HideFullHealthBar)
                HealthBarPivot.gameObject.SetActive(HealthBarImage.fillAmount != 1);
            if(health.IsCritical())
            {
                var newColor = HealthBarImage.color;
                newColor.a = 0.6f + 0.4f*Mathf.Sin( 1f / health.GetRatio()  * Time.time);
                HealthBarImage.color = newColor;
            }
        }
    }
}