namespace LIBRARY_SYSTEM_PRACTICE.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string CategoryName { get; set; } = string.Empty;
        public int BookCount { get; set; }
        public string CategoryDescription { get; set; }
    }
}
