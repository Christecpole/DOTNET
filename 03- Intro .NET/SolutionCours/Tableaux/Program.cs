using System;

#region Tableau

int[] TableauInt = new int[5];

string[] TableauString = new string[5];

char[] TableauChar = {'a','b','c','d','e'};

TableauString[0] = "1er Element";

foreach (var i in TableauChar)
{
    Console.WriteLine(i);
}


#endregion

#region Copy

//int[] T1 = { 1, 2, 3 };
//int[] T2;
//T2 = T1;
//T1[0] = 100;
//foreach(var i in T2)
//{
//    Console.WriteLine(i); 
//}

int[] T1 = { 1, 2, 3 };
int[] T2 = new int[5];
T1.CopyTo(T2,0);
T1[0] = 100;
foreach (var i in T2)
{
    Console.WriteLine(i);
}

int[] T3 = { 1, 2, 3 };
int[] T4 = (int[]) T3.Clone();
T3[0] = 100;
foreach (var i in T4)
{
    Console.WriteLine(i);
}

#endregion