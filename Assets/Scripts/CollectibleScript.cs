using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public GameManager scoreRef;
    //private AudioSource soundManager;

    //public AudioClip sound2;


    void Start()
    {
        //soundManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Collectible"))
        //{
        //    PlaySoundOnCollision(sound2);
        //}

        if (collision.CompareTag("Player"))
        {
            // ��������� ������������ � �������
            Collect();
        }
    }

    private void Collect()
    {
        scoreRef.puntos += 10; // ����������� ���� �� 10 �����
        scoreRef.nombreTXT.text = scoreRef.puntos.ToString(); // ��������� ����������� �����

        Debug.Log("Collected");

        // ��������� ����������� �������� ��� ������������ ��������
        gameObject.SetActive(false); // ��������� ����������� �������
        // ���
        // Destroy(gameObject); // ���������� ������
    }




    //private void PlaySoundOnCollision(AudioClip sound)
    //{
    //    // ������������� ����
    //    soundManager.clip = sound; // ������������� ��������� �������� ���� � ��������� AudioSource
    //    soundManager.Play();
    //}


}
