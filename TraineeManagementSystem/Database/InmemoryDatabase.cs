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
                    new Trainee { Id = 1, Name = "John Doe", University = "XYZ University", Technology = "C#", Phone = "1234567890", Email = "john.doe@example.com" },
                    new Trainee { Id = 2, Name = "Jane Smith", University = "ABC University", Technology = "JavaScript", Phone = "0987654321", Email = "jane.smith@example.com" },
                    new Trainee { Id = 3, Name = "Sam Wilson", University = "DEF University", Technology = "Python", Phone = "1122334455", Email = "sam.wilson@example.com" }
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
            }
        }
    }
}
