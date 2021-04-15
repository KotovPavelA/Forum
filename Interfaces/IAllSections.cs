﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interfaces
{
    public interface IAllSections
    {
        IEnumerable<Section> GetAllSectionsForList { get; }
        IEnumerable<QSection> GetGetQSections();
        Section FindSectionById(int i);
        QSection FindQSectionById(int i);
        


    }
}
