using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using technical_test.Application.DTOs.Property;
using technical_test.Application.Services;
using technical_test.Core.Entities;
using technical_test.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace technical_test.Tests.Application.Services
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private Mock<IPropertyRepository> _mockPropertyRepository;
        private Mock<IOwnerRepository> _mockOwnerRepository;
        private PropertyService _service;

        [SetUp]
        public void Setup()
        {
            _mockPropertyRepository = new Mock<IPropertyRepository>();
            _mockOwnerRepository = new Mock<IOwnerRepository>();
            _service = new PropertyService(_mockPropertyRepository.Object, _mockOwnerRepository.Object);
        }

        [Test]
        public async Task CreatePropertyAsync_ShouldReturnPropertyResponse_WhenValidDtoProvided()
        {
            var dto = new CreatePropertyDto
            {
                Name = "Casa Finca",
                Address = "Quimbaya",
                Price = 500000,
                CodeInternal = "C-001",
                Year = "2020",
                OwnerId = "owner123",
                Images = new List<PropertyImageInputDto>
                {
                    new PropertyImageInputDto
                    {
                        FileUrl = new FormFile(
                            baseStream: new MemoryStream(Encoding.UTF8.GetBytes("fake image")),
                            baseStreamOffset: 0,
                            length: 10,
                            name: "image",
                            fileName: "image.png"
                        ),
                        Enabled = true
                    }
                }
            };

            var expectedProperty = new Property
            {
                Id = "prop123",
                Name = "Casa Finca",
                Address = "Quimbaya",
                Price = 500000,
                CodeInternal = "C-001",
                Year = "2020",
                OwnerId = "owner123",
                Images = new List<PropertyImage>
                {
                    new PropertyImage
                    {
                        FileUrl = new byte[] { 1, 2, 3 },
                        Enabled = true
                    }
                }
            };

            _mockPropertyRepository
                .Setup(r => r.CreateProperty(It.IsAny<Property>()))
                .ReturnsAsync(expectedProperty);

            var result = await _service.CreatePropertyAsync(dto);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("prop123"));
            Assert.That(result.Name, Is.EqualTo("Casa Finca"));
            Assert.That(result.Address, Is.EqualTo("Quimbaya"));
            Assert.That(result.Images.Count, Is.EqualTo(1));

            _mockPropertyRepository.Verify(r => r.CreateProperty(It.IsAny<Property>()), Times.Once);
        }

        [Test]
        public async Task GetPropertyByIdAsync_ShouldReturnPropertyResponse_WhenExists()
        {
            var property = new Property
            {
                Id = "prop123",
                Name = "Apartamento",
                Address = "Bogotá",
                Price = 800000,
                CodeInternal = "AP-777",
                Year = "2022",
                OwnerId = "owner123"
            };

            _mockPropertyRepository
                .Setup(r => r.GetPropertyById("prop123"))
                .ReturnsAsync(property);

            var result = await _service.GetPropertyByIdAsync("prop123");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("prop123"));
            Assert.That(result.Name, Is.EqualTo("Apartamento"));
            Assert.That(result.Address, Is.EqualTo("Bogotá"));
            Assert.That(result.Price, Is.EqualTo(800000));
        }

        [Test]
        public async Task GetAllPropertiesAsync_ShouldReturnFilteredList()
        {
            var properties = new List<Property>
            {
                new Property { Id = "1", Name = "Casa Roja", Address = "Medellín", Price = 300000 },
                new Property { Id = "2", Name = "Casa Azul", Address = "Cali", Price = 600000 }
            };

            _mockPropertyRepository
                .Setup(r => r.GetAllProperties())
                .ReturnsAsync(properties);

            var result = await _service.GetAllPropertiesAsync(name: "Roja", address: null, priceMin: null, priceMax: null);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("Casa Roja"));
        }
    }
}
