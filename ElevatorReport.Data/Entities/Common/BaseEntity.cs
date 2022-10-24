using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.Common
{
    public class BaseEntity<TKey> : IEntity<TKey>
    {
        [Column(Order = 201)]
        public TKey Id { get; set; }

        [DefaultValue(RepositoryDefaults.DefaultEntityStatus)]
        [Required(ErrorMessage = "Lütfen boş bırakmayınız")]
        public virtual int StatusId { get; set; } = (int)EntityStatus.Active;

        [NotMapped]
        public virtual string StatusText { get; set; } = string.Empty;

        [Display(Name = "Oluşturulma Tarihi")]
        [Column(Order = 202)]
        public virtual DateTime CreatedOn { get; set; }

        [Column(Order = 203)]
        public virtual Guid CreatedBy { get; set; }

        [NotMapped]
        [Display(Name = "Oluşturan")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual Guid CreatedByUser { get; set; }

        [NotMapped]
        [Display(Name = "Oluşturan")]
        public virtual string CreatedByUserFullname { get; set; } = string.Empty;

        [Display(Name = "Güncellenme Tarihi")]
        [Column(Order = 204)]
        public virtual DateTime ModifiedOn { get; set; }

        [Column(Order = 205)]
        public virtual Guid ModifiedBy { get; set; }

        [NotMapped]
        [Display(Name = "Güncelleyen")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual Guid ModifiedByUser { get; set; }

        [NotMapped]
        [Display(Name = "Güncelleyen")]
        public virtual string ModifiedByUserFullname { get; set; } = string.Empty;
    }

    public class BaseEntity : BaseEntity<Guid>
    {
    }
}
