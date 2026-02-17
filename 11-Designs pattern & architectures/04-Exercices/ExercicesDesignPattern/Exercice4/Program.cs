
using Exercice4;

Console.WriteLine("Exercice 4");

//AnimalFactory factory = new ChatFactory();
//IAnimal cat = factory.CreateAnimal();
//cat.Speak();

//AnimalFactory factory1 = new ChienFactory();
//IAnimal dog = factory1.CreateAnimal();
//dog.Speak();

var bigFactory  = new BigFactory();
bigFactory.AjouterFactory("chat", new ChatFactory());
bigFactory.AjouterFactory("chien", new ChienFactory());


var a1 = bigFactory.ProduireAnimal("chat");
a1.Speak();

var a2 = bigFactory.ProduireAnimal("chien");
a2.Speak();

var a3 = bigFactory.ProduireAnimal("hamster");