
//1-08", createdBy: 1 , fields: [ { "required": true, "name": "Ad", dataType: "STRING" }, { "required": true, "name": "Soyad", dataType: "STRING" },{ "required": false, "name": "Yaş", dataType: "NUMBER" } ] }
namespace FormManagementWebApp.Models.Domain
{
    public class Form
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

        public List<Field> Fields { get; set; } 
    }

    public class Field
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DataTypeEnum DataType { get; set; }
        public bool Required { get; set; }

        // Form referansı
        public Guid FormId { get; set; }
        public Form Form { get; set; }
    }
    
    public enum DataTypeEnum
    {
        STRING,
        NUMBER,
        DATE,
        BOOLEAN
    }
}