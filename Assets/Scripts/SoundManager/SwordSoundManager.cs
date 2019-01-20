using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSoundManager : MonoBehaviour
{
    public AudioClip sword_air; //재생할 소리를 변수로 담습니다.
    public AudioClip sword_person;

    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    public static SwordSoundManager instance;  //자기자신을 변수로 담습니다.

    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (SwordSoundManager.instance == null) //instance가 비어있는지 검사합니다.
        {
            SwordSoundManager.instance = this; //자기자신을 담습니다.
        }
    }

    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
    }		
    

	public void PlaySwordAirSound()
	{
		myAudio.PlayOneShot(sword_air); 
    }

    public void PlaySwordPersonSound()
	{
		myAudio.PlayOneShot(sword_person); 
    }
}
