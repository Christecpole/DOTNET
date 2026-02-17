using Demo04Abstraction.Classes;


Piano piano = new Piano("Piano1","corde");
Violon violon = new Violon("violon 2","corde");

Instrument[] instruments = {piano,violon};

foreach (Instrument instr in instruments)
{
    instr.Jouer();
    instr.Reparer();
    
    if(instr is Violon violon1)
    {
        violon1.JouerDeLArchet();
    }
}