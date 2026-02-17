using DemoClasse.Classes;

Dinosaure dino1 = new Dinosaure();
Dinosaure dino2 = new Dinosaure(200,"dino2",6,true,"Carnirvore",1500);
Dinosaure dino3 = new Dinosaure("Dino3",12);

dino2.Nom = "Petit pied";

dino1.AfficheDino();
dino2.AfficheDino();
dino3.AfficheDino();

dino1.Voler();
dino2.Voler();
dino3.Voler();

Dinosaure.AfficherNombreDinosaure();
