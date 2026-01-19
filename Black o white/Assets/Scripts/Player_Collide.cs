using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Collide : MonoBehaviour
{
    [NonSerialized] public string spikeTag = "SpikeBlack";

    [SerializeField] private Player_Movement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(spikeTag))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Level_Manager.instance.FinishLevel();
        }
        if (collision.gameObject.CompareTag("Rust"))
        {
            playerMovement.canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rust"))
        {
            playerMovement.canMove = true;
        }
    }
    private void Die()
    {
        UI_Manager.instance.ReloadScene();
    }
}
