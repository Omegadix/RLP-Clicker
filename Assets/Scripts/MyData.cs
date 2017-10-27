using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * Ce fichier définie seulement la classe MyData pour la sauvegarde
 * Il sera utile pour sauvegarder les achats aussi
 */

[Serializable]
public class MyData {


    public ulong abonnésSAV;
    public ulong APSSAV;
    public ulong MultiClicSAV;


    public int achatClicMultiSAV;
    public int achatFollowerSAV;
    public int achatConnexionInternetSAV;
    public int achatTitrePutaclicSAV;
    public int achatVolerContenuSAV;
    public int achatFeaturingSAV;


    public ulong AjoutMultiClicSAV;
    public ulong AjoutAchatFollowerSAV;
    public ulong AjoutConnexionInternetSAV;
    public ulong AjoutTitrePutaclicSAV;
    public ulong AjoutVolerContenuSAV;
    public ulong AjoutFeaturingSAV;


    public ulong prixMultiClicSAV;
    public ulong prixAchatFollowerSAV;
    public ulong prixConnexionInternetSAV;
    public ulong prixTitrePutaclicSAV;
    public ulong prixVolerContenuSAV;
    public ulong prixFeaturingSAV;

}