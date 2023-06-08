using UnityEngine;

public class MixableColor : MonoBehaviour
{
    public Material drinkMat;
    Renderer rend;
    public float colorStrength;
    void Start()
    {
        rend = GetComponent<Renderer>();
        drinkMat = rend.material;
        colorStrength = 0.05f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Liquid")
        {
            MixColor(other);
        }
        if (other.transform.tag == "Liquid") 
        {
            MixColor(other);
        }
    }
    private void MixColor(Collider other)
    {
        Color newCol = new Color(0, 0, 0);
        Material liquidMat = other.gameObject.GetComponent<Renderer>().material;

        if (liquidMat.color.r == 1 && liquidMat.color.g == 1 && liquidMat.color.b == 1) //color of liquid is white
        {
            newCol.r = colorStrength;
            newCol.g = colorStrength;
            newCol.b = colorStrength;
            if (drinkMat.color.r + newCol.r < 1 || drinkMat.color.g + newCol.g < 1 || drinkMat.color.b + newCol.b < 1)
            drinkMat.color += newCol;
            newCol = new Color(0, 0, 0);
        }
        else if (liquidMat.color.r == 0 && liquidMat.color.g == 0 && liquidMat.color.b == 0) //color of liquid is black
        {
            newCol.r = -colorStrength;
            newCol.g = -colorStrength;
            newCol.b = -colorStrength;
            drinkMat.color += newCol;
            newCol = new Color(0, 0, 0);
        }
        else
        {
            if (liquidMat.color.r > 0) //color of liquid is red
            {
                newCol.r = colorStrength;
                newCol.g = -colorStrength / 2;
                newCol.b = -colorStrength / 2;
                if (drinkMat.color.r + newCol.r > 1)
                {
                    newCol.r = 0;
                    drinkMat.color += newCol;
                }
                drinkMat.color += newCol;
                newCol = new Color(0, 0, 0);
            }
            if (liquidMat.color.g > 0) //color of liquid is green
            {
                newCol.r = -colorStrength / 2;
                newCol.g = colorStrength;
                newCol.b = -colorStrength / 2;
                if (drinkMat.color.g + newCol.g > 1)
                {
                    newCol.g = 0;
                    drinkMat.color += newCol;
                }
                drinkMat.color += newCol;
                newCol = new Color(0, 0, 0);
            }
            if (liquidMat.color.b > 0) //color of liquid is blue
            {
                newCol.r = -colorStrength / 2;
                newCol.g = -colorStrength / 2;
                newCol.b = colorStrength;
                if (drinkMat.color.b + newCol.b > 1)
                {
                    newCol.b = 0;
                    drinkMat.color += newCol;
                }
                drinkMat.color += newCol;
                newCol = new Color(0, 0, 0);
            }

        }
    }
}

//Update: Used neither of the below systems, but I'll keep them here as comments. To show process.

//WIP color mixing system. still getting gross browns.
//if (liquidMat.color.r < 1)
//{
//    newCol.r = colorStrength;
//    newCol.g = -colorStrength;
//    newCol.b = -colorStrength;
//    drinkMat.color += newCol;
//    newCol = new Color(0, 0, 0);
//}
//if (liquidMat.color.g < 1)
//{
//    newCol.r = -colorStrength;
//    newCol.g = colorStrength;
//    newCol.b = -colorStrength;
//    drinkMat.color += newCol;
//    newCol = new Color(0, 0, 0);
//}
//if (liquidMat.color.b < 1)
//{
//    newCol.r = -colorStrength;
//    newCol.g = -colorStrength;
//    newCol.b = colorStrength;
//    drinkMat.color += newCol;
//    newCol = new Color(0, 0, 0);
//}
//currently working system
//liquidMat.color = Color.Lerp(liquidMat.color, drinkMat.color, 1f);