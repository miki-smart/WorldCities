﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCities.Server.Data.Models
{
    [Table("Countries")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(ISO2), IsUnique = true)]
    [Index(nameof(ISO3), IsUnique = true)]
    public class Country
    {
        #region Properties
        /// <summary>
        /// The unique id and primary key for this Country
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }/// <summary>
                                   /// Country name (in UTF8 format)
                                   /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Country code (in ISO 3166-1 ALPHA-2 format)
        /// </summary>
        public required string ISO2 { get; set; }
        /// <summary>
        /// Country code (in ISO 3166-1 ALPHA-3 format)
        /// </summary>
        public required string ISO3 { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// A collection of all the cities related to this country.
        /// </summary>
        public ICollection<City>? Cities { get; set; }
        #endregion
    }
}
