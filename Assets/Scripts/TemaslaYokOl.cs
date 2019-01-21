using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour {
    public GameObject patlama;
    public GameObject playerPatlama;

    GameObject OyunKontrol; //gameobje olan oyun kontrol
    oyunKontrol kontrol; //script olan kontrol

    void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("OyunKontrol");
        kontrol = OyunKontrol.GetComponent<oyunKontrol>();
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag!="Sinir")
        {
            Destroy(col.gameObject); //buna çarpan
            Destroy(gameObject); //kendini
            Instantiate(patlama, transform.position, transform.rotation);
            kontrol.ScoreArttir(10);
        }
        if (col.tag=="player")
        {
            Instantiate(playerPatlama, col.transform.position, col.transform.rotation);
            kontrol.oyunBitti();
        }
       
    }
}
