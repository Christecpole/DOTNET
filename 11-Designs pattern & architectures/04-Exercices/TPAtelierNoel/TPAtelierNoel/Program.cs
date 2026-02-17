
using TPAtelierNoel.Decorator;
using TPAtelierNoel.Factory;
using TPAtelierNoel.Observer;

Console.WriteLine("TP Atelier Pere Noel");

var atelier = new Atelier();

atelier.EnregistrerFactory("robot", new RobotFactory());
atelier.EnregistrerFactory("gameboy", new GameBoyFactory());
atelier.AjouterLutin(new Lutin("Toto"));
atelier.AjouterLutin(new Lutin("Tata"));


IJouet robot = atelier.ProduireJouet("robot");
IJouet gameBoy = atelier.ProduireJouet("gameboy");

Console.WriteLine("Jouets avant decoration");
Console.WriteLine(robot.GetDescription());
Console.WriteLine(gameBoy.GetDescription());

robot = new Ruban(robot);
gameBoy = new PapierCadeau(new Ruban(gameBoy));

Console.WriteLine("Jouets apres decoration");
Console.WriteLine(robot.GetDescription());
Console.WriteLine(gameBoy.GetDescription());
