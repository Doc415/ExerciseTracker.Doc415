using exerciseTracker.doc415.context;
using exerciseTracker.doc415.Models;
using Microsoft.EntityFrameworkCore;

namespace exerciseTracker.doc415.Repository;

internal class ExerciseRepository : IExerciseRepository
{
    ExerciseDbContext _context;

    public ExerciseRepository()
    {
        _context =ExerciseDbContext.GetDbContext();
    }

    public IEnumerable<Exercise> GetAll()
    {
        var exerciseList = _context.Exercies.ToList();
        return exerciseList;
    }
    public Exercise GetById(int id)
    {
        Exercise exercise = _context.Exercies.Find(id);
        return exercise;
    }
    public void Delete(int id)
    {
        var exerciseToDelete = _context.Exercies.Single(x => x.Id == id);
        if (exerciseToDelete != null)
            _context.Remove(exerciseToDelete);
        _context.SaveChanges();
    }
    public void Insert(Exercise exercise)
    {
        _context.Exercies.Add(exercise);
        _context.SaveChanges();
    }
    public void Update(Exercise exercise)
    {
        var exerciseToUpdate = _context.Exercies.Find(exercise.Id);
        if (exerciseToUpdate != null)
        {
            exerciseToUpdate.DateEnd = exercise.DateEnd;
            exerciseToUpdate.DateStart = exercise.DateStart;
            exerciseToUpdate.Duration = exercise.Duration;
            exerciseToUpdate.Comments = exercise.Comments;
        }
        _context.Exercies.Update(exerciseToUpdate);
        _context.Entry(exerciseToUpdate).State = EntityState.Modified;
        _context.SaveChanges();

    }

}
