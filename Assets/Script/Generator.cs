using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    List<int> generati;

    // Start is called before the first frame update
    void Start()
    {
        var lista = new List<int>();
        for (int i = 0; i < 1500; i++) {
            lista.Add((int)Random.Range(1f, 101f)); 
        }
        int[] matrice =new int [101];
        foreach (var x in lista) {
            matrice[x] += 1;
        }
        string[] nomiRazze = new string[18];
        nomiRazze[0] = "Umani";
        nomiRazze[1] = "Nani";
        nomiRazze[2] = "Elfi";
        nomiRazze[3] = "Gnomi";
        nomiRazze[4] = "Mezzelfi";
        nomiRazze[5] = "Mezzorci";
        nomiRazze[6] = "Halfling";
        nomiRazze[7] = "Rattoidi";
        nomiRazze[8] = "Felinidi";
        nomiRazze[9] = "Grippli";
        nomiRazze[10] = "Coboldi";
        nomiRazze[11] = "Vanara";
        nomiRazze[12] = "Tiefling";
        nomiRazze[13] = "Centauri";
        nomiRazze[14] = "Kitsune";
        nomiRazze[15] = "Goblin";
        nomiRazze[16] = "Tengu";
        nomiRazze[17] = "Asimar";


        int[] razze = new int[18];

        foreach (var selezionato in lista) {
            if (selezionato < 11)
            {
                razze[0] += 1;
            }
            else if (selezionato < 21)
            {
                razze[1] += 1;
            }
            else if (selezionato < 31)
            {
                razze[2] += 1;
            }
            else if (selezionato < 41)
            {
                razze[3] += 1;
            }
            else if (selezionato < 51)
            {
                razze[4] += 1;
            }
            else if (selezionato < 61)
            {
                razze[5] += 1;
            }
            else if (selezionato < 71)
            {
                razze[6] += 1;
            }
            else if (selezionato < 74)
            {
                razze[7] += 1;
            }
            else if (selezionato < 79)
            {
                razze[8] += 1;
            }
            else if (selezionato < 82)
            {
                razze[9] += 1;
            }
            else if (selezionato < 87)
            {
                razze[10] += 1;
            }
            else if (selezionato < 89)
            {
                razze[11] += 1;
            }
            else if (selezionato < 92)
            {
                razze[12] += 1;
            }
            else if (selezionato < 95)
            {
                razze[13] += 1;
            }
            else if (selezionato < 97)
            {
                razze[14] += 1;
            }
            else if (selezionato < 99)
            {
                razze[15] += 1;
            }
            else if (selezionato < 100)
            {
                razze[16] += 1;
            }
            else
            {
                razze[17] += 1;
            }
            
        }
        string messaggio = "Lista Razze:\n";
        for (int i = 0; i < 18; i++) {
            messaggio += nomiRazze[i]+ ": "+razze[i]+"\n";
        }
        Debug.Log(messaggio);
        int total = 0 ;
        foreach (var y in matrice) {
            total += y;
        }

        Debug.Log("Totale: " +total);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
