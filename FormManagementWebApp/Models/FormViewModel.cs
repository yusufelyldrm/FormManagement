

namespace FormManagementWebApp.Models.ViewModels
{
    public class FormRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public List<FieldRequestModel> Fields { get; set; }
    }

    public class FieldRequestModel
    {
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }

}