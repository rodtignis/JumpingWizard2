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


}
