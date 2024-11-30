using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Diagnostics;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace LiftlandsModManager
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class LiftlandsModManager : BaseUnityPlugin
    {
        private const string MyGUID = "in.sculk.LiftlandsModManager";
        private const string PluginName = "LiftlandsModManager";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private ConfigEntry<string> configString;
        private ConfigEntry<bool> configBool;
        private ConfigEntry<int> configInt;
        private ConfigEntry<float> configFloat;

        private void Awake()
        {
            Logger.LogInfo($"{PluginName} {VersionString} is loading...");
            Harmony.PatchAll();
            Logger.LogInfo($"{PluginName} {VersionString} is loaded.");
            Log = Logger;
        }
        private void Start()
        {
            GameObject menuCanvas = GameObject.Find("MainMenuManager/Canvas");
            Transform menuButtons = menuCanvas.transform.Find("MenuButtons");
            Vector3 newPosition = menuButtons.localPosition;
            newPosition.y += 150;
            menuButtons.localPosition = newPosition;

            GameObject exitBtn = menuButtons.Find("EXIT")?.gameObject;

            GameObject modsButton = new GameObject("Mods");
            modsButton.name = "Mods";
            modsButton.transform.SetParent(menuButtons);

            Button buttonComponent = modsButton.AddComponent<Button>();

            TextMeshProUGUI exitBtnText = exitBtn.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI modsBtnText = modsButton.AddComponent<TextMeshProUGUI>();

            // Looks weird on non-1080p screens

            modsBtnText.text = "MODS";
            modsBtnText.fontSize = exitBtnText.fontSize;
            modsBtnText.font = exitBtnText.font;
            modsBtnText.alignment = exitBtnText.alignment;
            modsBtnText.outlineColor = exitBtnText.outlineColor;
            modsBtnText.outlineWidth = exitBtnText.outlineWidth;
            modsBtnText.fontStyle = FontStyles.Bold;

            RectTransform modsBtnRect = modsButton.GetComponent<RectTransform>();
            RectTransform exitBtnRect = exitBtn.GetComponent<RectTransform>();

            modsBtnRect.localScale = exitBtnRect.localScale;

            modsButton.transform.SetSiblingIndex(3);

            modsButton.AddComponent<Hover>();

            buttonComponent.interactable = true;
            buttonComponent.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            GameObject.Find("MainMenuManager").SetActive(false);
        }
    }
}
