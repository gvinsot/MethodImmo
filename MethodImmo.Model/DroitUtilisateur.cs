﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Model
{
    public class DroitUtilisateur
    {
        public long Id;
        public Immeuble ImmeubleConcerne;
        public TypeDeDroitUtilisateur TypeDeDroit;
        public GroupeDePersonnes UtilisateursConcerne;
    }
}