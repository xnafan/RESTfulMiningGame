using GenericDaoLibrary;
using MiningApi.Dtos;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class AuctionConverter
    {
        public static Auction FromDto(this AuctionDto AuctionDto)
        {
            return AuctionDto.CopyPropertiesTo(new Auction());
        }
        public static AuctionDto ToDto(this Auction Auction)
        {
            var auctionDto = Auction.CopyPropertiesTo(new AuctionDto());
            auctionDto.SellerTeamName = Auction.SellerTeam.Name;
            return auctionDto;
        }

        public static IEnumerable<Auction> FromDtos(this IEnumerable<AuctionDto> auctionDtos)
        {
            return auctionDtos.Select(dto => dto.FromDto());
        }
        public static IEnumerable<AuctionDto> ToDtos(this IEnumerable<Auction> Auctions)
        {
            return Auctions.Select(dto => dto.ToDto());
        }
    }
}