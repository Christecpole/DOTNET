
using DemoDesignPattern.Behavorial.Observer;
using DemoDesignPattern.Creational.Builder;
using DemoDesignPattern.Creational.FactoryMethod;
using DemoDesignPattern.Strucutural.Decorator;

Console.WriteLine("Demo Design Pattern");

//Person person = new Person.Builder()
//    .LastNameValue("Dupont")
//    .AgeValue(42)
//    .FirstNameValue("Marie")
//    .Build();

//Console.WriteLine(person);

//var person2 = new Person.Builder()
//    .AgeValue (43)
//    .Build ();
//Console.WriteLine(person2);

//var person3 = new Person.Builder()
//    .FirstNameValue("toto")
//    .LastNameValue("tata")
//    .Build();
//Console.WriteLine(person3);

//IPizza pizza = new PlainPizza();
//pizza = new CheeseDecorator(pizza);
//pizza = new OliveDecorator(pizza);

//Console.WriteLine(pizza.GetDescription());
//Console.WriteLine(pizza.GetCost());

//IPizza pizza1 = new PlainPizza();

//Console.WriteLine(pizza1.GetDescription());
//Console.WriteLine(pizza1.GetCost());

//IPizza pizza2 = new PlainPizza();
//pizza2 = new OliveDecorator(pizza2);

//Console.WriteLine(pizza2.GetDescription());
//Console.WriteLine(pizza2.GetCost());

//var subject = new Subject();
//subject.AddObserver(new MyObserver("Espion 1"));
//subject.AddObserver(new MyObserver("Espion 2"));


//subject.NotifyObservers("Hello World !!!");

VehicleFactory factory = new CarFactory();

var vehicle = factory.CreateVehicle();
vehicle.Drive();

factory = new TruckFactory();
vehicle = factory.CreateVehicle();
vehicle.Drive();


