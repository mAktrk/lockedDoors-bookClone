using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{

    [SerializeField] private GameObject anahtarVar;
    [SerializeField] private GameObject kapiAcik;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && anahtarVar.activeSelf) 
        {
            collision.gameObject.SetActive(false);
            kapiAcik.SetActive(true);
            Application.LoadLevel(1);
        }
    }
}
