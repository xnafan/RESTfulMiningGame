using GenericDaoLibrary.Interfaces;
using System;
using System.Collections.Generic;
namespace MiningApi.Dtos;
public class AuctionDto : IIdentifiable<int>
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string SellerTeamName { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}