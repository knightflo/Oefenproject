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
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paint"))
        {
            UI_Manager.instance.PaintCollect();
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        UI_Manager.instance.ReloadScene();
    }
}
