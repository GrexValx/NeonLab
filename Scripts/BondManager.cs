//va dentro de assets Create → C# Script en unity y se llama BondManager.cs

using System.Collections.Generic;
using UnityEngine;

public class BondManager : MonoBehaviour
{
    public List<Atom> nearbyAtoms = new List<Atom>();
    public GameObject waterMoleculePrefab;

    void Update()
    {
        CheckForWater();
    }

    void CheckForWater()
    {
        int hCount = 0;
        int oCount = 0;

        foreach (Atom atom in nearbyAtoms)
        {
            if (atom.elementType == "H") hCount++;
            if (atom.elementType == "O") oCount++;
        }

        if (hCount >= 2 && oCount >= 1)
        {
            CreateWater();
        }
    }

    void CreateWater()
    {
        Debug.Log("¡Agua creada!");

        Vector3 center = Vector3.zero;

        foreach (Atom atom in nearbyAtoms)
        {
            center += atom.transform.position;
            Destroy(atom.gameObject);
        }

        center /= nearbyAtoms.Count;

        Instantiate(waterMoleculePrefab, center, Quaternion.identity);

        nearbyAtoms.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        Atom atom = other.GetComponent<Atom>();

        if (atom != null && !nearbyAtoms.Contains(atom))
        {
            nearbyAtoms.Add(atom);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Atom atom = other.GetComponent<Atom>();

        if (atom != null && nearbyAtoms.Contains(atom))
        {
            nearbyAtoms.Remove(atom);
        }
    }
}