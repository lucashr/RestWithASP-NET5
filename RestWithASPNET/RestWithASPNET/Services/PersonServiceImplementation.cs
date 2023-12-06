﻿using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Services.Implementation;
using System;

namespace RestWithASPNET.Services
{
    public class PersonServiceImplementation : IPersonService
    {

        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id)!;
        }

        public Person Create(Person person)
        {

            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;

        }

        public Person Update(Person person)
        {

            if (!Exists(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id)!;

            if (result != null)
            {

                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            return person;
        }

        public void Delete(long id)
        {

            var result = _context.Persons.SingleOrDefault(p => p.Id == id)!;

            if (result != null)
            {

                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Equals(id));
        }

    }
}
