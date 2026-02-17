using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoInterface.Classe
{
    internal interface IPayement
    {
        string EffectuerPaiement(double montant);
    }
}
