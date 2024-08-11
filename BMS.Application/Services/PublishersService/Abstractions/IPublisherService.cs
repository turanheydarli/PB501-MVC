using BMS.Application.Services.PublishersService.DTOs;
using BMS.Application.Services.PublishersService.Models;
using BMS.Data.Models;

namespace BMS.Application.Services.PublishersService.Abstractions;

public interface IPublisherService
{
    PublisherListModel GetPublisherList();
    PublisherDto GetPublisherById(int publisherId);
    PublisherCreatedDto CreatePublisher(Publisher publisher);
    PublisherUpdatedDto UpdatePublisher(Publisher publisher);
    void DeletePublisher(Publisher publisher);
}