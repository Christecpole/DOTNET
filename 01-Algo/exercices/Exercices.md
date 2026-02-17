# Exercice 1:  Calcul de salaire
- Écrire un algorithme qui demande le nombre d'heures travaillées et le taux horaire, puis calcule le salaire brut, les charges sociales (22%) et le salaire net

# Solution Exercice 1

```
PRINT("Merci de saisir le nombre d'heure")
READ(nombre_heure)
PRINT("Merci de saisir le taux horaire")
READ(taux_horaire)
salaire_brut = nombre_heure * taux_horaire
charge = salaire_brut * 0.22
salaire_net = salaire_brut - charge
PRINT("Salaire BRUT : ")
PRINT(salaire_brut)
PRINT("Charge : ")
PRINT(charge)
PRINT("SALAIRE NET : ")
PRINT(salaire_net)
```

# Solution slide 48 

```
PRINT("Saisir un nombre entier")
READ(nombre_entier)
PRINT(nombre_entier % 3)
IF nombre_entier % 3 = 0 THEN
  PRINT("Multiple de 3")
ELSE
  PRINT("Pas multiple de 3")
ENDIF
```

# solution slide 52

```
PRINT("Nombre de photocopies : ")
READ(nombre_photocopies)
prix_par_copie = 0.3
IF nombre_photocopies < 10 THEN
  prix_par_copie = 0.5
ELSE
  IF nombre_photocopies <= 20 THEN
    prix_par_copie = 0.4
  ENDIF
ENDIF

prix_total = prix_par_copie * nombre_photocopies
PRINT("Prix total : ")
PRINT(prix_total)
```

# Solution slide 53

```
Variables
  c, t, cn: Reel
  n: entier
Debut
  Ecrire "Entrez le capital initial "
  Lire c

  Ecrire "Entrez le taux (ex 0.04 pour un taux de 4%)"
  Lire t

  Ecrire "Entrez le nombre d'année "
  Lire n

  SI n > 0 AND t > 0 AND c > 0 ALORS
    cn <- c * (1+t)^n
    Ecrire "Le capital final est de : ", cn
    Ecrire "Gain : ", cn - c
  SINON
    Ecrire "Merci de saisir des valeurs positives pour n, t et c"
  FINSI
Fin

```



# Solution Slide 54

```
PRINT("Entrer l'age de l'enfant ")
READ(age)

IF age >= 3 and age <= 6 THEN
  PRINT("Baby")
ELSEIF age >=7 and age <= 8 THEN
  PRINT("Poussin")
ELSEIF age >=9 and age <=10 THEN
  PRINT("Pupille")
ELSEIF age >=11 and age <= 12 THEN
  PRINT("Minime")
ELSEIF age >=13 THEN
  PRINT("Cadet")
ELSE
  Print("Age Invalide pour une licence")
ENDIF
``` 

# Solution Slide 55

```
PRINT("Merci de saisir les côtés : ")
READ(AB)
READ(AC)
READ(BC)

IF AB = AC THEN
  IF AC = BC THEN
    PRINT("équilatéral")
  ELSE
    PRINT("Isocèle en A")
  ENDIF
ELSEIF BC = AB THEN
  PRINT("Isocèle en B")
ELSEIF AC = BC THEN
  PRINT("Isocèle en C")
ELSE 
  PRINT("Rien")
ENDIF
```


# Soluion Slide 63

```
PRINT("Merci de saisir un nombre entre 1 et 3 ")
READ(nombre)
WHILE nombre < 1 OR nombre > 3  DO
  PRINT("Saisie erronnée, Recommencez ")
  READ(nombre)
ENDWHILE

PRINT(nombre)
```

# Solution slide 64

```
PRINT("Merci de saisir le capital")
READ(capital)
PRINT("Merci de saisir le taux ")
READ(taux)
capital_initial = capital 
nombre_annee = 0
while(capital < capital_initial * 2) DO 
  capital = capital * (1 + taux)
  nombre_annee = nombre_annee + 1
ENDWHILE

PRINT("Le capital est doublé en " + nombre_annee)

```


# Solution slide 76 

```
PRINT("Table de multiplication : ")
PRINT("Merci de saisir la table : ")
READ(n)
FOR i = 1 TO 10 DO
  resultat = n * i
  PRINT(i + " X " + n + " = " + resultat)
ENDFOR

i = 1 
WHILE i <= 10 DO
  resultat = n * i
  PRINT(i + " X " + n + " = " + resultat)
  i = i + 1
ENDWHILE
```

# Solution slide 77

```
PRINT("Nombre de chiffre ")
READ(limite)
PRINT(limite)
nombre_max = 0
FOR compteur = 1 TO limite DO
  READ(le_nombre_saisi)
  
  IF compteur == 1 OR le_nombre_saisi > nombre_max THEN
    nombre_max = le_nombre_saisi
  ENDIF
  
ENDFOR

PRINT("Le nombre max est " + nombre_max)
```

```
PRINT("Nombre de chiffre ")
READ(limite)

compteur = 1

READ(nombre_saisi)
nombre_max = nombre_saisi
WHILE compteur < limite DO
  READ(nombre_saisi)
  IF nombre_saisi > nombre_max THEN
    nombre_max = nombre_saisi
  ELSE
  ENDIF
  compteur = compteur + 1
ENDWHILE
PRINT("Le nombre max est " + nombre_max)
```

# Solution slide 78


```
PRINT("Nombre de chiffre ")
READ(nombre)
resultat = 0
resultat_chaine = ""
FOR compteur = 1 TO nombre DO
  resultat = resultat + compteur
  If compteur < 2 THEN
    resultat_chaine = compteur
  ELSEIF compteur <= nombre THEN
    resultat_chaine = resultat_chaine + " + " + compteur
  ELSE
    
  ENDIF
ENDFOR

PRINT(resultat_chaine + " = " + resultat)


compteur = 1
WHILE compteur <= nombre DO
  resultat = resultat + compteur
  IF compteur < 2 THEN
     resultat_chaine = compteur
  ELSE
    resultat_chaine = resultat_chaine + " + " + compteur
  ENDIF
  compteur = compteur + 1
ENDWHILE

PRINT(resultat_chaine + " = " + resultat)

```

# solution slide 79 

```
PRINT("Tables de multiplication")
FOR i = 1 TO 10 DO
  PRINT("-------- TABLE de "+ i + " --------")
  FOR j = 1 TO 10 DO
    PRINT( i + " X "+ j + " = " + (i*j))
  ENDFOR
ENDFOR
```