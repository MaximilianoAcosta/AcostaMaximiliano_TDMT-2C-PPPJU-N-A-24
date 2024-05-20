using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeColider : MonoBehaviour
{
    [SerializeField] string collideWithTag;
    [SerializeField] string sceneToChange;

    [SerializeField] SceneController sceneController;
    [SerializeField] PauseGame PauseGame;
    [SerializeField] MenuActivation MenuActivation;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(collideWithTag))
        {
            PauseGame.Pause();
            MenuActivation.OpenMenu(1);
            sceneController.ChangeGameScene(sceneToChange);
        }
    }
}