using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gaffgc_App.Models
{

    public class LinkTree
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("Id")] // Can not exist without Dna
        public Dna dna { get; set; }

        // Can have many Dna relationships
        public ICollection<Dna> links { get; set; }

        public bool addLink(string dnaId)
        {
            GaffgcDBContext db = new GaffgcDBContext();
            Dna dna = db.DnaStore.Find(dnaId);
            if (dna != null)
            {
                links.Add(dna);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
