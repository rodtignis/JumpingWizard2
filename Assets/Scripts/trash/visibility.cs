using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visibility : MonoBehaviour
{
    void StartGame()
    {
        // ���������� ������
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }

        // ���������� ��������
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        foreach (GameObject collectible in collectibles)
        {
            collectible.SetActive(true);
        }
    }
}
