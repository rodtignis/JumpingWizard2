using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	public float movementSpeed = 10f;
	public float fallSpeed = 10f;
	public GameManager gameManager;
	public Camera mainCamera;
	private float characterHeight;
	public AudioClip sound1; 
	public AudioClip sound2;

	public RankingManager referencia;

	private AudioSource soundManager;


	[SerializeField]

	Rigidbody2D wiz;



	void Start()
	{
		wiz = GetComponent<Rigidbody2D>();
		gameManager = FindObjectOfType<GameManager>();
		characterHeight = GetComponent<SpriteRenderer>().bounds.extents.y;

		soundManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();


	}

	void Update()
	{
		
		float horizontalInput = Input.acceleration.x;

		wiz.velocity = new Vector2(horizontalInput * movementSpeed, wiz.velocity.y);

		float characterBottom = transform.position.y - characterHeight;
		float cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;


		if (wiz.transform.position.x > 4.37f)
		{

			wiz.transform.position = new Vector3(-3f, wiz.transform.position.y, wiz.transform.position.z);
		
		}


		if (wiz.transform.position.x < -3f)
		{

			wiz.transform.position = new Vector3(4.37f, wiz.transform.position.y, wiz.transform.position.z);
		
		}




		if (characterBottom < cameraBottom)
		{
			Die();
		}

	}



	private void PlaySoundOnCollision(AudioClip sound)
	{
		soundManager.clip = sound; 
		soundManager.Play();
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Die();
		}


		if (collision.gameObject.CompareTag("Platform"))
		{
			PlaySoundOnCollision(sound1);
		}
		
		if (collision.gameObject.CompareTag("Collectible"))
		{
			PlaySoundOnCollision(sound2);
		}

	}

	private void Die()
	{
		gameManager.GuardarPuntosDB();
		//referencia.BorrarPuntos(3);
		//referencia.ObtenerRanking();
        //referencia.BorrarPuntosExtra();
        //referencia.MostrarRanking();
		SceneManager.LoadScene("DeathScene");

	}



}
   
