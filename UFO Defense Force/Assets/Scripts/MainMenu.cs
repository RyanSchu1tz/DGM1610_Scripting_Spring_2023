using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour


{
    private AudioSource StartG;
    public AudioClip StartGa;
    private AudioSource EndG;
    public AudioClip EndGa;
    
    [SerializeField]
    private int sceneToLoad;

    void Start()
    {
        // get audiosource component
        StartG = GetComponent<AudioSource>();
        EndG = GetComponent<AudioSource>();
    } 

    public void StartGame()
    {
        StartG.PlayOneShot(StartGa,1.0f);
        SceneManager.LoadScene(sceneToLoad); //Indexed Scene to LoadScene
        Debug.Log("New Scene Loaded!");
    }

    public void QuitGame()
    {
        EndG.PlayOneShot(EndGa,1.0f);
        Application.Quit(); //Quit Game
        Debug.Log("You have quit the game, goodbye!");
    }

    
}
