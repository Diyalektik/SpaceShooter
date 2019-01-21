using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyunKontrol : MonoBehaviour {

    public GameObject Asteroid;
    public Vector3 randomPos;
    

    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;

    public Text text;
    public Text oyunBittiText;
    public Text yenidenBaslaText;

    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;

    int score;


	// Use this for initialization
	void Start () {
        score = 0;
        text.text = "score = " + score;
        oyunBittiText.text = "";
        yenidenBaslaText.text = "";
        StartCoroutine(olustur());
	}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    // Update is called once per frame
    IEnumerator olustur() {

        //5saniye bekle, 1 saniye aralıklarla asteroidleri 
        //yarat, 10 tane olduğunda 2 saniye bekle,
        // tekrar başa dön(5 saniye beklemeye).

        yield return new WaitForSeconds(baslangicBekleme);
        while (true) 
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }
            
            if (oyunBittiKontrol)
            {

                yenidenBaslaKontrol = true;
                yenidenBaslaText.text = "yeniden baslamak icin r ye bas";
                break;
            }
            yield return new WaitForSeconds(donguBekleme);

        }

        

    }
    public void ScoreArttir(int gelenScore)
    {
        
        score += gelenScore;
        text.text = "score = " + score;
    }

    public void oyunBitti()
    {
        oyunBittiText.text = "oyun bitti";
        oyunBittiKontrol = true;

    }
}
