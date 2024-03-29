﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;


namespace Library.Interfaces
{
    public interface IRaceRepository
    {
        Task AddRace(Race race);
        Task<Race> GetRaceByID(int id);
        Task<List<Race>> GetRaces();
        Task<List<Race>> GetRacesByTitle(string title);
        Task UpdateRace(Race race);
        Task DeleteRace(Race race);
    }
}
