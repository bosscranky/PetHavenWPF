using Newtonsoft.Json;
using PetHaven.Domain;
using PetHaven.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHavenWPF.DataLayer
{
    public class PetHavenDataLayer : IPetDataLayer
    {
        private List<BasePet> Pets { get; } = new List<BasePet>();

        public PetHavenDataLayer()
        {
            ReadPets();
        }

        public List<BasePet> FindAllPets()
        {
            return Pets.ToList();
        }

        public List<BasePet> FindPetsByName(string name)
        {
            return Pets.FindAll(pet => pet.Name.StartsWith(name)).ToList();
        }

        public BasePet SavePet(BasePet pet)
        {
            pet.Id = Pets.Count + 1;

            Pets.Add(pet);

            return pet;
        }

        private void ReadPets()
        {
            ReadPetType<Dog>("Dogs");
            ReadPetType<Cat>("Cats");
            ReadPetType<Lizard>("Lizards");
            ReadPetType<Snake>("Snakes");
        }

        private void ReadPetType<T>(string name) where T : BasePet
        {
            string rawContents = File.ReadAllText(@"./TestData/" + name + ".json");

            var localPets = JsonConvert.DeserializeObject<List<T>>(rawContents);

            if (localPets != null && localPets.Count > 0)
            {
                Pets.AddRange(localPets);
            }

            
        }
}
}
