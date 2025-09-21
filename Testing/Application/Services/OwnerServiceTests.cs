using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using technical_test.Application.DTOs.Owner;
using technical_test.Application.Services;
using technical_test.Core.Entities;
using technical_test.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace technical_test.Tests.Application.Services
{
    [TestFixture]
    public class OwnerServiceTests
    {
        private Mock<IOwnerRepository> _mockRepository;
        private OwnerService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IOwnerRepository>();
            _service = new OwnerService(_mockRepository.Object);
        }

        [Test]
        public async Task CreateOwnerAsync_ShouldReturnOwner_WhenValidDtoProvided()
        {
            var dto = new CreateOwnerDto
            {
                Name = "Jorge",
                Address = "Quimbaya",
                BirthDate = new DateOnly(1995, 10, 10),
                Photo = new FormFile(
                    baseStream: new MemoryStream(Encoding.UTF8.GetBytes("fake image")),
                    baseStreamOffset: 0,
                    length: 10,
                    name: "Photo",
                    fileName: "test.png"
                )
            };

            var expectedOwner = new Owner
            {
                Id = "123",
                Name = "Jorge",
                Address = "Quimbaya",
                BirthDate = new DateOnly(1995, 10, 10),
                Photo = new byte[] { 1, 2, 3, 4, 5 }
            };

            _mockRepository
                .Setup(r => r.CreateOwner(It.IsAny<Owner>()))
                .ReturnsAsync(expectedOwner);

            var result = await _service.CreateOwnerAsync(dto);

            


            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Jorge"));
            Assert.That(result.Address, Is.EqualTo("Quimbaya"));

            _mockRepository.Verify(r => r.CreateOwner(It.IsAny<Owner>()), Times.Once);
        }

        [Test]
        public async Task GetOwnerByIdAsync_ShouldReturnOwner_WhenExists()
        {
            var owner = new Owner
            {
                Id = "123",
                Name = "Carlos",
                Address = "Bogotá",
                BirthDate = new DateOnly(1990, 1, 1)
            };

            _mockRepository
                .Setup(r => r.GetOwnerById("123"))
                .ReturnsAsync(owner);

            var result = await _service.GetOwnerByIdAsync("123");\

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("123"));
            Assert.That(result.Name, Is.EqualTo("Carlos"));
            Assert.That(result.Address, Is.EqualTo("Bogotá"));
        }

        [Test]
        public async Task GetAllOwnersAsync_ShouldReturnListOfOwners()
        {
            var owners = new List<Owner>
            {
                new Owner { Id = "1", Name = "Ana", Address = "Medellín" },
                new Owner { Id = "2", Name = "Luis", Address = "Cali" }
            };

            _mockRepository
                .Setup(r => r.GetAllOwners())
                .ReturnsAsync(owners);

            var result = await _service.GetAllOwnersAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Name, Is.EqualTo("Ana"));
            Assert.That(result[1].Name, Is.EqualTo("Luis"));
        }
    }
}

