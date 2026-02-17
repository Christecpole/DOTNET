// See https://aka.ms/new-console-template for more information
using Exercice2;

Console.WriteLine("Exercice 2");


IText personalisation = new PlainText();
personalisation = new PrefixDecorator(personalisation, "[ ALERT ] ");
personalisation = new UpperCaseDecorator(personalisation);


Console.WriteLine(personalisation.Transform("coucou"));
Console.WriteLine(personalisation.Transform("hello"));


IText personalisation2 = new PlainText();
personalisation2 = new PrefixDecorator(personalisation2, "/\\ DANGER /\\ ");

Console.WriteLine(personalisation2.Transform("coucou"));
Console.WriteLine(personalisation2.Transform("hello"));