﻿using CRepublic.Royale.Files.CSV_Helpers;
using CRepublic.Royale.Files.CSV_Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRepublic.Royale.Files.CSV_Logic
{
    internal class Globals : Data
    {
        internal Globals(Row _Row, DataTable _DataTable) : base(_Row, _DataTable)
        {
            Load(_Row);
        }

        // NOTE: This was generated from the globals.csv using gen_csv_properties.py script.

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Number value.
        /// </summary>
        public int NumberValue { get; set; }

        /// <summary>
        /// Gets or sets Boolean value.
        /// </summary>
        public bool BooleanValue { get; set; }

        /// <summary>
        /// Gets or sets Text value.
        /// </summary>
        public string TextValue { get; set; }

        /// <summary>
        /// Gets or sets String array.
        /// </summary>
        public string StringArray { get; set; }

        /// <summary>
        /// Gets or sets Number array.
        /// </summary>
        public int NumberArray { get; set; }
    }
}