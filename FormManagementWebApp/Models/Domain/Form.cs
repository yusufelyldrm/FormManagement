namespace FormManagementWebApp.Models.Domain;

//{"id": 1, "name": "Test form", "description": "",createdAt: "2017-01-08", createdBy: 1 , fields: [ { "required": true, "name": "Ad", dataType: "STRING" }, { "required": true, "name": "Soyad", dataType: "STRING" },{ "required": false, "name": "Yaş", dataType: "NUMBER" } ] }

public class Form
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    
    public ICollection<Field> Fields { get; set; }       
}

public class Field
{
    public Guid Id { get; set; }
    public bool Required { get; set; }
    public string Name { get; set; }
    public DataType DataType { get; set; }
}

public enum DataType
{
    STRING,
    NUMBER,
    DATE
}