using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioClip scream_1;
	public AudioClip scream_2;

    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    public static SoundManager instance;  //자기자신을 변수로 담습니다.

    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (SoundManager.instance == null) //instance가 비어있는지 검사합니다.
        {
            SoundManager.instance = this; //자기자신을 담습니다.
        }
    }

    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
    }		


	public void PlayScream1Sound()
	{
		myAudio.PlayOneShot(scream_1); 
	}

    public void PlayScream2Sound()
	{
		myAudio.PlayOneShot(scream_2); 
	}
}
