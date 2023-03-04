using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiTrain.Entities
{

    public class Author
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }


    }

}