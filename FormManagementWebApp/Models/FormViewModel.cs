
namespace FormManagementWebApp.Models.ViewModels
{
    public class FormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public List<FieldViewModel> Fields { get; set; }
    }

    public class FieldViewModel
    {
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}