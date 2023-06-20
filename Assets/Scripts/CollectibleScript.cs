using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public GameManager scoreRef;

    private void OnTriggerEnter2D(Collider2D collision)
    {
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


}
