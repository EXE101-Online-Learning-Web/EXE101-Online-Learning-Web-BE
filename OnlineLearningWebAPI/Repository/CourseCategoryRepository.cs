using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class CourseCategoryRepository : IRepository<CourseRepository>
    {
        public Task AddAsync(CourseRepository entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CourseRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseRepository>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseRepository?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CourseRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
