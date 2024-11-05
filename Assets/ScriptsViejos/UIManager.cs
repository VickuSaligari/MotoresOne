using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] _damageImages;
    void Awake()
    {
        EventManager.Subscribe(EventType.OnPlayerDamage, PlayerDamage);
    }

    private void PlayerDamage(params object[] parameter) 
    {
        foreach (var image in _damageImages) 
        {
            var actualColor = image.color;
            actualColor.a = 100 - (float)parameter[0];
            image.color = actualColor;
        }
    }
}
