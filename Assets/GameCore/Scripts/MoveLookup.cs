using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair
{
    public short first, second;
    public Pair(short first, short second)
    {
        this.first = first;
        this.second = second;
    }
};

public class MoveLookup : MonoBehaviour {

     public Dictionary<short, short> Moves = new Dictionary<short, short>()
    {
        {1, 2},
        {1, 10},
        {2, 1},
        {2, 5},
        {2, 3},
        {3, 2},
        {3, 15},
        {4, 5},
        {4, 11},
        {5, 4},
        {5, 8},
        {5, 6},
        {6, 5},
        {6, 14},
        {7, 8},
        {7, 12},
        {8, 7},
        {8, 9},
        {9, 8},
        {9, 13},
        {10, 1},
        {10, 11},
        {10, 22},
        {11, 4},
        {11, 10},
        {11, 12},
        {11, 19},
        {12, 7},
        {12, 11},
        {12, 16},
        {13, 9},
        {13, 14},
        {13, 18},
        {14, 6},
        {14, 13},
        {14, 15},
        {14, 21},
        {15, 3},
        {15, 14},
        {15, 24},
        {16, 12},
        {16, 17},
        {17, 16},
        {17, 18},
        {17, 20},
        {18, 13},
        {18, 17},
        {19, 11},
        {19, 20},
        {20, 17},
        {20, 19},
        {20, 21},
        {20, 23},
        {21, 14},
        {21, 20},
        {22, 10},
        {22, 23},
        {23, 20},
        {23, 22},
        {23, 24},
        {24, 15},
        {24, 23}
    };

    public Dictionary <short, Pair> Mills = new Dictionary<short, Pair>()
    {
        { 1, new Pair(2, 3) },
        { 1, new Pair(10, 22) },
        { 2, new Pair(1, 3) },
        { 2, new Pair(5, 8) },
        { 3, new Pair(1, 2) },
        { 3, new Pair(15, 24) },
        { 4, new Pair(5, 6) },
        { 4, new Pair(11, 19) },
        { 5, new Pair(4, 6) },
        { 5, new Pair(2, 8) },
        { 6, new Pair(4, 5) },
        { 6, new Pair(14, 21) },
        { 7, new Pair(8, 9) },
        { 7, new Pair(12, 16) },
        { 8, new Pair(7, 9) },
        { 8, new Pair(2, 5) },
        { 9, new Pair(7, 8) },
        { 9, new Pair(13, 18) },
        { 10, new Pair(11, 12) },
        { 10, new Pair(1, 22) },
        { 11, new Pair(10, 12) },
        { 11, new Pair(4, 19) },
        { 12, new Pair(10, 11) },
        { 12, new Pair(7, 16) },
        { 13, new Pair(14, 15) },
        { 13, new Pair(9, 18) },
        { 14, new Pair(13, 15) },
        { 14, new Pair(6, 21) },
        { 15, new Pair(13, 14) },
        { 15, new Pair(3, 24) },
        { 16, new Pair(17, 18) },
        { 16, new Pair(7, 12) },
        { 17, new Pair(16, 18) },
        { 17, new Pair(20, 23) },
        { 18, new Pair(16, 17) },
        { 18, new Pair(9, 13) },
        { 19, new Pair(20, 21) },
        { 19, new Pair(4, 11) },
        { 20, new Pair(19, 21) },
        { 20, new Pair(17, 23) },
        { 21, new Pair(19, 20) },
        { 21, new Pair(6, 14) },
        { 22, new Pair(23, 24) },
        { 22, new Pair(1, 10) },
        { 23, new Pair(22, 24) },
        { 23, new Pair(17, 20) },
        { 23, new Pair(22, 23) },
        { 23, new Pair(3, 15) },
    };



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
