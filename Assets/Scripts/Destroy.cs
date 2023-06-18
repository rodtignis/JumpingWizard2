using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Update()
    {
        // Получаем позицию нижней границы камеры
        float cameraBottom = Camera.main.transform.position.y - Camera.main.orthographicSize;

        // Если платформа находится ниже нижней границы камеры, уничтожаем ее
        if (transform.position.y < cameraBottom)
        {
            Destroy(gameObject);
        }
    }

}