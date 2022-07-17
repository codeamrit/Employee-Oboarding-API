using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class EmployeeModel
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [JsonIgnore]
        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string? EmpId { get; set; }

        //[Required]
        public string? Adress { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }
        public int Pincode { get; set; }
        public string Title { get; set; }
        public int Dob { get; set; }

        //[Required]
        public string? Namefirst { get; set; }

        //[Required]
        public string? Namelast { get; set; }

        public string? ProfilePicture { get; set; }
        public string? EducationalDocument { get; set; }
        public string? Department { get; set; }
        //[Required]
        public int ContactNumber { get; set; }

        [EmailAddress]
        public string? EmailId { get; set; }
    }
}
