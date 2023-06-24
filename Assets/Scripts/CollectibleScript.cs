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
            // Обработка столкновения с игроком
            Collect();
        }
    }

    private void Collect()
    {
        scoreRef.puntos += 10; // Увеличиваем счет на 10 очков
        scoreRef.nombreTXT.text = scoreRef.puntos.ToString(); // Обновляем отображение счета

        Debug.Log("Collected");

        // Выполните необходимые действия для исчезновения предмета
        gameObject.SetActive(false); // Отключаем отображение объекта
        // или
        // Destroy(gameObject); // Уничтожаем объект
    }




    //private void PlaySoundOnCollision(AudioClip sound)
    //{
    //    // Воспроизводим звук
    //    soundManager.clip = sound; // Устанавливаем выбранный звуковой файл в компонент AudioSource
    //    soundManager.Play();
    //}


}
