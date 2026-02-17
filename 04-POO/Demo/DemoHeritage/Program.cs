using Demo03Heritage.Classes;

Chien toutou = new Chien("toutou",2,"chien","os");

toutou.Crier();
toutou.Manger();

Chat chat = new Chat("chat",4,"felin");
chat.Crier();
chat.Manger();

//Console.WriteLine(chat);
//Console.WriteLine(toutou);


Animal[] animals = new Animal[2];

animals[0] = chat;
animals[1] = toutou;

foreach(Animal animal in animals)
{
    Console.WriteLine(animal);
}
