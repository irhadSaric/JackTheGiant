using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previusPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        previusPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if(transform.position.y < previusPosition.y)
            {
                scoreCount++;
            }
            previusPosition = transform.position;
            GameplayController.instance.setScore(scoreCount);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            GameplayController.instance.setCoinScore(coinCount);
            GameplayController.instance.setScore(scoreCount);
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            GameplayController.instance.setScore(scoreCount);
            GameplayController.instance.setLifeScore(lifeCount);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Bounds")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
        }

        if(target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
        }

    }
}
