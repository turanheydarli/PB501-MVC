using BMS.Application.Services.PublishersService.DTOs;
using BMS.Domain.Models;

namespace BMS.Application.Services.PublishersService.Abstractions;

public interface IPublisherService
{
    PublisherDto GetPublisherById(int publisherId);
    PublisherCreatedDto CreatePublisher(Publisher publisher);
    PublisherUpdatedDto UpdatePublisher(Publisher publisher);
    void DeletePublisher(Publisher publisher);
}