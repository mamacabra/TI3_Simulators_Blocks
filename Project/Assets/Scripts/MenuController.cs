using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public enum State {JOGAR, OPCOES, SAIR, CREDITOS, TEMCERTEZA, CONFIGOPCOES, PAINELJOGAR};
    State state = State.JOGAR;
    public GameObject jogar;
    public GameObject opcoes;
    public GameObject sair;
    public GameObject creditos;
    public GameObject temCerteza;
    public GameObject botoes;
    public GameObject confgOpcoes;
    public GameObject painelJogar;
    private Scene scene;
    public int controller = 0;
    public int control = 0;
    public Button buttonE;
    public Button buttonD;
    public Button buttonP;

    void Start(){
        ChangePanel();
        scene = SceneManager.GetActiveScene();
		Debug.Log(scene.name);
	}

    void Update(){
        if(controller == 4){
            controller = 0;
        }
        if(controller == -1){
            controller = 3;
        }
        Status();
        ChangePanel();

    }

    public void ButtonP(){
        BotaoPrincipal();
    }

    public void ButtonD(){
        controller ++;
        Debug.Log("Maior");
        BotaoMaior();
    }

    public void ButtonE(){
        controller --;
        Debug.Log("Menor");
        BotaoMenor();
    }

    public void BotaoMaior(){
        if(controller == 0){
            Debug.Log("Jogo");
        }
        if(controller == 1){
            //Config
            Debug.Log("Opções");
        }
        if(controller == 2){
            Debug.Log("Saindo");
        }
        if(controller == 3){
            //Creditos
            Debug.Log("Creditos");
        }
    }

    public void BotaoMenor(){
        if(controller == 0){
            Debug.Log("Jogo");
        }
        if(controller == 1){
            //Config
            Debug.Log("Opções");
        }
        if(controller == 2){
            Debug.Log("Saindo");
        }
        if(controller == 3){
            //Creditos
            Debug.Log("Creditos");
        }
    }

    public void BotaoPrincipal(){
        if(controller == 0){
            buttonP.gameObject.SetActive(false);
            Debug.Log("Jogo");
            control = 7;
        }
        if(controller == 1){
            //Config
            Debug.Log("Opções");
            control = 6;
        }
        if(controller == 2){
            Debug.Log("Saindo");
            control = 5;
            buttonP.gameObject.SetActive(false);
        }
        if(controller == 3){
            //Creditos
            Debug.Log("Creditos");
        }
    }

    public void Sim(){
        Application.Quit();
    }

    public void Nao(){
        buttonP.gameObject.SetActive(true);
        control = 0;
        temCerteza.SetActive(false);
    }

    public void X(){
        confgOpcoes.SetActive(false);
        painelJogar.SetActive(false);
        control = 0;
        buttonP.gameObject.SetActive(true);
    }

    public void FaseUm(){
        SceneManager.LoadScene("FoiOqueDeuPraFazer2");
    }
    public void FaseDois()
    {
        SceneManager.LoadScene("FoiOqueDeuPraFazer3");
    }

    void ChangePanel(){
        switch (state){
            case State.JOGAR:
            if(jogar){jogar.SetActive(true);}
                opcoes.SetActive(false);
                sair.SetActive(false);
                creditos.SetActive(false);
                temCerteza.SetActive(false);
                botoes.SetActive(true);
                confgOpcoes.SetActive(false);
                painelJogar.SetActive(false);
                break;

            case State.OPCOES:
            if(opcoes){jogar.SetActive(false);}
                opcoes.SetActive(true);
                sair.SetActive(false);
                creditos.SetActive(false);
                temCerteza.SetActive(false);
                botoes.SetActive(true);
                confgOpcoes.SetActive(false);
                painelJogar.SetActive(false);
                break;

            case State.SAIR:
            if(sair){jogar.SetActive(false);}
                opcoes.SetActive(false);
                sair.SetActive(true);
                creditos.SetActive(false);
                temCerteza.SetActive(false);
                botoes.SetActive(true);
                confgOpcoes.SetActive(false);
                painelJogar.SetActive(false);
                break;

            case State.CREDITOS:
            if(creditos){jogar.SetActive(false);}
                opcoes.SetActive(false);
                sair.SetActive(false);
                creditos.SetActive(true);
                temCerteza.SetActive(false);
                botoes.SetActive(true);
                confgOpcoes.SetActive(false);
                painelJogar.SetActive(false);
                break;

            case State.TEMCERTEZA:
            if(temCerteza){jogar.SetActive(false);}
                opcoes.SetActive(false);
                sair.SetActive(true);
                creditos.SetActive(false);
                temCerteza.SetActive(true);
                botoes.SetActive(false);
                confgOpcoes.SetActive(false);
                painelJogar.SetActive(false);
                break;

            case State.CONFIGOPCOES:
            if(confgOpcoes){jogar.SetActive(false);}
                opcoes.SetActive(true);
                sair.SetActive(false);
                creditos.SetActive(false);
                temCerteza.SetActive(false);
                botoes.SetActive(false);
                confgOpcoes.SetActive(true);
                buttonP.gameObject.SetActive(false);
                painelJogar.SetActive(false);
                break;

            case State.PAINELJOGAR:
            if(painelJogar){jogar.SetActive(true);}
                opcoes.SetActive(false);
                sair.SetActive(false);
                creditos.SetActive(false);
                temCerteza.SetActive(false);
                botoes.SetActive(false);
                confgOpcoes.SetActive(false);
                buttonP.gameObject.SetActive(false);
                painelJogar.SetActive(true);
                break;
        }
    }

    void Status(){
        if(controller == 0){
            state = State.JOGAR;
        }
        if(controller == 1){
            state = State.OPCOES;
        }
        if(controller == 2){
            state = State.SAIR;
        }
        if(controller == 3){
            state = State.CREDITOS;
        }
        if(control == 5){
            state = State.TEMCERTEZA;
        }
        if(control == 6){
            state = State.CONFIGOPCOES;
        }
        if(control == 7){
            state = State.PAINELJOGAR;
        }
    }
}
//0jogar-1opções-2sair-3creditos
