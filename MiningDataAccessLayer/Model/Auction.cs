﻿using GenericDaoLibrary.Interfaces;

namespace MiningDataAccessLayer.Model;
public class Auction : IIdentifiable<int>
{
    public int Id { get; set; }
    public Team SellerTeam { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Price { get; set; }
}