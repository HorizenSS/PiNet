namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.userskill")]
    public partial class userskill
    {
        public long id { get; set; }

        public int level { get; set; }

        public long? skill_id { get; set; }

        public long? user_id { get; set; }

        public virtual skill skill { get; set; }

        public virtual utilisateur utilisateur { get; set; }
    }
}
