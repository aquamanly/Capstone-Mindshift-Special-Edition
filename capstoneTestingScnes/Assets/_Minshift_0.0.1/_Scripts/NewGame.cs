using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {
	public bool dadInfluence;
	public  bool girlInfluence;
	public bool momInfluence;
	public bool salesmanInfluence;

    public int[] scenes;
    public int i;
    public AudioSource music;

    void Awake () {
        SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
        music = GameObject.FindGameObjectWithTag("MainSoundtrack").GetComponent<AudioSource>();
        music.clip = music.GetComponent<audioPocket>().SoundsOfWar[6];
        music.Play();
        music.loop = true;
    }

    private void Update()
    {
        Scene name = SceneManager.GetActiveScene();
        Debug.Log(name.name);
    }
    public void NextLevel()
    {

        SceneManager.UnloadSceneAsync(scenes[i]);
        i++;
        SceneManager.LoadScene(scenes[i], LoadSceneMode.Additive);

      

    }

    public void NextLevelConversation(int NextLevel) {
        SceneManager.UnloadSceneAsync(scenes[i]);
        
        i++;
        SceneManager.LoadScene(scenes[NextLevel], LoadSceneMode.Additive);
        switch (i)
        {
            case 2:
                //music.Stop();
                break;

            case 8:
                
                //music.clip = music.GetComponent<audioPocket>().SoundsOfWar[3];
                //music.Play();
                break;

            default:
               
                break;
        }
    }
}
