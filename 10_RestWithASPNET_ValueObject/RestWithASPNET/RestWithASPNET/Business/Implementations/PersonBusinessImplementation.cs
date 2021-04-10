using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        // AS REGRAS DE NEGÓCIO E AS VALIDAÇÕES DEVEM SER APLICADAS AQUI!

        private readonly IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        // Method responsible for returning all "persons"
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Method responsible for returning a person
        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Method responsible for creating a new person
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person); //Preciso "parsear" o objeto que chega (PersonVO) para poder persisti-lo na base
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for updating a person 
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person); //Preciso "parsear" o objeto que chega (PersonVO) para poder persisti-lo na base
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
