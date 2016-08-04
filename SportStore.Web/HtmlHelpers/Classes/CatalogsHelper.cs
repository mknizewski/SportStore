using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Catalog;
using SportStore.Web.Models.Home;
using SportStore.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Web.HtmlHelpers.Classes
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa pomocniczna do przegladania produktów
    /// Data:   26.11.15
    /// </summary>
    public class CatalogsHelper : ICatalogHelper, IDisposable
    {
        public ICatalogsRepository _catalogRepository;
        private static int _pageSize = 9; // defaultowo 9

        public CatalogsHelper(ICatalogsRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        IEnumerable<_dict_catalogs> ICatalogHelper.GetCatalogs()
        {
            return _catalogRepository.Catalogs;
        }

        Models.Catalog.ProductsListViewModel ICatalogHelper.GetItemsByCatalog(int catalogId, int page)
        {
            var currentCatalog = _catalogRepository.Catalogs
                                .Select(x => x)
                                .Where(x => x.Id.Equals(catalogId))
                                .FirstOrDefault();

            var viewModel = new ProductsListViewModel
            {
                Items = _catalogRepository.Items
                        .Where(x => x.Id_Category.Equals(catalogId))
                        .OrderBy(x => x.Id)
                        .Skip((page - 1) * _pageSize)
                        .Take(_pageSize),

                pagingModel = new PagingModel
                {
                    CurrentPage = page,
                    ItemsPerPage = _pageSize,
                    TotalItems = _catalogRepository.Items
                                .Select(x => x)
                                .Where(x => x.Id_Category.Equals(catalogId))
                                .Count()
                },

                CurrentCategory = currentCatalog.Name,
                CurrentCategoryId = catalogId
            };

            return viewModel;
        }

        items_picutures ICatalogHelper.GetPictureById(int productId)
        {
            var image = _catalogRepository.ItemsPicture
                        .FirstOrDefault(p => p.Id_Item.Equals(productId));

            return image;
        }

        ItemModel ICatalogHelper.GetDescriptionItemById(int productId)
        {
            var item = _catalogRepository.Items
                        .Where(x => x.Id.Equals(productId))
                        .FirstOrDefault();

            var details = _catalogRepository.ItemsDetails
                            .Where(x => x.Id_Item.Equals(productId))
                            .Select(x => x.Name)
                            .FirstOrDefault();

            string[] detailData = { "" };

            if (details != null)
                detailData = details.Split(';');

            var opinions = _catalogRepository.ItemsOpinions
                            .Where(x => x.Id_Item.Equals(productId))
                            .ToArray();

            var quantity = _catalogRepository.ItemsQuantity
                            .Where(x => x.Id_Item.Equals(productId))
                            .ToArray();

            var pictures = _catalogRepository.ItemsPicture
                            .Where(x => x.Id_Item.Equals(productId))
                            .ToArray();

            var modelToReturn = new ItemModel
            {
                Item = item,
                Opinions = opinions,
                Quantity = quantity,
                Pictures = pictures,
                DetailsItem = detailData
            };

            return modelToReturn;
        }

        void ICatalogHelper.ChangePageSize(int newSize)
        {
            _pageSize = newSize;
        }

        void ICatalogHelper.AddOpinion(OpinionModel opinionModel)
        {
            if (opinionModel.Id_User != -1 && opinionModel.Opinion != null)
            {
                var modelToSave = new items_opinions
                {
                    Id_Item = opinionModel.Id_Item,
                    Opinion = opinionModel.Opinion,
                    Rate = (Rating)opinionModel.Rate,
                    InsertTime = DateTime.Now,
                    Id_Client = opinionModel.Id_User
                };

                _catalogRepository.AddOpinion(modelToSave);
            }
            else if (opinionModel.Id_User == -1 && opinionModel.Opinion != null)
            {
                var modelToSave = new items_opinions
                {
                    Id_Item = opinionModel.Id_Item,
                    Opinion = opinionModel.Opinion,
                    Rate = (Rating)opinionModel.Rate,
                    InsertTime = DateTime.Now,
                    Id_Client = null
                };

                _catalogRepository.AddOpinion(modelToSave);
            }
        }

        items ICatalogHelper.GetItemById(int productId)
        {
            return _catalogRepository.Items
                .Where(x => x.Id.Equals(productId))
                .FirstOrDefault();
        }

        int ICatalogHelper.GetQuantityItemById(int productId)
        {
            return _catalogRepository.ItemsQuantity
                .Where(x => x.Id_Item.Equals(productId))
                .Sum(x => x.Quantity);
        }

        IndexModel ICatalogHelper.GetIndexModel()
        {
            IndexModel model = new IndexModel();

            var lastAdded = _catalogRepository
                .Items
                .OrderBy(x => x.Description.InsertTime)
                .Take(3);

            var lastAddedList = new List<LastAddedItemModel>();

            foreach (var item in lastAdded)
            {
                lastAddedList.Add
                    (new LastAddedItemModel
                    {
                        Item = item,
                        Picture = _catalogRepository.ItemsPicture.Where(x => x.Id_Item.Equals(item.Id)).FirstOrDefault(),
                        Opinions = _catalogRepository.ItemsOpinions.Where(x => x.Id_Item.Equals(item.Id)).ToList()
                    });
            }

            var topRated = from x in _catalogRepository.ItemsOpinions
                           group x by x.Id_Item into g
                           orderby g.Key
                           select new { Id_Item = g.Key, Item = g.ToList() };

            topRated = topRated.Take(3);

            var topRatedList = new List<TopRatedItemModel>();

            foreach (var item in topRated)
            {
                topRatedList.Add(
                    new TopRatedItemModel
                    {
                        Item = _catalogRepository.Items.Where(x => x.Id.Equals(item.Id_Item)).FirstOrDefault(),
                        Picure = _catalogRepository.ItemsPicture.Where(x => x.Id_Item.Equals(item.Id_Item)).FirstOrDefault(),
                        Opinions = _catalogRepository.ItemsOpinions.Where(x => x.Id_Item.Equals(item.Id_Item)).ToList()
                    });
            }

            model.LastAdded = lastAddedList;
            model.TopRated = topRatedList;

            return model;
        }

        public void Dispose()
        {
            _catalogRepository.Dispose();
            _catalogRepository = null;
        }
    }
}