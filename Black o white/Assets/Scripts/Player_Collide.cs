using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Collide : MonoBehaviour
{
    [NonSerialized] public string spikeTag = "SpikeBlack";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(spikeTag))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Level_Manager.instance.finishLevel();
        }
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
