namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Position")]
    public partial class Position
    {
        public int Id { get; set; }

        [Column("Position")]
        [Required]
        [StringLength(150)]
        public string Position1 { get; set; }

        [Required]
        [StringLength(150)]
        public string Company { get; set; }

        [StringLength(150)]
        public string Location { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateApplied { get; set; }

        [StringLength(150)]
        public string Contact { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string URL { get; set; }

        public int PeriodId { get; set; }

        public virtual Period Period { get; set; }
    }
}
