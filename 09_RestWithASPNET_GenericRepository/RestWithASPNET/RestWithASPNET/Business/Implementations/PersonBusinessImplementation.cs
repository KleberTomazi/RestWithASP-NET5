﻿using RestWithASPNET.Models;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        // AS REGRAS DE NEGÓCIO E AS VALIDAÇÕES DEVEM SER APLICADAS AQUI!

        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        // Method responsible for returning all "persons"
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for returning a person
        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        // Method responsible for creating a new person
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        // Method responsible for updating a person 
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
