using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuFAse : MonoBehaviour
{
    public enum State {JOGAR, PAUSE, OPCOES, SAIR, TEMCERTEZA};
    State state = State.JOGAR;
    public GameObject confgOpcoes;
    public GameObject temCerteza;
    public GameObject pause;
    void Start()
    {
        ChangePanel();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
			if (Time.timeScale == 1){
				Time.timeScale = 0;
				state = State.PAUSE;
				ChangePanel();
			}
			else{
				Time.timeScale = 1;
				state = State.JOGAR;
				ChangePanel();
			}
		}
    }

    public void Opcoes(){
        state = State.OPCOES;
		ChangePanel();
    }

    public void Sair(){
		state = State.TEMCERTEZA;
		ChangePanel();
    }

    public void Sim(){
        Application.Quit();
    }

    public void Nao(){
        pause.SetActive(true);
        temCerteza.SetActive(false);
    }

    public void Menu(){
		SceneManager.LoadScene("Menu");
    }

    public void XConfig(){
        confgOpcoes.SetActive(false);
        pause.SetActive(true);
    }
    public void XPause(){
        pause.SetActive(false);
        Time.timeScale = 1;
		state = State.JOGAR;
		ChangePanel();

    }
    void ChangePanel(){
        switch (state){
            case State.JOGAR:
            if(confgOpcoes){confgOpcoes.SetActive(false);}
                temCerteza.SetActive(false);
                pause.SetActive(false);
                Time.timeScale = 1.0f;
                break;

            case State.PAUSE:
            if(pause){confgOpcoes.SetActive(false);}
                temCerteza.SetActive(false);
                pause.SetActive(true);
                Time.timeScale = 0.0f;
                break;

            case State.OPCOES:
            if(confgOpcoes){confgOpcoes.SetActive(true);}
                temCerteza.SetActive(false);
                pause.SetActive(false);
                Time.timeScale = 0.0f;
                break;

            case State.TEMCERTEZA:
            if(temCerteza){confgOpcoes.SetActive(false);}
                temCerteza.SetActive(true);
                pause.SetActive(false);
                Time.timeScale = 0.0f;
                break;
        }
    }
}
