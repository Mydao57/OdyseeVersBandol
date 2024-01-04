using UnityEngine;

public class MurScript : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;

    void Start()
    {
        if (ConditionPourFaireDisparaitreMur(wall1))
        {
            wall1.SetActive(true);
        }

        if (ConditionPourFaireDisparaitreMur(wall2))
        {
            wall2.SetActive(false);
        }
    }

    bool ConditionPourFaireDisparaitreMur(GameObject wall)
    {
 //condition des murs => ici
        return true; 
    }
}
