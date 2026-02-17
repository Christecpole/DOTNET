// See https://aka.ms/new-console-template for more information
using Exercice3;

Console.WriteLine("Exercice 3");


var event1 = new EventManager();
event1.AddObserver(new ConsoleLogger());
event1.AddObserver(new FileLogger());
event1.AddObserver(new MailObserver());

event1.CreateEvent("Repas d'entreprise demain");

var event2 = new EventManager();
event2.AddObserver(new ConsoleLogger());
event2.AddObserver(new MailObserver());

event2.CreateEvent("Un evenement est survenue !!!!");