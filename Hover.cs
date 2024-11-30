using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace LiftlandsModManager
{
    public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Button button;
        private TextMeshProUGUI buttonText;
        private Color originalColor;
        private Color hoverColor = Color.gray;

        void Start()
        {
            button = GetComponent<Button>();
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            originalColor = buttonText.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            buttonText.color = hoverColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            buttonText.color = originalColor;
        }
    }

}
