using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour {

    //Dungeon 1
    public GameObject PPCircleLogo;
    public GameObject PPSquareLogo;
    public GameObject PPStarLogo;
    public GameObject PPStarLogo2;
    public GameObject Door;
    public GameObject BossDoor;

    private int Order = 1;
    private int WrongOrder = 0;

    public Material Selected;
    public Material Correct;
    public Material Standard;
    private Material Circle;
    private Material Square;
    private Material Star;
    private Material Star2;

    private bool CircleSelected;
    private bool SquareSelected;
    private bool StarSelected;
    private bool IsWrong;

    public Player player;

    void Start()
    {
        Circle = PPCircleLogo.GetComponent<Renderer>().material;
        Square = PPSquareLogo.GetComponent<Renderer>().material;
        Star = PPStarLogo.GetComponent<Renderer>().material;
        Star2 = PPStarLogo2.GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (WrongOrder >= 3 || Order >= 1 && WrongOrder >= 2)
        {
            WrongOrder = 0;
            IsWrong = false;
            Order = 1;
            Circle.color = Standard.color;
            Square.color = Standard.color;
            Star.color = Standard.color;
            Star2.color = Standard.color;
            CircleSelected = false;
            SquareSelected = false;
            StarSelected = false;
        }

        if(player.Collected == 3)
        {
            BossDoor.GetComponent<Animator>().SetBool("CanOpen", true);
        }
        
    }

    void CorrectOrder()
    {
        Circle.color = Correct.color;
        Square.color = Correct.color;
        Star.color = Correct.color;
        Star2.color = Correct.color;
        Door.GetComponent<Animator>().SetBool("CanOpen", true);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == PPCircleLogo)
        {
            if(Order == 3 && CircleSelected == false && IsWrong == false)
            {
                Circle.color = Selected.color;
                CircleSelected = true;
                CorrectOrder();
            }
            else if(CircleSelected == false)
            {
                Circle.color = Selected.color;
                WrongOrder++;
                CircleSelected = true;
                IsWrong = true;
            }
        }

        if(other.gameObject == PPSquareLogo)
        {
            if(Order == 1 && SquareSelected == false && IsWrong == false)
            {
                Square.color = Selected.color;
                Order++;
                SquareSelected = true;
            }
            else if(SquareSelected == false)
            {
                Square.color = Selected.color;
                WrongOrder++;
                SquareSelected = true;
                IsWrong = true;
            }
        }

        if(other.gameObject == PPStarLogo)
        {
            if(Order == 2 && StarSelected == false && IsWrong == false)
            {
                Star.color = Selected.color;
                Star2.color = Selected.color;
                Order++;
                StarSelected = true;
            }
            else if(StarSelected == false)
            {
                Star.color = Selected.color;
                Star2.color = Selected.color;
                WrongOrder++;
                StarSelected = true;
                IsWrong = true;
            }
        }
    }
}
