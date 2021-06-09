using System;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    [SerializeField] private GameObject cameraObject;

    private Health _health;
    private void Awake()
    {
        if (photonView.IsMine) return;
        tag = "Enemy";
        Destroy(cameraObject);
        Destroy(GetComponent<FirstPersonCharacter>());
        Destroy(GetComponent<FirstPersonHeadBob>());
        Destroy(GetComponent<MouseRotator>());
        Destroy(GetComponentInChildren<Vibration>());
        var objs = GetComponentsInChildren<MouseRotator>();
        foreach (var obj in objs)
        {
            Destroy(obj);
        }
    }

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    void OnGUI()
    {
        if (!photonView.IsMine) return;
        GUI.Label(new Rect(200, Screen.height - 30, 100, 20), "Health: " + _health.currentHealth);
    }
}
