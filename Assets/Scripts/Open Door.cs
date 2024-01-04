using UnityEngine;

public class MurScript : MonoBehaviour
{
    public GameObject WallLeft;
    public GameObject WallRight;

    void Start()
    {
        if (WallLeft != null && ConditionPourFaireDisparaitreMur(WallLeft))
        {
            WallLeft.SetActive(false);
        }

        if (WallRight != null && ConditionPourFaireDisparaitreMur(WallRight))
        {
            WallRight.SetActive(false);
        }
    }

    bool ConditionPourFaireDisparaitreMur(GameObject mur)
    {
        // condition � v�rifier pour faire dispara�tre le mur
        return true; 
    }
}
