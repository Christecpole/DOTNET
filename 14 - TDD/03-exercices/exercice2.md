## Exercice 2

- Le but de l'exercice est de réaliser des tests unitaire en utilisant mstest pour la classe fournie

```cs
public class Fib
{
    private int _range;

    public Fib(int r)
    {
        _range = r;
    }

    public List<int> GetFibSeries()
    {
        List<int> result = new List<int>();
        int a = 0, b = 1, c = 0;
        if (_range == 1)
        {
            result.Add(0);
            return result;
        }
        result.Add(0);
        result.Add(1);
        for (int i = 2; i < _range; i++)
        {
            c = a + b;
            result.Add(c);
            a = b;
            b = c;
        }
        return result;
    }
}
```

- Lors du déclanchement de la fonction GetFibSeries() avec un Range de 1 
  - Le résultat n’est pas vide
  - Le résultat correspond à une liste qui contient {0}
- Lors du déclanchement de la fonction GetFibSeries() avec un Range de 6 
  - Le résultat contient le chiffre 3 
  - Le résultat contient 6 éléments 
  - Le résultat n’a pas le chiffre 4 en son sein 
  - Le résultat correspond à une liste qui contient {0, 1, 1, 2, 3, 5}
  - Le résultat est trié de façon ascendance 