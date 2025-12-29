using BethanysPieShopHRM.Shared.Domain;

namespace PieShopHRM.Services;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int id);
}