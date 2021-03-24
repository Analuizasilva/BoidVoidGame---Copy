using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class BadgeManager : MonoBehaviour
{
    [SerializeField]
    public GameObject BadgeWindowPrefab;
    [SerializeField]
    public GameObject BadgeButtonPrefab;

    public Toggle Toggle;

    private Badge[] badges;

    void Start()
    {
        StartCoroutine(
            Requester.Get("http://localhost:62448/api/badge", (error, data) =>
            { LoadData(error, data); })
            );
    }

    public void ManageBadgeInfo(KeyValuePair<string, int> keyValuePair, Badge badge)
    {
        var oldPrefab = GameObject.FindGameObjectWithTag("BadgesWindow");
        GameObject.Destroy(oldPrefab);

        var windowGO = GameObject.FindGameObjectWithTag("BadgeMenuContent").transform;
        GameObject windowPrefab = Instantiate(BadgeWindowPrefab, windowGO);

        BadgeData badgeData = new BadgeData();
        badgeData.BadgeName = keyValuePair.Key;
        badgeData.BadgeDescription = badge.BadgeType.Description;
        badgeData.Timestamp = badge.Timestamp;
        badgeData.Quantity = keyValuePair.Value;

        var prefabComponents = windowPrefab.GetComponentsInChildren<Text>();
        //var toggle = windowPrefab.GetComponentInChildren<Toggle>();
        //if (badgeData.isFavorite) toggle.isOn = true;

        foreach (var component in prefabComponents)
        {
            if (component.name == "BadgeName") component.text = badgeData.BadgeName;
            if (component.name == "Description") component.text = badgeData.BadgeDescription;
            if (component.name == "ObtainedDate") component.text = badgeData.Timestamp.ToString();
            if (component.name == "Quantity") component.text = badgeData.Quantity.ToString();
        }

    }

    public class BadgeData
    {
        public string BadgeName { get; set; }
        public string BadgeDescription { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public bool isFavorite { get; set; }
    }

    public Dictionary<string, int> GetBadgeType(Badge[] badges)
    {
        Dictionary<string, int> badgeTypeCounter = new Dictionary<string, int>();
        foreach (var badge in badges)
        {
            var key = badge.BadgeType.Name;
            int value = 1;

            if (badgeTypeCounter.ContainsKey(key))
            {
                badgeTypeCounter[key] = value + 1;
            }
            else
            {
                badgeTypeCounter.Add(key, value);
            }
        }
        return badgeTypeCounter;
    }


    private void LoadData(string error, byte[] data)
    {
        if (!string.IsNullOrEmpty(error))
        {
            Debug.LogError(error);
        }
        else
        {
            var requestResult = System.Text.Encoding.Default.GetString(data);

            badges = JsonHelper.GetJsonArray<Badge>(requestResult, "Badges");

            if (badges != null)
            {
                var dictionary = GetBadgeType(badges);
                BadgeData badgeData = new BadgeData();
                foreach (var entry in dictionary)
                {
                    var buttonGameObject = GameObject.FindGameObjectWithTag("BadgesDownButton").transform;
                    GameObject buttonPrefab = Instantiate(BadgeButtonPrefab, buttonGameObject);

                    var badge = badges.Where(x => x.BadgeType.Name == entry.Key).FirstOrDefault();

                    buttonPrefab.GetComponent<Text>().text = entry.Key;
                    var buttonText = buttonPrefab.GetComponent<Text>().text;
                    
                    if (entry.Key == buttonText)
                    {
                        buttonPrefab.GetComponent<Button>().onClick.AddListener(delegate
                        {
                            ManageBadgeInfo(entry, badge);

                        });
                    }
                }
            }
        }
    }
}
