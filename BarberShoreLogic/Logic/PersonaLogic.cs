using BarberEntity.Entity;
using BarberShoreLogic.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShoreLogic.Logic
{
    public class PersonaLogic
    {
        BarberShoreDataBaseContext barberShoreDataBaseContext = new BarberShoreDataBaseContext();


        public List<PersonaEntity> GetAllPerson(string name = "")
        {
            var listPersonEntites = new List<PersonaEntity>();

            var listPersonDataBase = new List<Persona>();

            if (string.IsNullOrEmpty(name))
            {
                listPersonDataBase = barberShoreDataBaseContext.Personas.ToList();
            }
            else
            {
                listPersonDataBase = barberShoreDataBaseContext.Personas.Where(x => x.Nombre.ToUpper().Contains(name.ToUpper())).ToList();
            }

            foreach (var peronDataBase in listPersonDataBase)
            {
                listPersonEntites.Add(ConvertPersonaDataBaseToPersonaEntity(peronDataBase));
            }

            return listPersonEntites;
        }


        public PersonaEntity AddPerson(PersonaEntity personaEntity)
        {
            try
            {

                if (GetAllPerson().Where(x => x.Cedula == personaEntity.Cedula).Any())
                {
                    PersonaEntity persona = new PersonaEntity();
                    persona.Message = "Ya existe un usuario con esa Cedula";
                    persona.Type = "danger";
                    return persona;
                }


                barberShoreDataBaseContext.Personas.Add(ConvertPersonaEntityToPersonaDataBase(personaEntity));
                barberShoreDataBaseContext.SaveChanges();
                personaEntity.Message = "La Persona fue guardada con exito";
                personaEntity.Type = "success";
                return personaEntity;
            }
            catch (Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = ex.Message;
                return persona;
            }

        }

        public PersonaEntity GetPersonForCedula(string cedula)
        {
            var personEntity = GetAllPerson().Where(x => x.Cedula == cedula).FirstOrDefault();

            if (personEntity == null)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = "No existe  una persona  con esa cedula";
                persona.Type = "danger";
                return persona;
            }

            return personEntity;
        }


        public PersonaEntity UpdatePerson(PersonaEntity personaEntity)
        {
            try
            {
                var personDataBase = barberShoreDataBaseContext.Personas.Where(x => x.Cedula == personaEntity.Cedula).FirstOrDefault();

                if (personDataBase == null)
                {
                    PersonaEntity persona = new PersonaEntity();
                    persona.Message = "No existe  una persona  con esa cedula";
                    persona.Type = "danger";
                    return persona;
                }

                personDataBase.Cedula = personaEntity.Cedula;
                personDataBase.Nombre = personaEntity.Nombre;
                personDataBase.Celular = personaEntity.Celular;
                personDataBase.Correo = personaEntity.Correo;
                personDataBase.Contraseña = personaEntity.Contraseña;


                barberShoreDataBaseContext.Personas.Update(personDataBase);
                barberShoreDataBaseContext.SaveChanges();
                personaEntity.Message = "La Persona fue actualizada con exito";
                personaEntity.Type = "success";
                return personaEntity;
            }
            catch (Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = ex.Message;
                return persona;
            }

        }

        public PersonaEntity DeletePerson(string cedula)
        {
            try
            {
                var personDataBase = barberShoreDataBaseContext.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();

                if (personDataBase == null)
                {
                    PersonaEntity persona = new PersonaEntity();
                    persona.Message = "No existe  una persona  con esa cedula";
                    persona.Type = "danger";
                    return persona;
                }

                PersonaEntity personaEntity = new PersonaEntity();
                barberShoreDataBaseContext.Personas.Remove(personDataBase);
                barberShoreDataBaseContext.SaveChanges();
                personaEntity.Message = "La Persona fue eliminada con exito";
                personaEntity.Type = "success";
                return personaEntity;
            }
            catch (Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = ex.Message;
                return persona;
            }
        }

        private Persona ConvertPersonaEntityToPersonaDataBase(PersonaEntity personaEntity)
        {
            Persona persona = new Persona();
            persona.Cedula = personaEntity.Cedula;
            persona.Nombre = personaEntity.Nombre;
            persona.Celular = personaEntity.Celular;
            persona.Correo = personaEntity.Correo;
            persona.Contraseña = personaEntity.Contraseña;

            return persona;
        }


        private PersonaEntity ConvertPersonaDataBaseToPersonaEntity(Persona persona)
        {
            PersonaEntity personaEntity = new PersonaEntity();
            personaEntity.Cedula = persona.Cedula;
            personaEntity.Nombre = persona.Nombre;
            personaEntity.Celular = persona.Celular;
            personaEntity.Correo = persona.Correo;
            personaEntity.Contraseña = persona.Contraseña;

            return personaEntity;
        }


    }
}
