namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.questionresponse")]
    public partial class questionresponse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public questionresponse()
        {
            userquizresponse = new HashSet<userquizresponse>();
        }

        public long id { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        [Column(TypeName = "bit")]
        public bool isCorrect { get; set; }

        public int? question_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userquizresponse> userquizresponse { get; set; }

        public virtual quizquestion quizquestion { get; set; }
    }
}
