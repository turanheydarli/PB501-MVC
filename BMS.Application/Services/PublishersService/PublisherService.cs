using BMS.Application.Services.PublishersService.Abstractions;
using BMS.Application.Services.PublishersService.DTOs;
using BMS.Application.Services.PublishersService.Models;
using BMS.Data.Models;
using BMS.Data.Persistence.Contexts;
using BMS.Data.Persistence.Repositories;


namespace BMS.Application.Services.PublishersService;

public class PublisherService : IPublisherService
{
    private readonly IRepository<Publisher, MsSqlDbContext> _repository;

    public PublisherService(IRepository<Publisher, MsSqlDbContext> repository)
    {
        _repository = repository;
    }

    public PublisherListModel GetPublisherList()
    {
        var categories = _repository.GetList();

        var categoriesDto = categories.Select(b => new PublisherDto(b.Id, b.CreatedAt, b.UpdatedAt, b.Name));

        var categoryListModel = new PublisherListModel()
        {
            Items = categoriesDto.ToList()
        };

        return categoryListModel;
    }

    public PublisherDto GetPublisherById(int publisherId)
    {
        Publisher author = _repository.Get(b => b.Id == publisherId);

        if (author == null)
        {
            throw new Exception();
        }

        return new PublisherDto(author.Id, author.CreatedAt, author.UpdatedAt, author.Name);
    }

    public PublisherCreatedDto CreatePublisher(Publisher publisher)
    {
        Publisher createdPublisher = _repository.Add(publisher);

        return new PublisherCreatedDto(
            createdPublisher.Id,
            createdPublisher.CreatedAt,
            createdPublisher.UpdatedAt,
            createdPublisher.Name);
    }

    public PublisherUpdatedDto UpdatePublisher(Publisher publisher)
    {
        Publisher publisherToUpdate = _repository.Get(b => b.Id == publisher.Id);

        publisherToUpdate.Name = publisher.Name;
        publisherToUpdate.UpdatedAt = DateTime.UtcNow;

        _repository.Update(publisherToUpdate);

        return new PublisherUpdatedDto(
            publisherToUpdate.Id,
            publisherToUpdate.CreatedAt,
            publisherToUpdate.UpdatedAt,
            publisherToUpdate.Name);
    }

    public void DeletePublisher(Publisher publisher)
    {
        Publisher deletedPublisher = _repository.Get(b => b.Id == publisher.Id);

        _repository.Delete(deletedPublisher);
    }
}