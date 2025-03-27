using TraineeManagementSystem.Models;

namespace TraineeManagementSystem.Database
{
    public class InmemoryDatabase
    {
        public List<Trainee> db;
        public InmemoryDatabase()
        {
            db = new List<Trainee>
            {
                    new Trainee { Id = 1, Name = "Owajeul Islam", University = "Islamic University", Technology = "ASP.NET Core", Phone = "01791233445", Email = "owajeul@gmail.com" },
                    new Trainee { Id = 2, Name = "Nahid", University = "Daffodil University", Technology = "ASP.NET Core", Phone = "0987654321", Email = "Nahid@gmail.com" },
            };

        }

        public List<Trainee> Get()
        {
            return db;
        }

        public Trainee Get(int Id)
        {
            return db.FirstOrDefault(t => t.Id == Id);
        }
        public void Add(Trainee trainee)
        {
            trainee.Id = db.Max(t => t.Id) + 1;
            db.Add(trainee);
        }

        public void Remove(Trainee trainee)
        {
            db.Remove(trainee);
        }

        public void Update(Trainee trainee)
        {
            var traineeToUpdate = db.FirstOrDefault(t =>  t.Id == trainee.Id);
            if(traineeToUpdate != null)
            {
                traineeToUpdate.Name = trainee.Name;
                traineeToUpdate.University = trainee.University;
                traineeToUpdate.Name = trainee.Name;
                traineeToUpdate.Phone = trainee.Phone;
                traineeToUpdate.Email = trainee.Email;
                traineeToUpdate.Technology = trainee.Technology;
            }
        }

        
    }
}
